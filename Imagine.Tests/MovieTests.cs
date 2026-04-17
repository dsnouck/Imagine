namespace Imagine.Tests;

public class MovieTests
{
	private const string InputDirectory = "input";

	private static readonly MovieSettings MovieSettings =
		new(
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

	[Fact]
	public void MovieHsv()
	{
		const string name = "hsv";
		const string inputFile = $"{InputDirectory}/{name}.mp4";

		static ColorHsv Function(Vector3 point)
		{
			var z = point.Z < 1D ? point.Z : 2D - point.Z;
			var center = new Vector2(z, z);
			var point2 = (Vector2)point;
			var r = (point2 - center).Length();

			return new(
				(2D * point.X) - 1D,
				r < 0.25D ? 1D - (4D * r) : 0D,
				point.Y);
		}

		var movie = Sampler.Sample(Function, MovieSettings);
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

		var movie = Enumerable.Repeat(
			Enumerable.Repeat(
				Enumerable.Repeat(
					Color.Red,
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

		static Color Function(Vector3 point)
		{
			var z = point.Z < 1D ? point.Z : 2D - point.Z;
			var center = new Vector2(z, z);
			var point2 = (Vector2)point;
			var r = (point2 - center).Length();

			return new(
				point.X,
				r < 0.25D ? 1D - (4D * r) : 0D,
				point.Y);
		}

		var movie = Sampler.Sample(Function, MovieSettings);
		var outputFile = Saver.Save(movie, name);

		outputFile.ShouldHaveSameContentAs(inputFile);
	}
}
