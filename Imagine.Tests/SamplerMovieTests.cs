namespace Imagine.Tests;

public class SamplerMovieTests
{
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
	public void SamplerMovieHsv()
	{
		const string name = "hsv";

		static ColorHsv Function(Vector3 point)
		{
			var t = point.Z < 1D ? point.Z : 2D - point.Z;
			var center = new Vector2(t, t);
			var point2 = (Vector2)point;
			var r = (point2 - center).Length();

			return new(
				(2D * point.X) - 1D,
				r < 0.25D ? 1D - (4D * r) : 0D,
				point.Y);
		}

		var movie = Sampler.Sample(Function, MovieSettings);
		var outputFile = Saver.Save(movie, name);

		File.Exists(outputFile).Should().BeTrue();
	}

	[Fact]
	public void SamplerMovieRgb()
	{
		const string name = "rgb";

		static Color Function(Vector3 point)
		{
			var t = point.Z < 1D ? point.Z : 2D - point.Z;
			var center = new Vector2(t, t);
			var point2 = (Vector2)point;
			var r = (point2 - center).Length();

			return new(
				point.X,
				r < 0.25D ? 1D - (4D * r) : 0D,
				point.Y);
		}

		var movie = Sampler.Sample(Function, MovieSettings);
		var outputFile = Saver.Save(movie, name);

		File.Exists(outputFile).Should().BeTrue();
	}
}
