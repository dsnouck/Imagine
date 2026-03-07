namespace Imagine.Tests;

// TODO: Find nice settings for all tests.
// TODO: Use new() everywhere.
// TODO: Rename variables named settings to samplerSettings.
// TODO: Create ProjectorSettings constructor with default BackgroundColor.
// TODO: Assert rendered images are correct (e.g. by comparing to reference images).
public class ProjectorTests
{
	private readonly ProjectorSettings projectorSettings = new(
		Eye: new(2D, 3D, 4D),
		Focus: new(0D, 0D, 0D),
		FieldOfView: Math.PI / 4D,
		BackgroundColor: new(0D, 0D, 0D));

	private readonly ImageSettings imageSettings = new(
		Width: 512,
		Height: 512,
		Subsamples: 2,
		XMin: -1D,
		XMax: 1D,
		YMin: -1,
		YMax: 1D);

	public static TheoryData<string, IScene> Scenes() =>
		new()
		{
			{ "cone", Scene.Intersection(Scene.Cone(), Scene.Plane(new(0D, 0D, -1D)), Scene.Plane(new(0D, 0D, 1D))) },
			{ "cube", Scene.Cube() },
			{ "cube-except-sphere", Scene.Cube().Except(Scene.Sphere().Scaled(double.Sqrt(2D) - 0.1D)) },
			{ "cube-sphere-intersection", Scene.Cube().IntersectedWith(Scene.Sphere().Scaled(double.Sqrt(2D) - 0.1D)) },
			{ "cube-sphere-union", Scene.Cube().UnitedWith(Scene.Sphere().Scaled(double.Sqrt(2D) - 0.1D)) },
			{ "cylinder", Scene.Intersection(Scene.Cylinder(), Scene.Plane(new(0D, 0D, -1D)), Scene.Plane(new(0D, 0D, 1D))) },
			{ "dodecahedron", Scene.Dodecahedron() },
			{ "icosahedron", Scene.Icosahedron() },
			{ "octahedron", Scene.Octahedron() },
			{ "red-cube", Scene.Cube().Painted(new ColorRgb(1D, 0D, 0D)) },
			{ "plane", Scene.Intersection(Scene.Plane(new Vector3(0D, 0D, -1D)), Scene.Plane(new Vector3(1D, 0D, 0D)).Transparent(), Scene.Plane(new Vector3(0D, 1D, 0D)).Transparent(), Scene.Plane(new Vector3(-1D, 0D, 0D)).Transparent(), Scene.Plane(new Vector3(0D, -1D, 0D)).Transparent()) },
			{ "rotated-cube", Scene.Cube().Rotated(Math.PI / 4D) },
			{ "scaled-cube", Scene.Cube().Scaled(0.5D) },
			{ "sphere", Scene.Sphere() },
			{ "sphere-except-cube", Scene.Sphere().Scaled(double.Sqrt(2D) - 0.1D).Except(Scene.Cube()) },
			{ "tetrahedron", Scene.Tetrahedron() },
			{ "translated-cube", Scene.Cube().Translated(new Vector3(0D, 0.5D, 0D)) },
		};

	[Theory]
	[MemberData(nameof(Scenes))]
	public void SceneIsRendered(string name, IScene scene)
	{
		var projection = Projector.Project(scene, projectorSettings);
		var image = Sampler.Sample(projection, imageSettings);
		var file = Saver.Save(image, name);

		File.Exists(file).Should().BeTrue();
	}
}
