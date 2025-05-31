namespace Imagine.Tests;

public class ImageTests
{
	private const int Rows = 512;
	private const int Columns = 512;

	private readonly IColorComponent colorComponent;
	private readonly IFileComponent fileComponent;
	private readonly ILineComponent lineComponent;
	private readonly ISamplerComponent samplerComponent;

	public ImageTests()
	{
		colorComponent = new ColorComponent();
		fileComponent = new FileComponent(colorComponent);
		lineComponent = new LineComponent();
		samplerComponent = new SamplerComponent(colorComponent, lineComponent);
	}

	[Fact]
	public void Red()
	{
		const string name = "red";

		var image = Enumerable.Repeat(
			Enumerable.Repeat(
				new RgbColor(1D, 0D, 0D),
				Columns).ToList(),
			Rows).ToList();

		fileComponent.Save(image, name);
	}

	[Fact]
	public void RgbGradient()
	{
		const string name = "rgb-gradient";

		var settings = new ImageSettings(
			Rows: Rows,
			Columns: Columns,
			Subsamples: 4,
			XMin: 0D,
			XMax: 1D,
			YMin: 0D,
			YMax: 1D);

		static RgbColor Function(Vector2 point)
		{
			var r = Math.Sqrt((point.X * point.X) + (point.Y * point.Y));

			var red = point.X;
			var green = 1D / (1D + (4D * r * r));
			var blue = point.Y;

			return new RgbColor(red, green, blue);
		}

		var image = samplerComponent.Sample(Function, settings);
		fileComponent.Save(image, name);
	}
}
