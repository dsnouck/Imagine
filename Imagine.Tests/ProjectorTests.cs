namespace Imagine.Tests;

public class ProjectorTests
{
	private const string InputDirectory = "input";
	private const double Narrow = 0.01D;
	private static readonly double SphereRadius = double.Sqrt(2D / 3D) - Narrow;

	private static readonly ProjectorSettings ProjectorSettings =
		new(
			eye: (Vector3)new Vector3Spherical(3D, double.Pi / 6D, double.Pi / 3D),
			focus: new(0D, 0D, 0D),
			fieldOfView: double.Pi / 4D);

	private static readonly ImageSettings ImageSettings =
		new(
			width: 512,
			height: 512,
			subsamples: 2);

	private static readonly IScene BoundingSphere = Scene.Sphere().Transparent();
	private static readonly IScene Cylinder = Scene.Cylinder(new(0D, 0D, 1D), 0.5D);
	private static readonly IScene Sphere = Scene.SphereWithRadius(SphereRadius);

	private static readonly Dictionary<string, IScene> Scenes =
		new()
		{
			{
				"cone",
				Scene.Intersection(Scene.Cone(new(0D, 0D, 1D), double.Pi / 2D), BoundingSphere)
			},
			{
				"cone-union",
				Scene.Union(
					Scene.Cone(new(1D, 0D, 0D), double.Pi / 16D).Painted(new(1D, 0D, 0D)),
					Scene.Cone(new(0D, 1D, 0D), double.Pi / 16D).Painted(new(0D, 1D, 0D)),
					Scene.Cone(new(0D, 0D, 1D), double.Pi / 16D).Painted(new(0D, 0D, 1D)))
			},
			{
				 "cube-except-sphere",
				 Scene.CubeFaceDownWithCircumradius(1D).Except(Sphere)
			},
			{
				"cube-octahedron-union",
				Scene.Union(
					Scene.CubeFaceDownWithMidradius(1D / double.Sqrt(2D)),
					Scene.OctahedronVertexDownWithMidradius(1D / double.Sqrt(2D)))
			},
			{
				 "cube-painted",
				 Scene.CubeFaceDownWithCircumradius(1D).Painted(new(1D, 0D, 0D))
			},
			{
				"cube-rotated",
				Scene.CubeFaceDownWithCircumradius(1D).Rotated(double.Pi / 4D)
			},
			{
				"cube-scaled",
				Scene.CubeFaceDownWithCircumradius(1D).Scaled(0.5D)
			},
			{
				"cube-sphere-intersection",
				Scene.CubeFaceDownWithCircumradius(1D).IntersectedWith(Sphere)
			},
			{
				"cube-sphere-union",
				Scene.CubeFaceDownWithCircumradius(1D).UnitedWith(Sphere)
			},
			{
				"cube-translated",
				Scene.CubeFaceDownWithCircumradius(1D).Translated(new(0D, 0.25D, 0D))
			},
			{
				"cube",
				Scene.CubeFaceDownWithCircumradius(1D)
			},
			{
				"cylinder",
				Scene.Intersection(Cylinder, BoundingSphere)
			},
			{
				"cylinder-intersection",
				Scene.Intersection(
					Scene.Cylinder(new(1D, 0D, 0D), 0.5D).Painted(new(1D, 0D, 0D)),
					Scene.Cylinder(new(0D, 1D, 0D), 0.5D).Painted(new(0D, 1D, 0D)),
					Scene.Cylinder(new(0D, 0D, 1D), 0.5D).Painted(new(0D, 0D, 1D)))
			},
			{
				"cylinder-union",
				Scene.Union(
					Scene.Cylinder(new(1D, 0D, 0D), 0.25D).Painted(new(1D, 0D, 0D)),
					Scene.Cylinder(new(0D, 1D, 0D), 0.25D).Painted(new(0D, 1D, 0D)),
					Scene.Cylinder(new(0D, 0D, 1D), 0.25D).Painted(new(0D, 0D, 1D)))
			},
			{
				"dodecahedron",
				Scene.Dodecahedron()
			},
			{
				"icosahedron",
				Scene.Icosahedron()
			},
			{
				"octahedron",
				Scene.OctahedronFaceDownWithCircumradius(1D)
			},
			{
				"octahedron-cube-union",
				Scene.Union(
					Scene.OctahedronFaceDownWithMidradius(1D / double.Sqrt(2D)),
					Scene.CubeVertexDownWithMidradius(1D / double.Sqrt(2D)))
			},
			{
				"plane",
				Scene.Intersection(Scene.PlaneThroughOrigin(new(0D, 0D, 1D)), BoundingSphere)
			},
			{
				"sphere-except-cone",
				Sphere.Except(Scene.Cone(new(0D, 0D, 1D), double.Pi / 2D))
			},
			{
				"sphere-except-cube",
				Sphere.Except(Scene.CubeFaceDownWithCircumradius(1D))
			},
			{
				"sphere",
				Sphere
			},
			{
				"tetrahedron",
				Scene.TetrahedronFaceDownWithCircumradius(1D)
			},
			{
				"tetrahedron-union",
				Scene.Union(
					Scene.TetrahedronFaceDownWithCircumradius(1D),
					Scene.TetrahedronVertexDownWithCircumradius(1D))
			},
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
