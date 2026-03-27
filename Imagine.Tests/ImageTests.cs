namespace Imagine.Tests;

public class ImageTests
{
	private const string InputDirectory = "input";

	private static readonly ImageSettings ImageSettings =
		new(
			Width: 512,
			Height: 512,
			Subsamples: 2,
			XMin: 0D,
			XMax: 1D,
			YMin: 0D,
			YMax: 1D);

	[Fact]
	public void ImageHsv()
	{
		const string name = "hsv";
		const string inputFile = $"{InputDirectory}/{name}.png";

		static ColorHsv Function(Vector2 point)
		{
			var center = new Vector2(0.5D, 0.5D);
			var r = (point - center).Length();

			var hue = (2D * point.X) - 1D;
			var saturation = r < 0.5D ? 1D - (2D * r) : 0D;
			var value = point.Y;

			return new(hue, saturation, value);
		}

		var image = Sampler.Sample(Function, ImageSettings);
		var outputFile = Saver.Save(image, name);

		outputFile.ShouldHaveSameContentAs(inputFile);
	}

	[Fact]
	public void ImageRed()
	{
		const string name = "red";
		const string inputFile = $"{InputDirectory}/{name}.png";

		const int width = 512;
		const int height = 512;
		var red = new ColorRgb(1D, 0D, 0D);

		var image = Enumerable.Repeat(
			Enumerable.Repeat(
				red,
				width).ToList(),
			height).ToList();

		var outputFile = Saver.Save(image, name);

		outputFile.ShouldHaveSameContentAs(inputFile);
	}

	[Fact]
	public void ImageRgb()
	{
		const string name = "rgb";
		const string inputFile = $"{InputDirectory}/{name}.png";

		static ColorRgb Function(Vector2 point)
		{
			var center = new Vector2(0.5D, 0.5D);
			var r = (point - center).Length();

			var red = point.X;
			var green = r < 0.5D ? 1D - (2D * r) : 0D;
			var blue = point.Y;

			return new(red, green, blue);
		}

		var image = Sampler.Sample(Function, ImageSettings);
		var outputFile = Saver.Save(image, name);

		outputFile.ShouldHaveSameContentAs(inputFile);
	}
}
