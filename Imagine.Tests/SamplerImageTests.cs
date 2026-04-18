namespace Imagine.Tests;

public class SamplerImageTests
{
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
	public void SamplerImageHsv()
	{
		const string name = "hsv";
		const string inputFile = $"{Constants.InputDirectory}/{name}.png";

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
	public void SamplerImageRgb()
	{
		const string name = "rgb";
		const string inputFile = $"{Constants.InputDirectory}/{name}.png";

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
