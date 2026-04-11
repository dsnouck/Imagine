namespace Imagine.Tests;

public class ProjectorTests
{
	private const string InputDirectory = "input";
	private const double Circumradius = 1D;
	private const double Narrow = 0.01D;
	private static readonly double SphereRadius = (Circumradius * Scene.CubeMidradius / Scene.CubeCircumradius) - Narrow;

	private static readonly ProjectorSettings ProjectorSettings =
		new(
			eye: (Vector3)new Vector3Spherical(3D, double.Pi / 6D, double.Pi / 3D),
			focus: Vector3.Zero,
			fieldOfView: double.Pi / 4D);

	private static readonly ImageSettings ImageSettings =
		new(
			width: 512,
			height: 512,
			subsamples: 2);

	private static readonly IScene BoundingSphere = Scene.SphereWithRadius(Circumradius).Transparent();
	private static readonly IScene Sphere = Scene.SphereWithRadius(SphereRadius);

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
				Scene.CubeFaceDownWithCircumradius(Circumradius),
			["cube-face-down-octahedron-vertex-down-union"] =
				Scene.Union(
					Scene.CubeFaceDownWithMidradius(Circumradius * Scene.OctahedronMidradius / Scene.OctahedronCircumradius),
					Scene.OctahedronVertexDownWithCircumradius(Circumradius)),
			["cube-face-down-painted"] =
				Scene.CubeFaceDownWithCircumradius(Circumradius)
					.Painted(Color.Red),
			["cube-face-down-rotated"] =
				Scene.CubeFaceDownWithCircumradius(Circumradius)
					.Rotated(double.Pi / 4D),
			["cube-face-down-scaled"] =
				Scene.CubeFaceDownWithCircumradius(Circumradius)
					.Scaled(Circumradius / 2D),
			["cube-face-down-sphere-intersection"] =
				Scene.Intersection(
					Scene.CubeFaceDownWithCircumradius(Circumradius),
					Sphere),
			["cube-face-down-sphere-inverted-union"] =
				Scene.Intersection(
					Scene.CubeFaceDownWithCircumradius(Circumradius),
					Sphere.Inverted()),
			["cube-face-down-sphere-union"] =
				Scene.Union(
					Scene.CubeFaceDownWithCircumradius(Circumradius),
					Sphere),
			["cube-face-down-translated"] =
				Scene.CubeFaceDownWithCircumradius(Circumradius)
					.Translated(new(0D, Circumradius / 4D, 0D)),
			["cube-vertex-down"] =
				Scene.CubeVertexDownWithCircumradius(Circumradius),
			["cylinder-bounded"] =
				Scene.Intersection(
					Scene.Cylinder(Vector3.UnitZ, Circumradius / 2D),
					BoundingSphere),
			["cylinder-intersection"] =
				Scene.Intersection(
					Scene.Cylinder(Vector3.UnitX, Circumradius / 2D).Painted(Color.Red),
					Scene.Cylinder(Vector3.UnitY, Circumradius / 2D).Painted(Color.Green),
					Scene.Cylinder(Vector3.UnitZ, Circumradius / 2D).Painted(Color.Blue)),
			["cylinder-union"] =
				Scene.Union(
					Scene.Cylinder(Vector3.UnitX, Circumradius / 4D).Painted(Color.Red),
					Scene.Cylinder(Vector3.UnitY, Circumradius / 4D).Painted(Color.Green),
					Scene.Cylinder(Vector3.UnitZ, Circumradius / 4D).Painted(Color.Blue)),
			["dodecahedron-face-down"] =
				Scene.DodecahedronFaceDownWithCircumradius(Circumradius),
			["dodecahedron-face-down-icosahedron-vertex-down-union"] =
				Scene.Union(
					Scene.DodecahedronFaceDownWithMidradius(Circumradius * Scene.IcosahedronMidradius / Scene.IcosahedronCircumradius),
					Scene.IcosahedronVertexDownWithCircumradius(Circumradius)),
			["dodecahedron-vertex-down"] =
				Scene.DodecahedronVertexDownWithCircumradius(Circumradius),
			["icosahedron-face-down"] =
				Scene.IcosahedronFaceDownWithCircumradius(Circumradius),
			["icosahedron-face-down-dodecahedron-vertex-down-union"] =
				Scene.Union(
					Scene.IcosahedronFaceDownWithCircumradius(Circumradius),
					Scene.DodecahedronVertexDownWithMidradius(Circumradius * Scene.IcosahedronMidradius / Scene.IcosahedronCircumradius)),
			["icosahedron-vertex-down"] =
				Scene.IcosahedronVertexDownWithCircumradius(Circumradius),
			["octahedron-face-down"] =
				Scene.OctahedronFaceDownWithCircumradius(Circumradius),
			["octahedron-face-down-cube-vertex-down-union"] =
				Scene.Union(
					Scene.OctahedronFaceDownWithCircumradius(Circumradius),
					Scene.CubeVertexDownWithMidradius(Circumradius * Scene.OctahedronMidradius / Scene.OctahedronCircumradius)),
			["octahedron-vertex-down"] =
				Scene.OctahedronVertexDownWithCircumradius(Circumradius),
			["plane-horizontal-bounded"] =
				Scene.Intersection(
					Scene.PlaneThroughOrigin(Vector3.UnitZ),
					BoundingSphere),
			["sphere"] =
				Sphere,
			["sphere-cone-inverted-intersection"] =
				Scene.Intersection(
					Sphere,
					Scene.Cone(Vector3.UnitZ, double.Pi / 2D).Inverted()),
			["sphere-cube-face-down-inverted-intersection"] =
				Scene.Intersection(
					Sphere,
					Scene.CubeFaceDownWithCircumradius(Circumradius)),
			["tetrahedron-face-down"] =
				Scene.TetrahedronFaceDownWithCircumradius(Circumradius),
			["tetrahedron-union"] =
				Scene.Union(
					Scene.TetrahedronFaceDownWithCircumradius(Circumradius),
					Scene.TetrahedronVertexDownWithCircumradius(Circumradius)),
			["tetrahedron-vertex-down"] =
				Scene.TetrahedronVertexDownWithCircumradius(Circumradius),
		};

	[ExcludeFromCodeCoverage]
	public static TheoryData<string> Names =>
		[.. Scenes.Keys.ToList()];

	[Theory]
	[MemberData(nameof(Names))]
	public void Projection(string name)
	{
		var scene = Scenes[name];
		var inputFile = $"{InputDirectory}/{name}.png";

		var projection = Projector.Project(scene, ProjectorSettings);
		var image = Sampler.Sample(projection, ImageSettings);
		var outputFile = Saver.Save(image, name);

		outputFile.ShouldHaveSameContentAs(inputFile);
	}
}
