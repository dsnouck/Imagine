namespace Imagine.Tests;

public class ProjectorMovieTests
{
	private static readonly MovieSettings MovieSettings =
		new(
			frames: 64,
			width: 256,
			height: 256,
			subsamples: 2);

	[Fact]
	public void ProjectorMovieCubeRotating()
	{
		const string name = "cube-rotating";

		var scene = Scene.CubeFaceDownWithCircumradius(Constants.Circumradius);

		Func<Vector2, Color> Function(double t)
		{
			var projectorSettings =
				ProjectorSettings.WithOpeningRadius(
					eye: (Vector3)new Vector3Spherical(10D, (double.Pi / 6D) + (double.Pi * t / 2D), double.Pi / 3D),
					focus: Vector3.Zero,
					openingRadius: Constants.Circumradius * 5D / 4D);

			return Projector.Project(scene, projectorSettings);
		}

		var movie = Sampler.Sample(Function, MovieSettings);
		var outputFile = Saver.Save(movie, name);

		File.Exists(outputFile).Should().BeTrue();
	}
}
