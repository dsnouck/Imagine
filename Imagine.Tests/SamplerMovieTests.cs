namespace Imagine.Tests;

[Collection(Constants.EmptyOutput)]
public class SamplerMovieTests
{
	private static readonly MovieSettings MovieSettings =
		new(
			Frames: 256,
			Width: 256,
			Height: 256,
			Subsamples: 2,
			XMin: 0F,
			XMax: 1F,
			YMin: 0F,
			YMax: 1F,
			ZMin: 0F,
			ZMax: 2F);

	[Fact]
	public void SamplerMovieHsv()
	{
		const string name = "hsv";

		static ColorHsv Function(Vector3 point)
		{
			var t = point.Z < 1F ? point.Z : 2F - point.Z;
			var center = new Vector2(t, t);
			var point2 = (Vector2)point;
			var r = (point2 - center).Length();

			return new(
				(2F * point.X) - 1F,
				r < 0.25F ? 1F - (4F * r) : 0F,
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
			var t = point.Z < 1F ? point.Z : 2F - point.Z;
			var center = new Vector2(t, t);
			var point2 = (Vector2)point;
			var r = (point2 - center).Length();

			return new(
				point.X,
				r < 0.25F ? 1F - (4F * r) : 0F,
				point.Y);
		}

		var movie = Sampler.Sample(Function, MovieSettings);
		var outputFile = Saver.Save(movie, name);

		File.Exists(outputFile).Should().BeTrue();
	}
}
