namespace Imagine.Tests;

public class ProjectorTests
{
	// TODO: Upgrade to .NET 10.
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
	private readonly IMatrix4Component matrix4Component = new Matrix4Component(new Vector3Component(), new Vector4Component());

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
	public void Cone()
	{
		const string name = "cone";

		var scene = CreateConeComponent();

		// TODO: Find nice settings for all tests.
		var projectorSettings = new ProjectorSettings(
			Eye: new(2D, 3D, 2D),
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
	public void Cylinder()
	{
		const string name = "cylinder";

		var scene = CreateCylinderComponent();

		// TODO: Find nice settings for all tests.
		var projectorSettings = new ProjectorSettings(
			Eye: new(2D, 3D, 2D),
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

		// TODO: Assert saved file is correct.
		var projection = projectorComponent.Project(scene, projectorSettings);
		var image = samplerComponent.Sample(projection, settings);
		fileComponent.Save(image, name);
	}

	[Fact]
	public void Tetrahedron()
	{
		const string name = "tetrahedron";

		var scene = CreateTetrahedronComponent();

		// TODO: Find nice settings for all tests.
		var projectorSettings = new ProjectorSettings(
			Eye: new(3D, 4D, 12D),
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

	// TODO: Reorder methods alphabetically?
	[Fact]
	public void Plane()
	{
		const string name = "plane";

		var scene = CreatePlaneComponent();

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
	public void CubeExceptSphere()
	{
		const string name = "cube-except-sphere";

		var scene = CreateCubeExceptSphereComponent();

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
	public void SphereExceptCube()
	{
		const string name = "sphere-except-cube";

		var scene = CreateSphereExceptCubeComponent();
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
	public void CubeSphereIntersection()
	{
		const string name = "cube-sphere-intersection";

		var scene = CreateCubeSphereIntersection();

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
	public void CubeSphereUnion()
	{
		const string name = "cube-sphere-union";

		var scene = CreateCubeSphereUnion();

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
	public void RotatedCube()
	{
		const string name = "rotated-cube";

		var scene = CreateRotatedComponent(CreateCubeComponent(), new Vector3(0D, 0D, 1D), Math.PI / 4D);

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
	public void ScaledCube()
	{
		const string name = "scaled-cube";

		var scene = CreateScaledComponent(CreateCubeComponent(), 0.5D);

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
	public void TranslatedCube()
	{
		const string name = "translated-cube";

		var scene = CreateTranslatedComponent(CreateCubeComponent(), new Vector3(0D, 0.5D, 0D));

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

	[Fact]
	public void Octahedron()
	{
		const string name = "octahdedron";

		var scene = CreateOctahedronComponent();

		// TODO: Find nice settings for all tests.
		var projectorSettings = new ProjectorSettings(
			Eye: new(4D, 4D, 4D),
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

	[Fact]
	public void Dodecahedron()
	{
		const string name = "dodecahedron";

		var scene = CreateDodecahedronComponent();

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

	[Fact]
	public void Icosahedron()
	{
		const string name = "icosahedron";

		var scene = CreateIcosahedronComponent();

		// TODO: Find nice settings for all tests.
		var projectorSettings = new ProjectorSettings(
			Eye: new(4D, 4D, 4D),
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
	public void Painted()
	{
		const string name = "red-cube";

		var scene = new Painted(CreateCubeComponent(), new RgbColor(1D, 0D, 0D));

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
	private ISceneComponent CreateTetrahedronComponent()
	{
		var dihedralAngle = Math.Acos(1D / 3D);
		var azimuthStep = 2D * Math.PI / 3D;

		var planes = new List<ISceneComponent>
		{
			new Plane(vector3Component.CreateVector3FromSphericalCoordinates(1D, Math.PI, 0D), vector3Component),
			new Plane(vector3Component.CreateVector3FromSphericalCoordinates(1D, dihedralAngle, 0D * azimuthStep), vector3Component),
			new Plane(vector3Component.CreateVector3FromSphericalCoordinates(1D, dihedralAngle, 1D * azimuthStep), vector3Component),
			new Plane(vector3Component.CreateVector3FromSphericalCoordinates(1D, dihedralAngle, 2D * azimuthStep), vector3Component),
		};

		return CreateIntersectionComponent(planes);
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

	// TODO: Move to static class Scene.
	private ISceneComponent CreatePlaneComponent()
	{
		var planes = new List<ISceneComponent>
		{
			new Plane(new Vector3(0D, 0D, -1D), vector3Component),
			new Transparent(new Plane(new Vector3(1D, 0D, 0D), vector3Component)),
			new Transparent(new Plane(new Vector3(0D, 1D, 0D), vector3Component)),
			new Transparent(new Plane(new Vector3(-1D, 0D, 0D), vector3Component)),
			new Transparent(new Plane(new Vector3(0D, -1D, 0D), vector3Component)),
		};

		return CreateIntersectionComponent(planes);
	}

	// TODO: Move to static class Scene.
	private ISceneComponent CreateCubeExceptSphereComponent()
	{
		// TODO: Are these colors and sizes good?
		var sphere = CreateScaledComponent(new Sphere(vector3Component, funcDoubleDoubleComponent, line3Component), Math.Sqrt(2D) * 0.99D);

		var planes = new List<ISceneComponent>
		{
			new Painted(CreateCubeComponent(), new RgbColor(1D, 0D, 0D)),
			new Painted(new Inverted(vector3Component, sphere), new RgbColor(0D, 0D, 1D)),
		};

		return CreateIntersectionComponent(planes);
	}

	// TODO: Move to static class Scene.
	private ISceneComponent CreateSphereExceptCubeComponent()
	{
		var sphere = CreateScaledComponent(new Sphere(vector3Component, funcDoubleDoubleComponent, line3Component), 1.3D);

		var planes = new List<ISceneComponent>
		{
			new Inverted(vector3Component, CreateCubeComponent()),
			sphere,
		};

		return CreateIntersectionComponent(planes);
	}

	// TODO: Move to static class Scene.
	private ISceneComponent CreateCubeSphereIntersection()
	{
		var sphere = CreateScaledComponent(new Sphere(vector3Component, funcDoubleDoubleComponent, line3Component), 1.3D);

		var planes = new List<ISceneComponent>
		{
			CreateCubeComponent(),
			sphere,
		};

		return CreateIntersectionComponent(planes);
	}

	// TODO: Move to static class Scene.
	private ISceneComponent CreateCubeSphereUnion()
	{
		var sphere = CreateScaledComponent(new Sphere(vector3Component, funcDoubleDoubleComponent, line3Component), 1.3D);

		var planes = new List<ISceneComponent>
		{
			CreateCubeComponent(),
			sphere,
		};

		return CreateUnionComponent(planes);
	}

	// TODO: Move to static class Scene.
	private ISceneComponent CreateConeComponent()
	{
		var planes = new List<ISceneComponent>
		{
			new Cone(funcDoubleDoubleComponent, line3Component, vector3Component),
			new Plane(new Vector3(0D, 0D, -1D), vector3Component),
			new Plane(new Vector3(0D, 0D, 1D), vector3Component),
		};

		return CreateIntersectionComponent(planes);
	}

	// TODO: Move to static class Scene.
	private ISceneComponent CreateCylinderComponent()
	{
		var planes = new List<ISceneComponent>
		{
			new Cylinder(funcDoubleDoubleComponent, line3Component, vector3Component),
			new Plane(new Vector3(0D, 0D, -1D), vector3Component),
			new Plane(new Vector3(0D, 0D, 1D), vector3Component),
		};

		return CreateIntersectionComponent(planes);
	}

	// TODO: Move to static class Scene.
	private ISceneComponent CreateOctahedronComponent()
	{
		var dihedralAngle = Math.Acos(-1D / 3D);
		var azimuthStep = Math.PI / 3D;

		var planes = new List<ISceneComponent>
		{
			new Plane(vector3Component.CreateVector3FromSphericalCoordinates(1D, Math.PI, 0D), vector3Component),
			new Plane(vector3Component.CreateVector3FromSphericalCoordinates(1D, dihedralAngle, 0D * azimuthStep), vector3Component),
			new Plane(vector3Component.CreateVector3FromSphericalCoordinates(1D, dihedralAngle, 2D * azimuthStep), vector3Component),
			new Plane(vector3Component.CreateVector3FromSphericalCoordinates(1D, dihedralAngle, 4D * azimuthStep), vector3Component),
			new Plane(vector3Component.CreateVector3FromSphericalCoordinates(1D, Math.PI - dihedralAngle, 1D * azimuthStep), vector3Component),
			new Plane(vector3Component.CreateVector3FromSphericalCoordinates(1D, Math.PI - dihedralAngle, 3D * azimuthStep), vector3Component),
			new Plane(vector3Component.CreateVector3FromSphericalCoordinates(1D, Math.PI - dihedralAngle, 5D * azimuthStep), vector3Component),
			new Plane(vector3Component.CreateVector3FromSphericalCoordinates(1D, 0D, 0D), vector3Component),
		};

		return CreateIntersectionComponent(planes);
	}

	// TODO: Move to static class Scene.
	private ISceneComponent CreateDodecahedronComponent()
	{
		var dihedralAngle = Math.Acos(-1D / Math.Sqrt(5D));
		var azimuthStep = Math.PI / 5D;

		var planes = new List<ISceneComponent>
		{
					new Plane(vector3Component.CreateVector3FromSphericalCoordinates(1D, Math.PI, 0D), vector3Component),
					new Plane(vector3Component.CreateVector3FromSphericalCoordinates(1D, dihedralAngle, 0D * azimuthStep), vector3Component),
					new Plane(vector3Component.CreateVector3FromSphericalCoordinates(1D, dihedralAngle, 2D * azimuthStep), vector3Component),
					new Plane(vector3Component.CreateVector3FromSphericalCoordinates(1D, dihedralAngle, 4D * azimuthStep), vector3Component),
					new Plane(vector3Component.CreateVector3FromSphericalCoordinates(1D, dihedralAngle, 6D * azimuthStep), vector3Component),
					new Plane(vector3Component.CreateVector3FromSphericalCoordinates(1D, dihedralAngle, 8D * azimuthStep), vector3Component),
					new Plane(vector3Component.CreateVector3FromSphericalCoordinates(1D, Math.PI - dihedralAngle, 1D * azimuthStep), vector3Component),
					new Plane(vector3Component.CreateVector3FromSphericalCoordinates(1D, Math.PI - dihedralAngle, 3D * azimuthStep), vector3Component),
					new Plane(vector3Component.CreateVector3FromSphericalCoordinates(1D, Math.PI - dihedralAngle, 5D * azimuthStep), vector3Component),
					new Plane(vector3Component.CreateVector3FromSphericalCoordinates(1D, Math.PI - dihedralAngle, 7D * azimuthStep), vector3Component),
					new Plane(vector3Component.CreateVector3FromSphericalCoordinates(1D, Math.PI - dihedralAngle, 9D * azimuthStep), vector3Component),
					new Plane(vector3Component.CreateVector3FromSphericalCoordinates(1D, 0D, 0D), vector3Component),
		};

		return CreateIntersectionComponent(planes);
	}

	// TODO: Move to static class Scene.
	private ISceneComponent CreateIcosahedronComponent()
	{
		var dihedralAngle = Math.Acos(-Math.Sqrt(5D) / 3D);
		var secondInclination = Math.Acos(-1D / 3D);
		var azimuthStep = Math.PI / 3D;
		var azimuthOffset = Math.PI / 3D - Math.Acos(Math.Sqrt(5D / 8D));

		var planes = new List<ISceneComponent>
		{
			new Plane(vector3Component.CreateVector3FromSphericalCoordinates(1D, Math.PI, 0D), vector3Component),
			new Plane(vector3Component.CreateVector3FromSphericalCoordinates(1D, dihedralAngle, 0D * azimuthStep), vector3Component),
			new Plane(vector3Component.CreateVector3FromSphericalCoordinates(1D, dihedralAngle, 2D * azimuthStep), vector3Component),
			new Plane(vector3Component.CreateVector3FromSphericalCoordinates(1D, dihedralAngle, 4D * azimuthStep), vector3Component),
			new Plane(vector3Component.CreateVector3FromSphericalCoordinates(1D, secondInclination, 1D * azimuthStep - azimuthOffset), vector3Component),
			new Plane(vector3Component.CreateVector3FromSphericalCoordinates(1D, secondInclination, 1D * azimuthStep + azimuthOffset), vector3Component),
			new Plane(vector3Component.CreateVector3FromSphericalCoordinates(1D, secondInclination, 3D * azimuthStep - azimuthOffset), vector3Component),
			new Plane(vector3Component.CreateVector3FromSphericalCoordinates(1D, secondInclination, 3D * azimuthStep + azimuthOffset), vector3Component),
			new Plane(vector3Component.CreateVector3FromSphericalCoordinates(1D, secondInclination, 5D * azimuthStep - azimuthOffset), vector3Component),
			new Plane(vector3Component.CreateVector3FromSphericalCoordinates(1D, secondInclination, 5D * azimuthStep + azimuthOffset), vector3Component),
			new Plane(vector3Component.CreateVector3FromSphericalCoordinates(1D, Math.PI - secondInclination, 0D * azimuthStep - azimuthOffset), vector3Component),
			new Plane(vector3Component.CreateVector3FromSphericalCoordinates(1D, Math.PI - secondInclination, 0D * azimuthStep + azimuthOffset), vector3Component),
			new Plane(vector3Component.CreateVector3FromSphericalCoordinates(1D, Math.PI - secondInclination, 2D * azimuthStep - azimuthOffset), vector3Component),
			new Plane(vector3Component.CreateVector3FromSphericalCoordinates(1D, Math.PI - secondInclination, 2D * azimuthStep + azimuthOffset), vector3Component),
			new Plane(vector3Component.CreateVector3FromSphericalCoordinates(1D, Math.PI - secondInclination, 4D * azimuthStep - azimuthOffset), vector3Component),
			new Plane(vector3Component.CreateVector3FromSphericalCoordinates(1D, Math.PI - secondInclination, 4D * azimuthStep + azimuthOffset), vector3Component),
			new Plane(vector3Component.CreateVector3FromSphericalCoordinates(1D, Math.PI - dihedralAngle, 1D * azimuthStep), vector3Component),
			new Plane(vector3Component.CreateVector3FromSphericalCoordinates(1D, Math.PI - dihedralAngle, 3D * azimuthStep), vector3Component),
			new Plane(vector3Component.CreateVector3FromSphericalCoordinates(1D, Math.PI - dihedralAngle, 5D * azimuthStep), vector3Component),
			new Plane(vector3Component.CreateVector3FromSphericalCoordinates(1D, 0D, 0D), vector3Component),
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

	private ISceneComponent CreateUnionComponent(List<ISceneComponent> scenes) =>
		// TODO: Use type argument instead of casting?
		scenes.Aggregate(
			(ISceneComponent)new Empty(),
			(scene, otherScene) =>
				new Union(
					line3Component,
					scene,
					otherScene));

	private ISceneComponent CreateRotatedComponent(ISceneComponent scene, Vector3 axis, double angle)
	{
		return new AffinelyTransformedComponent(
			matrix4Component,
			scene,
			matrix4Component.CreateRotationMatrix(axis, angle),
			matrix4Component.CreateRotationMatrix(axis, -angle));
	}

	private ISceneComponent CreateScaledComponent(ISceneComponent scene, double factor)
	{
		return new AffinelyTransformedComponent(
			matrix4Component,
			scene,
			matrix4Component.CreateScalingMatrix(factor),
			matrix4Component.CreateScalingMatrix(1 / factor));
	}

	private ISceneComponent CreateTranslatedComponent(ISceneComponent scene, Vector3 translation)
	{
		return new AffinelyTransformedComponent(
			matrix4Component,
			scene,
			matrix4Component.CreateTranslationMatrix(translation),
			matrix4Component.CreateTranslationMatrix(translation * -1D));
	}
}
