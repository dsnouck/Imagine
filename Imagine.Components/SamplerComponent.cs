namespace Imagine.Components;

public class SamplerComponent(IColorComponent colorComponent, ILineComponent lineComponent) : ISamplerComponent
{
	private const double Half = 0.5D;

	public List<List<RgbColor>> Sample(Func<Vector2, HsvColor> function, ImageSettings settings)
	{
		RgbColor RgbFunction(Vector2 point) => colorComponent.ToRgb(function(point));

		return Sample(RgbFunction, settings);
	}

	public List<List<RgbColor>> Sample(Func<Vector2, RgbColor> function, ImageSettings settings)
	{
		var rowToY = lineComponent.Line(
			new Vector2(-Half, settings.MaximumY),
			new Vector2((settings.Rows * settings.Subsamples) - Half, settings.MinimumY));

		var columnToX = lineComponent.Line(
			new Vector2(-Half, settings.MinimumX),
			new Vector2((settings.Columns * settings.Subsamples) - Half, settings.MaximumX));

		return Enumerable.Range(0, settings.Rows)
			.AsParallel()
			.AsOrdered()
			.Select(row => Enumerable.Range(0, settings.Columns)
				.Select(column => colorComponent.Average(
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
}
