namespace Imagine.Tests;

public class ProjectorImageTests
{
	private const float Narrow = 0.01F;

	private static readonly float CubeOctahedronMidradius =
		Constants.Circumradius * float.Min(
			Scene.CubeMidradius / Scene.CubeCircumradius,
			Scene.OctahedronMidradius / Scene.OctahedronCircumradius);

	private static readonly float DodecahedronIcosahedronMidradius =
		Constants.Circumradius * float.Min(
			Scene.DodecahedronMidradius / Scene.DodecahedronCircumradius,
			Scene.IcosahedronMidradius / Scene.IcosahedronCircumradius);

	private static readonly float SphereAlmostTouchingCubeEdgeRadius =
		(Constants.Circumradius * Scene.CubeMidradius / Scene.CubeCircumradius) - Narrow;

	private static readonly float TetrahedronMidradius =
		Constants.Circumradius * Scene.TetrahedronMidradius / Scene.TetrahedronCircumradius;

	private static readonly ProjectorSettings ProjectorSettings =
		ProjectorSettings.WithOpeningRadius(
			eye: (Vector3)new Vector3Spherical(10F, float.Pi / 6F, float.Pi / 3F),
			focus: Vector3.Zero,
			openingRadius: Constants.Circumradius * 5F / 4F);

	private static readonly ImageSettings ImageSettings =
		new(
			width: 512,
			height: 512,
			subsamples: 2);

	private static readonly IScene BoundingSphere = Scene.SphereWithRadius(Constants.Circumradius).Transparent();
	private static readonly IScene SphereAlmostTouchingCubeEdge = Scene.SphereWithRadius(SphereAlmostTouchingCubeEdgeRadius);

