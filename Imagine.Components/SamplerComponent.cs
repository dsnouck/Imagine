namespace Imagine.Components;

public class SamplerComponent(ILine2Component line2Component) : ISamplerComponent
{
	public List<List<ColorRgb>> Sample(Func<Vector2, ColorHsv> function, ImageSettings settings)
	{
		ColorRgb RgbFunction(Vector2 point) => (ColorRgb)function(point);

		return Sample(RgbFunction, settings);
	}

	public List<List<ColorRgb>> Sample(Func<Vector2, ColorRgb> function, ImageSettings settings)
	{
		var rowToY = line2Component.Line(
			new Vector2(-0.5D, settings.YMax),
			new Vector2((settings.Height * settings.Subsamples) - 0.5D, settings.YMin));

		var columnToX = line2Component.Line(
			new Vector2(-0.5D, settings.XMin),
			new Vector2((settings.Width * settings.Subsamples) - 0.5D, settings.XMax));

		return Enumerable.Range(0, settings.Height)
			.AsParallel()
			.AsOrdered()
			.Select(row => Enumerable.Range(0, settings.Width)
				.Select(column => ColorRgb.Average(
					Enumerable.Range(0, settings.Subsamples)
						.Select(subrow => rowToY((row * settings.Subsamples) + subrow))
						.SelectMany(y => Enumerable.Range(0, settings.Subsamples)
							.Select(subcolumn => columnToX((column * settings.Subsamples) + subcolumn))
							.Select(x => new Vector2(x, y))
							.Select(function))
						.ToList()))
				.ToList())
			.ToList();
	}

	public List<List<List<ColorRgb>>> Sample(Func<Vector3, ColorHsv> function, MovieSettings settings)
	{
		ColorRgb RgbFunction(Vector3 point) => (ColorRgb)function(point);

		return Sample(RgbFunction, settings);
	}

	public List<List<List<ColorRgb>>> Sample(Func<Vector3, ColorRgb> function, MovieSettings settings)
	{
		var frameToZ = line2Component.Line(
			new Vector2(-0.5D, settings.ZMin),
			new Vector2(settings.Frames - 0.5D, settings.ZMax));

		var imageSettings = new ImageSettings(
			Width: settings.Width,
			Height: settings.Height,
			Subsamples: settings.Subsamples,
			XMin: settings.XMin,
			XMax: settings.XMax,
			YMin: settings.YMin,
			YMax: settings.YMax);

		var movie = new List<List<List<ColorRgb>>>();

		for (var frame = 0; frame < settings.Frames; frame++)
		{
			var z = frameToZ(frame);

			ColorRgb CreateColor(Vector2 point) => function(new Vector3(point.X, point.Y, z));

			movie.Add(Sample(CreateColor, imageSettings));
		}

		return movie;
	}
}
