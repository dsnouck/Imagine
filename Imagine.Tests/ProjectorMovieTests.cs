namespace Imagine.Tests;

[Collection(Constants.EmptyOutput)]
public class ProjectorMovieTests()
{
	[Fact(Skip = Constants.LongDuration)]
	public void ProjectorMovieCubeFaceDownRotating()
	{
		const string name = "cube-face-down-rotating";

		var movieSettings =
			new MovieSettings(
				frames: 64,
				width: 256,
				height: 256,
				subsamples: 2);

		var scene = Scene.CubeFaceDownWithCircumradius(Constants.Circumradius);

		Func<Vector2, Color> Function(float t)
		{
			var projectorSettings =
				ProjectorSettings.WithOpeningRadius(
					eye: (Vector3)new Vector3Spherical(10F, (float.Pi / 6F) - (float.Pi * t / 2F), float.Pi / 3F),
					focus: Vector3.Zero,
					openingRadius: Constants.Circumradius * 5F / 4F);

			return Projector.Project(scene, projectorSettings);
		}

		var movie = Sampler.Sample(Function, movieSettings);
		var outputFile = Saver.Save(movie, name);

		File.Exists(outputFile).Should().BeTrue();
	}

	[Fact(Skip = Constants.LongDuration)]
	public void ProjectorMovieIcosahedronFaceDownFadeToOctahedronVertexDown()
	{
		const string name = "icosahedron-face-down-fade-to-octahedron-vertex-down";

		var movieSettings =
			new MovieSettings(
				frames: 256,
				width: 256,
				height: 256,
				subsamples: 2,
				zMin: 0F,
				zMax: 2F);

		var scene0 = Scene.IcosahedronFaceDownWithMidradius(Constants.DodecahedronIcosahedronMidradius);
		var scene1 = Scene.DodecahedronVertexDownWithMidradius(Constants.DodecahedronIcosahedronMidradius);

		Func<Vector2, Color> Function(float t)
		{
			var tProjector = t < 1F ? t : t - 1F;
			var tUnion = t < 1F ? t : 2F - t;

			var projectorSettings =
				ProjectorSettings.WithOpeningRadius(
					eye: (Vector3)new Vector3Spherical(10F, (float.Pi / 6F) - (2F * float.Pi * tProjector), float.Pi / 3F),
					focus: Vector3.Zero,
					openingRadius: Constants.Circumradius * 5F / 4F);

			Color Projection(Vector2 point)
			{
				var projection0 = Projector.Project(scene0, projectorSettings);
				var color0 = projection0(point);
				var projection1 = Projector.Project(scene1, projectorSettings);
				var color1 = projection1(point);

				return (color0 * (1F - tUnion)) + (color1 * tUnion);
			}

			return Projection;
		}

		var movie = Sampler.Sample(Function, movieSettings);
		var outputFile = Saver.Save(movie, name);

		File.Exists(outputFile).Should().BeTrue();
	}

	[Fact(Skip = Constants.LongDuration)]
	public void ProjectorMovieIcosahedronFaceDownWithOctahedronVertexDownAppearing()
	{
		const string name = "icosahedron-face-down-with-octahedron-vertex-down-appearing";

		var movieSettings =
			new MovieSettings(
				frames: 256,
				width: 256,
				height: 256,
				subsamples: 2,
				zMin: 0F,
				zMax: 2F);

		var scene0 = Scene.IcosahedronFaceDownWithMidradius(Constants.DodecahedronIcosahedronMidradius);
		var scene1 = Scene.Union(
			Scene.IcosahedronFaceDownWithMidradius(Constants.DodecahedronIcosahedronMidradius),
			Scene.DodecahedronVertexDownWithMidradius(Constants.DodecahedronIcosahedronMidradius));

		Func<Vector2, Color> Function(float t)
		{
			var tProjector = t < 1F ? t : t - 1F;
			var tUnion = t < 1F ? t : 2F - t;

			var projectorSettings =
				ProjectorSettings.WithOpeningRadius(
					eye: (Vector3)new Vector3Spherical(10F, (float.Pi / 6F) - (2F * float.Pi * tProjector), float.Pi / 3F),
					focus: Vector3.Zero,
					openingRadius: Constants.Circumradius * 5F / 4F);

			Color Projection(Vector2 point)
			{
				var projection0 = Projector.Project(scene0, projectorSettings);
				var color0 = projection0(point);
				var projection1 = Projector.Project(scene1, projectorSettings);
				var color1 = projection1(point);

				return (color0 * (1F - tUnion)) + (color1 * tUnion);
			}

			return Projection;
		}

		var movie = Sampler.Sample(Function, movieSettings);
		var outputFile = Saver.Save(movie, name);

		File.Exists(outputFile).Should().BeTrue();
	}
}