	private static readonly Dictionary<string, IScene> Scenes =
		new()
		{
			["cone-bounded"] =
				Scene.Intersection(
					Scene.Cone(Vector3.UnitZ, float.Pi / 2F),
					BoundingSphere),
			["cone-union"] =
				Scene.Union(
					Scene.Cone(Vector3.UnitX, float.Pi / 16F).Painted(Color.Red),
					Scene.Cone(Vector3.UnitY, float.Pi / 16F).Painted(Color.Green),
					Scene.Cone(Vector3.UnitZ, float.Pi / 16F).Painted(Color.Blue)),
			["cube-face-down"] =
				Scene.CubeFaceDownWithCircumradius(Constants.Circumradius),
			["cube-face-down-octahedron-vertex-down-union"] =
				Scene.Union(
					Scene.CubeFaceDownWithMidradius(CubeOctahedronMidradius),
					Scene.OctahedronVertexDownWithMidradius(CubeOctahedronMidradius)),
			["cube-face-down-rotated"] =
				Scene.CubeFaceDownWithCircumradius(Constants.Circumradius)
					.Rotated(float.Pi / 4F),
			["cube-face-down-scaled"] =
				Scene.CubeFaceDownWithCircumradius(Constants.Circumradius)
					.Scaled(Constants.Circumradius / 2F),
			["cube-face-down-sphere-intersection"] =
				Scene.Intersection(
					Scene.CubeFaceDownWithCircumradius(Constants.Circumradius),
					Scene.SphereWithRadius(1F).
						Scaled(SphereAlmostTouchingCubeEdgeRadius)),
			["cube-face-down-sphere-inverted-union"] =
				Scene.Intersection(
					Scene.CubeFaceDownWithCircumradius(Constants.Circumradius),
					SphereAlmostTouchingCubeEdge.Inverted()),
			["cube-face-down-sphere-union"] =
				Scene.Union(
					Scene.CubeFaceDownWithCircumradius(Constants.Circumradius),
					SphereAlmostTouchingCubeEdge),
			["cube-face-down-translated"] =
				Scene.CubeFaceDownWithCircumradius(Constants.Circumradius)
					.Translated(new(0F, Constants.Circumradius / 4F, 0F)),
			["cube-vertex-down"] =
				Scene.CubeVertexDownWithCircumradius(Constants.Circumradius),
			["cylinder-bounded"] =
				Scene.Intersection(
					Scene.Cylinder(Vector3.UnitZ, Constants.Circumradius / 2F),
					BoundingSphere),
			["cylinder-intersection"] =
				Scene.Intersection(
					Scene.Cylinder(Vector3.UnitX, Constants.Circumradius / 2F).Painted(Color.Red),
					Scene.Cylinder(Vector3.UnitY, Constants.Circumradius / 2F).Painted(Color.Green),
					Scene.Cylinder(Vector3.UnitZ, Constants.Circumradius / 2F).Painted(Color.Blue)),
			["cylinder-union"] =
				Scene.Union(
					Scene.Cylinder(Vector3.UnitX, Constants.Circumradius / 4F).Painted(Color.Red),
					Scene.Cylinder(Vector3.UnitY, Constants.Circumradius / 4F).Painted(Color.Green),
					Scene.Cylinder(Vector3.UnitZ, Constants.Circumradius / 4F).Painted(Color.Blue)),
			["dodecahedron-face-down"] =
				Scene.DodecahedronFaceDownWithCircumradius(Constants.Circumradius),
			["dodecahedron-face-down-icosahedron-vertex-down-union"] =
				Scene.Union(
					Scene.DodecahedronFaceDownWithMidradius(DodecahedronIcosahedronMidradius),
					Scene.IcosahedronVertexDownWithMidradius(DodecahedronIcosahedronMidradius)),
			["dodecahedron-vertex-down"] =
				Scene.DodecahedronVertexDownWithCircumradius(Constants.Circumradius),
			["icosahedron-face-down"] =
				Scene.IcosahedronFaceDownWithCircumradius(Constants.Circumradius),
			["icosahedron-face-down-dodecahedron-vertex-down-union"] =
				Scene.Union(
					Scene.IcosahedronFaceDownWithMidradius(DodecahedronIcosahedronMidradius),
					Scene.DodecahedronVertexDownWithMidradius(DodecahedronIcosahedronMidradius)),
			["icosahedron-vertex-down"] =
				Scene.IcosahedronVertexDownWithCircumradius(Constants.Circumradius),
			["octahedron-face-down"] =
				Scene.OctahedronFaceDownWithCircumradius(Constants.Circumradius),
			["octahedron-face-down-cube-vertex-down-union"] =
				Scene.Union(
					Scene.OctahedronFaceDownWithMidradius(CubeOctahedronMidradius),
					Scene.CubeVertexDownWithMidradius(CubeOctahedronMidradius)),
			["octahedron-vertex-down"] =
				Scene.OctahedronVertexDownWithCircumradius(Constants.Circumradius),
			["plane-horizontal-bounded"] =
				Scene.Intersection(
					Scene.PlaneThroughOrigin(Vector3.UnitZ),
					BoundingSphere),
			["sphere"] =
				Scene.SphereWithRadius(Constants.Circumradius),
			["sphere-cone-inverted-intersection"] =
				Scene.Intersection(
					SphereAlmostTouchingCubeEdge,
					Scene.Cone(Vector3.UnitZ, float.Pi / 2F).Inverted()),
			["sphere-cube-face-down-inverted-intersection"] =
				Scene.Intersection(
					SphereAlmostTouchingCubeEdge,
					Scene.CubeFaceDownWithCircumradius(Constants.Circumradius)),
			["sphere-painted-hsv"] =
				Scene.SphereWithRadius(1F)
					.Painted(new ColorHsv(0.1F, 0.9F, 1F)),
			["sphere-painted-hsv-cartesian"] =
				Scene.SphereWithRadius(1F)
					.Painted(point =>
						new ColorHsv(
							(2F * point.X).Modulo(1F),
							(1F - point.Z) / 2F,
							1F)),
			["sphere-painted-hsv-spherical"] =
				Scene.SphereWithRadius(1F)
					.Painted(point =>
						new ColorHsv(
							(2F * point.Phi / float.Pi).Modulo(1F),
							point.Theta / float.Pi,
							1F)),
			["sphere-painted-rgb"] =
				Scene.SphereWithRadius(1F)
					.Painted(Color.Red),
			["sphere-painted-rgb-cartesian"] =
				Scene.SphereWithRadius(1F)
					.Painted(point =>
						new Color(
							float.Abs(point.X),
							float.Abs(point.Y),
							float.Abs(point.Z))),
			["sphere-painted-rgb-spherical"] =
				Scene.SphereWithRadius(1F)
					.Painted(point =>
						new Color(
							(1F + float.Cos(16F * point.Phi)) / 2F,
							0F,
							(1F + float.Cos(16F * point.Theta)) / 2F)),
			["tetrahedron-face-down"] =
				Scene.TetrahedronFaceDownWithCircumradius(Constants.Circumradius),
			["tetrahedron-union"] =
				Scene.Union(
					Scene.TetrahedronFaceDownWithMidradius(TetrahedronMidradius),
					Scene.TetrahedronVertexDownWithMidradius(TetrahedronMidradius)),
			["tetrahedron-vertex-down"] =
				Scene.TetrahedronVertexDownWithCircumradius(Constants.Circumradius),
		};

	[ExcludeFromCodeCoverage]
	public static TheoryData<string> Names =>
		[.. Scenes.Keys];

	[Theory]
	[MemberData(nameof(Names))]
	public void ProjectorImage(string name)
	{
		var scene = Scenes[name];
		var inputFile = $"{Constants.InputDirectory}/{name}.png";

		var projection = Projector.Project(scene, ProjectorSettings);
		var image = Sampler.Sample(projection, ImageSettings);
		var outputFile = Saver.Save(image, name);

		outputFile.ShouldHaveSameContentAs(inputFile);
	}
}
