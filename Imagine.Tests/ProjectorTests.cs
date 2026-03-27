namespace Imagine.Tests;

public class ProjectorTests
{
	private const string InputDirectory = "input";
	private const double Narrow = 0.01D;
	private static readonly double SphereRadius = double.Sqrt(2D / 3D) - Narrow;

	private static readonly ProjectorSettings ProjectorSettings =
		new(
			eye: (Vector3)new Vector3Spherical(3D, Math.PI / 6D, Math.PI / 3D),
			focus: new(0D, 0D, 0D),
			fieldOfView: Math.PI / 4D);

	private static readonly ImageSettings ImageSettings =
		new(
			width: 512,
			height: 512,
			subsamples: 2);

	private static readonly IScene BoundingSphere = Scene.Sphere().Transparent();
	private static readonly IScene Cylinder = Scene.CylinderWithRadius(0.5D);
	private static readonly IScene Sphere = Scene.SphereWithRadius(SphereRadius);
	private static readonly IScene Tetrahedron = Scene.Tetrahedron().Rotated(11D * Math.PI / 24D);

	private static readonly Dictionary<string, IScene> Scenes =
		new()
		{
			{
				"cone",
				Scene.Intersection(Scene.Cone(), BoundingSphere)
			},
			{
				 "cube-except-sphere",
				 Scene.Cube().Except(Sphere)
			},
			{
				 "cube-painted",
				 Scene.Cube().Painted(new(1D, 0D, 0D))
			},
			{
				"cube-rotated",
				Scene.Cube().Rotated(Math.PI / 4D)
			},
			{
				"cube-scaled",
				Scene.Cube().Scaled(0.5D)
			},
			{
				"cube-sphere-intersection",
				Scene.Cube().IntersectedWith(Sphere)
			},
			{
				"cube-sphere-union",
				Scene.Cube().UnitedWith(Sphere)
			},
			{
				"cube-translated",
				Scene.Cube().Translated(new(0D, 0.25D, 0D))
			},
			{
				"cube",
				Scene.Cube()
			},
			{
				"cylinder",
				Scene.Intersection(Cylinder, BoundingSphere)
			},
			{
				"cylinder-intersection",
				Scene.Intersection(
					Scene.Cylinder().Rotated(new(0D, 1D, 0D), Math.PI / 2D).Painted(new(1D, 0D, 0D)),
					Scene.Cylinder().Rotated(new(1D, 0D, 0D), Math.PI / 2D).Painted(new(0D, 1D, 0D)),
					Scene.Cylinder().Painted(new(0D, 0D, 1D)))
					.Scaled(0.5D)
			},
			{
				"cylinder-union",
				Scene.Union(
					Scene.Cylinder().Rotated(new(0D, 1D, 0D), Math.PI / 2D).Painted(new(1D, 0D, 0D)),
					Scene.Cylinder().Rotated(new(1D, 0D, 0D), Math.PI / 2D).Painted(new(0D, 1D, 0D)),
					Scene.Cylinder().Painted(new(0D, 0D, 1D)))
					.Scaled(0.5D)
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
				Scene.Octahedron()
			},
			{
				"plane",
				Scene.Intersection(Scene.PlaneThroughOrigin(new(0D, 0D, 1D)), BoundingSphere)
			},
			{
				"sphere-except-cone",
				Sphere.Except(Scene.Cone())
			},
			{
				"sphere-except-cube",
				Sphere.Except(Scene.Cube())
			},
			{
				"sphere",
				Sphere
			},
			{
				"tetrahedron",
				Tetrahedron
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
