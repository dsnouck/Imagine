namespace Imagine.Components;

public class SamplerComponent(IColorComponent colorComponent, ILineComponent lineComponent) : ISamplerComponent
{
	private const double Half = 0.5D;

	public List<List<RgbColor>> Sample(Func<Vector2, RgbColor> function, ImageSettings settings)
	{
		var rowToY = lineComponent.LineThrough(
			new Vector2(-Half, settings.YMax),
			new Vector2((settings.Rows * settings.Subsamples) - Half, settings.YMin));

		var columnToX = lineComponent.LineThrough(
			new Vector2(-Half, settings.XMin),
			new Vector2((settings.Columns * settings.Subsamples) - Half, settings.XMax));

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
