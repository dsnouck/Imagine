namespace Imagine.Tests;

public class ImageTests
{
	[Fact]
	public void ImageHsv()
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

		var image = Sampler.Sample(Function, settings);
		Saver.Save(image, name);
	}

	[Fact]
	public void ImageRed()
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

		Saver.Save(image, name);
	}

	[Fact]
	public void ImageRgb()
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

		var image = Sampler.Sample(Function, settings);
		Saver.Save(image, name);
	}
}
