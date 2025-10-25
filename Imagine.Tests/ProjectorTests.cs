namespace Imagine.Tests;

public class ProjectorTests
{
	// TODO: Clean up fields.
	private readonly IColorComponent colorComponent;
	private readonly IFileComponent fileComponent;
	private readonly ILine2Component line2Component;
	private readonly ISamplerComponent samplerComponent;
	private readonly IVector2Component vector2Component;
	private readonly IVector3Component vector3Component;
	private readonly IFuncDoubleDoubleComponent funcDoubleDoubleComponent;
	private readonly ILine3Component line3Component;
	private readonly IProjectorComponent projectorComponent;

	private readonly IFuncVector2Vector3Component funcVector2Vector3Component;

	public ProjectorTests()
	{
		colorComponent = new ColorComponent();
		fileComponent = new FileComponent(colorComponent);
		line2Component = new Line2Component();
		samplerComponent = new SamplerComponent(colorComponent, line2Component);
		vector2Component = new Vector2Component();
		vector3Component = new Vector3Component();
		funcDoubleDoubleComponent = new FuncDoubleDoubleComponent();
		line3Component = new Line3Component(vector3Component);
		funcVector2Vector3Component = new FuncVector2Vector3Component(vector3Component);
		projectorComponent = new ProjectorComponent(colorComponent, vector3Component, funcVector2Vector3Component);
	}

	[Fact]
	public void Sphere()
	{
		const string name = "sphere";

		var scene = new Sphere(vector3Component, funcDoubleDoubleComponent, line3Component);

		// TODO: Find nice settings for all tests.
		var projectorSettings = new ProjectorSettings(
			Eye: new(2D, 3D, 4D),
			Focus: new(0D, 0D, 0D),
			FieldOfView: Math.PI / 4D,
			// TODO: Use new() everywhere.
			BackgroundColor: new RgbColor(0D, 0D, 0D));

		// TODO: Find nice settings for all tests.
		// TODO: Rename variables named settings to samplerSettings.
		var settings = new ImageSettings(
			Width: 512,
			Height: 512,
			Subsamples: 2,
			XMin: -1D,
			XMax: 1D,
			YMin: -1,
			YMax: 1D);

		var projection = projectorComponent.Project(scene, projectorSettings);
		var image = samplerComponent.Sample(projection, settings);
		fileComponent.Save(image, name);
	}

	// TODO: Reorder methods alphabetically?
	[Fact]
	public void Cube()
	{
		const string name = "cube";

		var scene = CreateCubeComponent();

		// TODO: Find nice settings for all tests.
		var projectorSettings = new ProjectorSettings(
			Eye: new(2D, 3D, 4D),
			Focus: new(0D, 0D, 0D),
			FieldOfView: Math.PI / 4D,
			// TODO: Use new() everywhere.
			BackgroundColor: new RgbColor(0D, 0D, 0D));

		// TODO: Find nice settings for all tests.
		// TODO: Rename variables named settings to samplerSettings.
		var settings = new ImageSettings(
			Width: 512,
			Height: 512,
			Subsamples: 2,
			XMin: -1D,
			XMax: 1D,
			YMin: -1,
			YMax: 1D);

		var projection = projectorComponent.Project(scene, projectorSettings);
		var image = samplerComponent.Sample(projection, settings);
		fileComponent.Save(image, name);
	}

	// TODO: Move to static class Scene.
	private ISceneComponent CreateCubeComponent()
	{
		var planes = new List<ISceneComponent>
		{
			new Plane(new Vector3(0D, 0D, -1D), vector3Component),
			new Plane(new Vector3(1D, 0D, 0D), vector3Component),
			new Plane(new Vector3(0D, 1D, 0D), vector3Component),
			new Plane(new Vector3(-1D, 0D, 0D), vector3Component),
			new Plane(new Vector3(0D, -1D, 0D), vector3Component),
			new Plane(new Vector3(0D, 0D, 1D), vector3Component),
		};

		return CreateIntersectionComponent(planes);
	}

	private ISceneComponent CreateIntersectionComponent(List<ISceneComponent> scenes) =>
		scenes.Aggregate(
			(ISceneComponent)new Full(),
			(scene, otherScene) =>
				new Intersection(
					scene,
					otherScene,
					line3Component));
}
