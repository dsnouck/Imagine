namespace Imagine.Tests;

[Collection(Constants.EmptyOutput)]
public class SamplerImageTests
{
	private static readonly ImageSettings ImageSettings =
		new(
			Width: 512,
			Height: 512,
			Subsamples: 2,
			XMin: 0F,
			XMax: 1F,
			YMin: 0F,
			YMax: 1F);

	[Fact]
	public void SamplerImageHsv()
	{
		const string name = "hsv";
		const string inputFile = $"{Constants.InputDirectory}/{name}.png";

		static ColorHsv Function(Vector2 point)
		{
			var center = new Vector2(0.5F, 0.5F);
			var r = (point - center).Length();

			return new(
				(2F * point.X) - 1F,
				r < 0.5F ? 1F - (2F * r) : 0F,
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
			var center = new Vector2(0.5F, 0.5F);
			var r = (point - center).Length();

			return new(
				point.X,
				r < 0.5F ? 1F - (2F * r) : 0F,
				point.Y);
		}

		var image = Sampler.Sample(Function, ImageSettings);
		var outputFile = Saver.Save(image, name);

		outputFile.ShouldHaveSameContentAs(inputFile);
	}
}
