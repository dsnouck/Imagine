namespace Imagine.Tests;

public class MovieTests
{
	private const string InputDirectory = "input";

	[Fact]
	public void MovieHsv()
	{
		const string name = "hsv";
		const string inputFile = $"{InputDirectory}/{name}.mp4";

		var settings = new MovieSettings(
			Frames: 256,
			Width: 256,
			Height: 256,
			Subsamples: 2,
			XMin: 0D,
			XMax: 1D,
			YMin: 0D,
			YMax: 1D,
			ZMin: 0D,
			ZMax: 2D);

		static ColorHsv Function(Vector3 point)
		{
			var z = point.Z < 1D ? point.Z : 2D - point.Z;
			var center = new Vector2(z, z);
			var point2 = (Vector2)point;
			var r = (point2 - center).Length();

			var hue = (2D * point.X) - 1D;
			var saturation = r < 0.25D ? 1D - (4D * r) : 0D;
			var value = point.Y;

			return new(hue, saturation, value);
		}

		var movie = Sampler.Sample(Function, settings);
		var outputFile = Saver.Save(movie, name);

		outputFile.ShouldHaveSameContentAs(inputFile);
	}

	[Fact]
	public void MovieRed()
	{
		const string name = "red";
		const string inputFile = $"{InputDirectory}/{name}.mp4";

		const int frames = 256;
		const int width = 256;
		const int height = 256;
		var red = new ColorRgb(1D, 0D, 0D);

		var movie = Enumerable.Repeat(
			Enumerable.Repeat(
				Enumerable.Repeat(
					red,
					width).ToList(),
				height).ToList(),
			frames).ToList();

		var outputFile = Saver.Save(movie, name);

		outputFile.ShouldHaveSameContentAs(inputFile);
	}

	[Fact]
	public void MovieRgb()
	{
		const string name = "rgb";
		const string inputFile = $"{InputDirectory}/{name}.mp4";

		var settings = new MovieSettings(
			Frames: 256,
			Width: 256,
			Height: 256,
			Subsamples: 2,
			XMin: 0D,
			XMax: 1D,
			YMin: 0D,
			YMax: 1D,
			ZMin: 0D,
			ZMax: 2D);

		static ColorRgb Function(Vector3 point)
		{
			var z = point.Z < 1D ? point.Z : 2D - point.Z;
			var center = new Vector2(z, z);
			var point2 = (Vector2)point;
			var r = (point2 - center).Length();

			var red = point.X;
			var green = r < 0.25D ? 1D - (4D * r) : 0D;
			var blue = point.Y;

			return new(red, green, blue);
		}

		var movie = Sampler.Sample(Function, settings);
		var outputFile = Saver.Save(movie, name);

		outputFile.ShouldHaveSameContentAs(inputFile);
	}
}
