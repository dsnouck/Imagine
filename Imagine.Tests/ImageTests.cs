namespace Imagine.Tests;

public class ImageTests
{
	private readonly ISamplerComponent samplerComponent;

	public ImageTests()
	{
		samplerComponent = new SamplerComponent();
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
			XMax: 1D,
			YMin: 0D,
			YMax: 1D);

		static ColorHsv Function(Vector2 point)
		{
			var center = new Vector2(0.5D, 0.5D);
			var r = (point - center).Length();

			var hue = (2D * point.X) - 1D;
			var saturation = r < 0.5D ? 1D - (2D * r) : 0D;
			var value = point.Y;

			return new ColorHsv(hue, saturation, value);
		}

		var image = samplerComponent.Sample(Function, settings);
		FileSaver.Save(image, name);
	}

	[Fact]
	public void Red()
	{
		const string name = "red";

		const int width = 512;
		const int height = 512;
		var red = new ColorRgb(1D, 0D, 0D);

		var image = Enumerable.Repeat(
			Enumerable.Repeat(
				red,
				width).ToList(),
			height).ToList();

		FileSaver.Save(image, name);
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
			XMax: 1D,
			YMin: 0D,
			YMax: 1D);

		static ColorRgb Function(Vector2 point)
		{
			var center = new Vector2(0.5D, 0.5D);
			var r = (point - center).Length();

			var red = point.X;
			var green = r < 0.5D ? 1D - (2D * r) : 0D;
			var blue = point.Y;

			return new ColorRgb(red, green, blue);
		}

		var image = samplerComponent.Sample(Function, settings);
		FileSaver.Save(image, name);
	}
}
