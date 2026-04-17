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

			return new(
				(2D * point.X) - 1D,
				r < 0.5D ? 1D - (2D * r) : 0D,
				point.Y);
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

		var image = Enumerable.Repeat(
			Enumerable.Repeat(
				Color.Red,
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

		static Color Function(Vector2 point)
		{
			var center = new Vector2(0.5D, 0.5D);
			var r = (point - center).Length();

			return new(
				point.X,
				r < 0.5D ? 1D - (2D * r) : 0D,
				point.Y);
		}

		var image = Sampler.Sample(Function, ImageSettings);
		var outputFile = Saver.Save(image, name);

		outputFile.ShouldHaveSameContentAs(inputFile);
	}
}
