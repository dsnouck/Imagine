namespace Imagine.Tests;

// TODO: Use new() everywhere.
// TODO: Rename variables named settings to samplerSettings.
// TODO: Create ProjectorSettings constructor with default BackgroundColor.
public class ProjectorTests
{
	private const double Narrow = 0.01D;
	private static readonly double SphereRadius = double.Sqrt(2D / 3D) - Narrow;

	private static readonly ProjectorSettings ProjectorSettings =
		new(
			Eye: new Vector3Spherical(3D, Math.PI / 3D, Math.PI / 6D),
			Focus: new(0D, 0D, 0D),
			FieldOfView: Math.PI / 4D,
			BackgroundColor: new(0D, 0D, 0D));

	private static readonly ImageSettings ImageSettings =
		new(
			Width: 512,
			Height: 512,
			Subsamples: 2,
			XMin: -1D,
			XMax: 1D,
			YMin: -1,
			YMax: 1D);

	private static readonly Dictionary<string, IScene> Scenes =
		new()
		{
			{ "cone", Scene.Intersection(Scene.Cone(), Scene.Sphere().Transparent()) },
			{ "cube-except-sphere", Scene.Cube().Except(Scene.SphereWithRadius(SphereRadius)) },
			{ "cube-rotated", Scene.Cube().Rotated(Math.PI / 4D) },
			{ "cube-scaled", Scene.Cube().Scaled(0.5D) },
			{ "cube-sphere-intersection", Scene.Cube().IntersectedWith(Scene.SphereWithRadius(SphereRadius)) },
			{ "cube-sphere-union", Scene.Cube().UnitedWith(Scene.SphereWithRadius(SphereRadius)) },
			{ "cube-translated", Scene.Cube().Translated(new Vector3(0D, 0.25D, 0D)) },
			{ "cube", Scene.Cube() },
			{ "cylinder", Scene.Intersection(Scene.CylinderWithRadius(0.5D), Scene.Sphere().Transparent()) },
			{ "dodecahedron", Scene.Dodecahedron() },
			{ "icosahedron", Scene.Icosahedron() },
			{ "octahedron", Scene.Octahedron() },
			{ "plane", Scene.Intersection(Scene.PlaneThroughOrigin(new(0D, 0D, 1D)), Scene.Sphere().Transparent()) },
			{ "red-cube", Scene.Cube().Painted(new ColorRgb(1D, 0D, 0D)) },
			{ "sphere-except-cube", Scene.SphereWithRadius(SphereRadius).Except(Scene.Cube()) },
			{ "sphere", Scene.SphereWithRadius(SphereRadius) },
			{ "tetrahedron", Scene.Tetrahedron().Rotated(11D * Math.PI / 24D) },
		};

	public static TheoryData<string> Names =>
		new(Scenes.Keys.ToList());

	[Theory]
	[MemberData(nameof(Names))]
	public void SceneIsRendered(string name)
	{
		var scene = Scenes[name];
		var projection = Projector.Project(scene, ProjectorSettings);
		var image = Sampler.Sample(projection, ImageSettings);
		var file = Saver.Save(image, name);

		File.Exists(file).Should().BeTrue();
	}
}
