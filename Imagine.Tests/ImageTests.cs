namespace Imagine.Tests;

public class ImageTests
{
	private readonly IColorComponent colorComponent;
	private readonly IFileComponent fileComponent;
	private readonly ILineComponent lineComponent;
	private readonly ISamplerComponent samplerComponent;
	private readonly IVector2Component vector2Component;

	public ImageTests()
	{
		colorComponent = new ColorComponent();
		fileComponent = new FileComponent(colorComponent);
		lineComponent = new LineComponent();
		samplerComponent = new SamplerComponent(colorComponent, lineComponent);
		vector2Component = new Vector2Component();
	}

	[Fact]
	public void Hsv()
	{
		const string name = "hsv";

		var settings = new ImageSettings(
			Width: 512,
			Height: 512,
			Subsamples: 2,
			XMin: 0D,
			Xmax: 1D,
			YMin: 0D,
			Ymax: 1D);

		HsvColor Function(Vector2 point)
		{
			var center = new Vector2(0.5D, 0.5D);
			var r = vector2Component.Length(vector2Component.Subtract(point, center));

			var hue = (2D * point.X) - 1D;
			var saturation = r < 0.5D ? 1D - (2D * r) : 0D;
			var value = point.Y;

			return new HsvColor(hue, saturation, value);
		}

		var image = samplerComponent.Sample(Function, settings);
		fileComponent.Save(image, name);
	}

	[Fact]
	public void Red()
	{
		const string name = "red";

		const int width = 512;
		const int height = 512;
		var red = new RgbColor(1D, 0D, 0D);

		var image = Enumerable.Repeat(
			Enumerable.Repeat(
				red,
				width).ToList(),
			height).ToList();

		fileComponent.Save(image, name);
	}

	[Fact]
	public void Rgb()
	{
		const string name = "rgb";

		var settings = new ImageSettings(
			Width: 512,
			Height: 512,
			Subsamples: 2,
			XMin: 0D,
			Xmax: 1D,
			YMin: 0D,
			Ymax: 1D);

		RgbColor Function(Vector2 point)
		{
			var center = new Vector2(0.5D, 0.5D);
			var r = vector2Component.Length(vector2Component.Subtract(point, center));

			var red = point.X;
			var green = r < 0.5D ? 1D - (2D * r) : 0D;
			var blue = point.Y;

			return new RgbColor(red, green, blue);
		}

		var image = samplerComponent.Sample(Function, settings);
		fileComponent.Save(image, name);
	}
}
