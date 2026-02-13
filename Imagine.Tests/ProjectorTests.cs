namespace Imagine.Tests;

public class ProjectorTests
{
	[Fact]
	public void Sphere()
	{
		const string name = "sphere";

		var scene = new Sphere();

		// TODO: Find nice settings for all tests.
		var projectorSettings = new ProjectorSettings(
			Eye: new(2D, 3D, 4D),
			Focus: new(0D, 0D, 0D),
			FieldOfView: Math.PI / 4D,
			// TODO: Use new() everywhere.
			BackgroundColor: new ColorRgb(0D, 0D, 0D));

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

		var projection = Projector.Project(scene, projectorSettings);
		var image = Sampler.Sample(projection, settings);
		FileSaver.Save(image, name);
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
			BackgroundColor: new ColorRgb(0D, 0D, 0D));

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

		var projection = Projector.Project(scene, projectorSettings);
		var image = Sampler.Sample(projection, settings);
		FileSaver.Save(image, name);
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
			BackgroundColor: new ColorRgb(0D, 0D, 0D));

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
		var projection = Projector.Project(scene, projectorSettings);
		var image = Sampler.Sample(projection, settings);
		FileSaver.Save(image, name);
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
			BackgroundColor: new ColorRgb(0D, 0D, 0D));

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

		var projection = Projector.Project(scene, projectorSettings);
		var image = Sampler.Sample(projection, settings);
		FileSaver.Save(image, name);
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
			BackgroundColor: new ColorRgb(0D, 0D, 0D));

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

		var projection = Projector.Project(scene, projectorSettings);
		var image = Sampler.Sample(projection, settings);
		FileSaver.Save(image, name);
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
			BackgroundColor: new ColorRgb(0D, 0D, 0D));

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

		var projection = Projector.Project(scene, projectorSettings);
		var image = Sampler.Sample(projection, settings);
		FileSaver.Save(image, name);
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
			BackgroundColor: new ColorRgb(0D, 0D, 0D));

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

		var projection = Projector.Project(scene, projectorSettings);
		var image = Sampler.Sample(projection, settings);
		FileSaver.Save(image, name);
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
			BackgroundColor: new ColorRgb(0D, 0D, 0D));

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

		var projection = Projector.Project(scene, projectorSettings);
		var image = Sampler.Sample(projection, settings);
		FileSaver.Save(image, name);
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
			BackgroundColor: new ColorRgb(0D, 0D, 0D));

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

		var projection = Projector.Project(scene, projectorSettings);
		var image = Sampler.Sample(projection, settings);
		FileSaver.Save(image, name);
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
			BackgroundColor: new ColorRgb(0D, 0D, 0D));

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

		var projection = Projector.Project(scene, projectorSettings);
		var image = Sampler.Sample(projection, settings);
		FileSaver.Save(image, name);
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
			BackgroundColor: new ColorRgb(0D, 0D, 0D));

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

		var projection = Projector.Project(scene, projectorSettings);
		var image = Sampler.Sample(projection, settings);
		FileSaver.Save(image, name);
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
			BackgroundColor: new ColorRgb(0D, 0D, 0D));

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

		var projection = Projector.Project(scene, projectorSettings);
		var image = Sampler.Sample(projection, settings);
		FileSaver.Save(image, name);
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
			BackgroundColor: new ColorRgb(0D, 0D, 0D));

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

		var projection = Projector.Project(scene, projectorSettings);
		var image = Sampler.Sample(projection, settings);
		FileSaver.Save(image, name);
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
			BackgroundColor: new ColorRgb(0D, 0D, 0D));

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

		var projection = Projector.Project(scene, projectorSettings);
		var image = Sampler.Sample(projection, settings);
		FileSaver.Save(image, name);
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
			BackgroundColor: new ColorRgb(0D, 0D, 0D));

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

		var projection = Projector.Project(scene, projectorSettings);
		var image = Sampler.Sample(projection, settings);
		FileSaver.Save(image, name);
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
			BackgroundColor: new ColorRgb(0D, 0D, 0D));

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

		var projection = Projector.Project(scene, projectorSettings);
		var image = Sampler.Sample(projection, settings);
		FileSaver.Save(image, name);
	}

	// TODO: Reorder methods alphabetically?
	[Fact]
	public void Painted()
	{
		const string name = "red-cube";

		var scene = new Painted(CreateCubeComponent(), new ColorRgb(1D, 0D, 0D));

		// TODO: Find nice settings for all tests.
		var projectorSettings = new ProjectorSettings(
			Eye: new(2D, 3D, 4D),
			Focus: new(0D, 0D, 0D),
			FieldOfView: Math.PI / 4D,
			// TODO: Use new() everywhere.
			BackgroundColor: new ColorRgb(0D, 0D, 0D));

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

		var projection = Projector.Project(scene, projectorSettings);
		var image = Sampler.Sample(projection, settings);
		FileSaver.Save(image, name);
	}

	// TODO: Move to static class Scene.
	private IScene CreateTetrahedronComponent()
	{
		var dihedralAngle = double.Acos(1D / 3D);
		var azimuthStep = 2D * Math.PI / 3D;

		var planes = new List<IScene>
		{
			new Plane(new Vector3Spherical(1D, Math.PI, 0D)),
			new Plane(new Vector3Spherical(1D, dihedralAngle, 0D * azimuthStep)),
			new Plane(new Vector3Spherical(1D, dihedralAngle, 1D * azimuthStep)),
			new Plane(new Vector3Spherical(1D, dihedralAngle, 2D * azimuthStep)),
		};

		return CreateIntersectionComponent(planes);
	}

	// TODO: Move to static class Scene.
	private IScene CreateCubeComponent()
	{
		var planes = new List<IScene>
		{
			new Plane(new Vector3(0D, 0D, -1D)),
			new Plane(new Vector3(1D, 0D, 0D)),
			new Plane(new Vector3(0D, 1D, 0D)),
			new Plane(new Vector3(-1D, 0D, 0D)),
			new Plane(new Vector3(0D, -1D, 0D)),
			new Plane(new Vector3(0D, 0D, 1D)),
		};

		return CreateIntersectionComponent(planes);
	}

	// TODO: Move to static class Scene.
	private IScene CreatePlaneComponent()
	{
		var planes = new List<IScene>
		{
			new Plane(new Vector3(0D, 0D, -1D)),
			new Transparent(new Plane(new Vector3(1D, 0D, 0D))),
			new Transparent(new Plane(new Vector3(0D, 1D, 0D))),
			new Transparent(new Plane(new Vector3(-1D, 0D, 0D))),
			new Transparent(new Plane(new Vector3(0D, -1D, 0D))),
		};

		return CreateIntersectionComponent(planes);
	}

	// TODO: Move to static class Scene.
	private IScene CreateCubeExceptSphereComponent()
	{
		// TODO: Are these colors and sizes good?
		var sphere = CreateScaledComponent(new Sphere(), double.Sqrt(2D) * 0.99D);

		var planes = new List<IScene>
		{
			new Painted(CreateCubeComponent(), new ColorRgb(1D, 0D, 0D)),
			new Painted(new Inverted(sphere), new ColorRgb(0D, 0D, 1D)),
		};

		return CreateIntersectionComponent(planes);
	}

	// TODO: Move to static class Scene.
	private IScene CreateSphereExceptCubeComponent()
	{
		var sphere = CreateScaledComponent(new Sphere(), 1.3D);

		var planes = new List<IScene>
		{
			new Inverted(CreateCubeComponent()),
			sphere,
		};

		return CreateIntersectionComponent(planes);
	}

	// TODO: Move to static class Scene.
	private IScene CreateCubeSphereIntersection()
	{
		var sphere = CreateScaledComponent(new Sphere(), 1.3D);

		var planes = new List<IScene>
		{
			CreateCubeComponent(),
			sphere,
		};

		return CreateIntersectionComponent(planes);
	}

	// TODO: Move to static class Scene.
	private IScene CreateCubeSphereUnion()
	{
		var sphere = CreateScaledComponent(new Sphere(), 1.3D);

		var planes = new List<IScene>
		{
			CreateCubeComponent(),
			sphere,
		};

		return CreateUnionComponent(planes);
	}

	// TODO: Move to static class Scene.
	private IScene CreateConeComponent()
	{
		var planes = new List<IScene>
		{
			new Cone(),
			new Plane(new Vector3(0D, 0D, -1D)),
			new Plane(new Vector3(0D, 0D, 1D)),
		};

		return CreateIntersectionComponent(planes);
	}

	// TODO: Move to static class Scene.
	private IScene CreateCylinderComponent()
	{
		var planes = new List<IScene>
		{
			new Cylinder(),
			new Plane(new Vector3(0D, 0D, -1D)),
			new Plane(new Vector3(0D, 0D, 1D)),
		};

		return CreateIntersectionComponent(planes);
	}

	// TODO: Move to static class Scene.
	private IScene CreateOctahedronComponent()
	{
		var dihedralAngle = double.Acos(-1D / 3D);
		var azimuthStep = Math.PI / 3D;

		var planes = new List<IScene>
		{
			new Plane(new Vector3Spherical(1D, Math.PI, 0D)),
			new Plane(new Vector3Spherical(1D, dihedralAngle, 0D * azimuthStep)),
			new Plane(new Vector3Spherical(1D, dihedralAngle, 2D * azimuthStep)),
			new Plane(new Vector3Spherical(1D, dihedralAngle, 4D * azimuthStep)),
			new Plane(new Vector3Spherical(1D, Math.PI - dihedralAngle, 1D * azimuthStep)),
			new Plane(new Vector3Spherical(1D, Math.PI - dihedralAngle, 3D * azimuthStep)),
			new Plane(new Vector3Spherical(1D, Math.PI - dihedralAngle, 5D * azimuthStep)),
			new Plane(new Vector3Spherical(1D, 0D, 0D)),
		};

		return CreateIntersectionComponent(planes);
	}

	// TODO: Move to static class Scene.
	private IScene CreateDodecahedronComponent()
	{
		var dihedralAngle = double.Acos(-1D / double.Sqrt(5D));
		var azimuthStep = Math.PI / 5D;

		var planes = new List<IScene>
		{
					new Plane(new Vector3Spherical(1D, Math.PI, 0D)),
					new Plane(new Vector3Spherical(1D, dihedralAngle, 0D * azimuthStep)),
					new Plane(new Vector3Spherical(1D, dihedralAngle, 2D * azimuthStep)),
					new Plane(new Vector3Spherical(1D, dihedralAngle, 4D * azimuthStep)),
					new Plane(new Vector3Spherical(1D, dihedralAngle, 6D * azimuthStep)),
					new Plane(new Vector3Spherical(1D, dihedralAngle, 8D * azimuthStep)),
					new Plane(new Vector3Spherical(1D, Math.PI - dihedralAngle, 1D * azimuthStep)),
					new Plane(new Vector3Spherical(1D, Math.PI - dihedralAngle, 3D * azimuthStep)),
					new Plane(new Vector3Spherical(1D, Math.PI - dihedralAngle, 5D * azimuthStep)),
					new Plane(new Vector3Spherical(1D, Math.PI - dihedralAngle, 7D * azimuthStep)),
					new Plane(new Vector3Spherical(1D, Math.PI - dihedralAngle, 9D * azimuthStep)),
					new Plane(new Vector3Spherical(1D, 0D, 0D)),
		};

		return CreateIntersectionComponent(planes);
	}

	// TODO: Move to static class Scene.
	private IScene CreateIcosahedronComponent()
	{
		var dihedralAngle = double.Acos(-double.Sqrt(5D) / 3D);
		var secondInclination = double.Acos(-1D / 3D);
		var azimuthStep = Math.PI / 3D;
		var azimuthOffset = Math.PI / 3D - double.Acos(double.Sqrt(5D / 8D));

		var planes = new List<IScene>
		{
			new Plane(new Vector3Spherical(1D, Math.PI, 0D)),
			new Plane(new Vector3Spherical(1D, dihedralAngle, 0D * azimuthStep)),
			new Plane(new Vector3Spherical(1D, dihedralAngle, 2D * azimuthStep)),
			new Plane(new Vector3Spherical(1D, dihedralAngle, 4D * azimuthStep)),
			new Plane(new Vector3Spherical(1D, secondInclination, 1D * azimuthStep - azimuthOffset)),
			new Plane(new Vector3Spherical(1D, secondInclination, 1D * azimuthStep + azimuthOffset)),
			new Plane(new Vector3Spherical(1D, secondInclination, 3D * azimuthStep - azimuthOffset)),
			new Plane(new Vector3Spherical(1D, secondInclination, 3D * azimuthStep + azimuthOffset)),
			new Plane(new Vector3Spherical(1D, secondInclination, 5D * azimuthStep - azimuthOffset)),
			new Plane(new Vector3Spherical(1D, secondInclination, 5D * azimuthStep + azimuthOffset)),
			new Plane(new Vector3Spherical(1D, Math.PI - secondInclination, 0D * azimuthStep - azimuthOffset)),
			new Plane(new Vector3Spherical(1D, Math.PI - secondInclination, 0D * azimuthStep + azimuthOffset)),
			new Plane(new Vector3Spherical(1D, Math.PI - secondInclination, 2D * azimuthStep - azimuthOffset)),
			new Plane(new Vector3Spherical(1D, Math.PI - secondInclination, 2D * azimuthStep + azimuthOffset)),
			new Plane(new Vector3Spherical(1D, Math.PI - secondInclination, 4D * azimuthStep - azimuthOffset)),
			new Plane(new Vector3Spherical(1D, Math.PI - secondInclination, 4D * azimuthStep + azimuthOffset)),
			new Plane(new Vector3Spherical(1D, Math.PI - dihedralAngle, 1D * azimuthStep)),
			new Plane(new Vector3Spherical(1D, Math.PI - dihedralAngle, 3D * azimuthStep)),
			new Plane(new Vector3Spherical(1D, Math.PI - dihedralAngle, 5D * azimuthStep)),
			new Plane(new Vector3Spherical(1D, 0D, 0D)),
		};

		return CreateIntersectionComponent(planes);
	}

	private IScene CreateIntersectionComponent(List<IScene> scenes) =>
		scenes.Aggregate(
			(IScene)new Full(),
			(scene, otherScene) =>
				new Intersection(
					scene,
					otherScene));

	private IScene CreateUnionComponent(List<IScene> scenes) =>
		// TODO: Use type argument instead of casting?
		scenes.Aggregate(
			(IScene)new Empty(),
			(scene, otherScene) =>
				new Union(
					scene,
					otherScene));

	private IScene CreateRotatedComponent(IScene scene, Vector3 axis, double angle)
	{
		return new Transformed(
			scene,
			Matrix4.Rotation(axis, angle),
			Matrix4.Rotation(axis, -angle));
	}

	private IScene CreateScaledComponent(IScene scene, double factor)
	{
		return new Transformed(
			scene,
			Matrix4.Scaling(factor),
			Matrix4.Scaling(1D / factor));
	}

	private IScene CreateTranslatedComponent(IScene scene, Vector3 translation) =>
		new Transformed(
			scene,
			Matrix4.Translation(translation),
			Matrix4.Translation(-translation));
}
