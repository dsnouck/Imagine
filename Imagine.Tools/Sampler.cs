namespace Imagine.Tools;

using Color = Models.Color;

public static class Sampler
{
	public static List<List<Color>> Sample(Func<Vector2, ColorHsv> function, ImageSettings settings)
	{
		Color RgbFunction(Vector2 point) =>
			(Color)function(point);

		return Sample(RgbFunction, settings);
	}

	public static List<List<Color>> Sample(Func<Vector2, Color> function, ImageSettings settings)
	{
		var rowToY = Line(
			from: new(-0.5F, settings.YMax),
			to: new((settings.Height * settings.Subsamples) - 0.5F, settings.YMin));

		var columnToX = Line(
			from: new(-0.5F, settings.XMin),
			to: new((settings.Width * settings.Subsamples) - 0.5F, settings.XMax));

		return Enumerable.Range(0, settings.Height)
			.AsParallel()
			.AsOrdered()
			.Select(row => Enumerable.Range(0, settings.Width)
				.Select(column => Color.Average(
					[.. Enumerable.Range(0, settings.Subsamples)
						.Select(subrow => rowToY((row * settings.Subsamples) + subrow))
						.SelectMany(y => Enumerable.Range(0, settings.Subsamples)
							.Select(subcolumn => columnToX((column * settings.Subsamples) + subcolumn))
							.Select(x => new Vector2(x, y))
							.Select(function))]))
				.ToList())
			.ToList();
	}

	public static List<List<List<Color>>> Sample(Func<Vector3, ColorHsv> function, MovieSettings settings)
	{
		Color RgbFunction(Vector3 point) =>
			(Color)function(point);

		return Sample(RgbFunction, settings);
	}

	public static List<List<List<Color>>> Sample(Func<Vector3, Color> function, MovieSettings settings) =>
		Sample(t => point => function(new(point.X, point.Y, t)), settings);

	public static List<List<List<Color>>> Sample(Func<float, Func<Vector2, Color>> function, MovieSettings settings)
	{
		var frameToT = Line(
			from: new(-0.5F, settings.ZMin),
			to: new(settings.Frames - 0.5F, settings.ZMax));

		var movie = new List<List<List<Color>>>();
		for (var frame = 0; frame < settings.Frames; frame++)
		{
			var t = frameToT(frame);
			var frameFunction = function(t);

			movie.Add(Sample(frameFunction, (ImageSettings)settings));
		}

		return movie;
	}

	private static Func<float, float> Line(Vector2 from, Vector2 to)
	{
		var slope = (to.Y - from.Y) / (to.X - from.X);
		var intercept = ((from.Y * to.X) - (from.X * to.Y)) / (to.X - from.X);

		return x => (slope * x) + intercept;
	}
}
