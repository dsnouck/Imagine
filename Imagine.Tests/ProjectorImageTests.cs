namespace Imagine.Tests;

public class ProjectorImageTests
{
	private const double Narrow = 0.01D;

	private static readonly double CubeOctahedronMidradius =
		Constants.Circumradius * double.Min(
			Scene.CubeMidradius / Scene.CubeCircumradius,
			Scene.OctahedronMidradius / Scene.OctahedronCircumradius);

	private static readonly double DodecahedronIcosahedronMidradius =
		Constants.Circumradius * double.Min(
			Scene.DodecahedronMidradius / Scene.DodecahedronCircumradius,
			Scene.IcosahedronMidradius / Scene.IcosahedronCircumradius);

	private static readonly double SphereAlmostTouchingCubeEdgeRadius =
		(Constants.Circumradius * Scene.CubeMidradius / Scene.CubeCircumradius) - Narrow;

	private static readonly double TetrahedronMidradius =
		Constants.Circumradius * Scene.TetrahedronMidradius / Scene.TetrahedronCircumradius;

	private static readonly ProjectorSettings ProjectorSettings =
		ProjectorSettings.WithOpeningRadius(
			eye: (Vector3)new Vector3Spherical(10D, double.Pi / 6D, double.Pi / 3D),
			focus: Vector3.Zero,
			openingRadius: Constants.Circumradius * 5D / 4D);

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
					Scene.Cone(Vector3.UnitZ, double.Pi / 2D),
					BoundingSphere),
			["cone-union"] =
				Scene.Union(
					Scene.Cone(Vector3.UnitX, double.Pi / 16D).Painted(Color.Red),
					Scene.Cone(Vector3.UnitY, double.Pi / 16D).Painted(Color.Green),
					Scene.Cone(Vector3.UnitZ, double.Pi / 16D).Painted(Color.Blue)),
			["cube-face-down"] =
				Scene.CubeFaceDownWithCircumradius(Constants.Circumradius),
			["cube-face-down-octahedron-vertex-down-union"] =
				Scene.Union(
					Scene.CubeFaceDownWithMidradius(CubeOctahedronMidradius),
					Scene.OctahedronVertexDownWithMidradius(CubeOctahedronMidradius)),
			["cube-face-down-rotated"] =
				Scene.CubeFaceDownWithCircumradius(Constants.Circumradius)
					.Rotated(double.Pi / 4D),
			["cube-face-down-scaled"] =
				Scene.CubeFaceDownWithCircumradius(Constants.Circumradius)
					.Scaled(Constants.Circumradius / 2D),
			["cube-face-down-sphere-intersection"] =
				Scene.Intersection(
					Scene.CubeFaceDownWithCircumradius(Constants.Circumradius),
					Scene.SphereWithRadius(1D).
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
					.Translated(new(0D, Constants.Circumradius / 4D, 0D)),
			["cube-vertex-down"] =
				Scene.CubeVertexDownWithCircumradius(Constants.Circumradius),
			["cylinder-bounded"] =
				Scene.Intersection(
					Scene.Cylinder(Vector3.UnitZ, Constants.Circumradius / 2D),
					BoundingSphere),
			["cylinder-intersection"] =
				Scene.Intersection(
					Scene.Cylinder(Vector3.UnitX, Constants.Circumradius / 2D).Painted(Color.Red),
					Scene.Cylinder(Vector3.UnitY, Constants.Circumradius / 2D).Painted(Color.Green),
					Scene.Cylinder(Vector3.UnitZ, Constants.Circumradius / 2D).Painted(Color.Blue)),
			["cylinder-union"] =
				Scene.Union(
					Scene.Cylinder(Vector3.UnitX, Constants.Circumradius / 4D).Painted(Color.Red),
					Scene.Cylinder(Vector3.UnitY, Constants.Circumradius / 4D).Painted(Color.Green),
					Scene.Cylinder(Vector3.UnitZ, Constants.Circumradius / 4D).Painted(Color.Blue)),
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
					Scene.Cone(Vector3.UnitZ, double.Pi / 2D).Inverted()),
			["sphere-cube-face-down-inverted-intersection"] =
				Scene.Intersection(
					SphereAlmostTouchingCubeEdge,
					Scene.CubeFaceDownWithCircumradius(Constants.Circumradius)),
			["sphere-painted-hsv"] =
				Scene.SphereWithRadius(1D)
					.Painted(new ColorHsv(0.1D, 0.9D, 1D)),
			["sphere-painted-hsv-cartesian"] =
				Scene.SphereWithRadius(1D)
					.Painted(point =>
						new ColorHsv(
							(2D * point.X).Modulo(1D),
							(1D - point.Z) / 2D,
							1D)),
			["sphere-painted-hsv-spherical"] =
				Scene.SphereWithRadius(1D)
					.Painted(point =>
						new ColorHsv(
							(2D * point.Phi / double.Pi).Modulo(1D),
							point.Theta / double.Pi,
							1D)),
			["sphere-painted-rgb"] =
				Scene.SphereWithRadius(1D)
					.Painted(Color.Red),
			["sphere-painted-rgb-cartesian"] =
				Scene.SphereWithRadius(1D)
					.Painted(point =>
						new Color(
							double.Abs(point.X),
							double.Abs(point.Y),
							double.Abs(point.Z))),
			["sphere-painted-rgb-spherical"] =
				Scene.SphereWithRadius(1D)
					.Painted(point =>
						new Color(
							(1D + double.Cos(16D * point.Phi)) / 2D,
							0D,
							(1D + double.Cos(16D * point.Theta)) / 2D)),
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
