namespace Imagine.Scenes;

public static class Scene
{
	public static IScene Cone(Vector3 axis, double angle) =>
		new Cone(axis, angle);

	public static IScene Cube() =>
		CubeWithCircumradius(1D);

	public static IScene CubeWithCircumradius(double circumradius) =>
		CubeWithInradius(circumradius / double.Sqrt(3D));

	public static IScene CubeWithInradius(double inradius) =>
		Polyhedron(
			new Vector3(0D, 0D, -inradius),
			new Vector3(inradius, 0D, 0D),
			new Vector3(0D, inradius, 0D),
			new Vector3(-inradius, 0D, 0D),
			new Vector3(0D, -inradius, 0D),
			new Vector3(0D, 0D, inradius));

	public static IScene Cylinder(Vector3 axis, double radius) =>
		new Cylinder(axis, radius);

	public static IScene Dodecahedron() =>
		DodecahedronWithCircumradius(1D);

	public static IScene DodecahedronWithCircumradius(double circumradius) =>
		DodecahedronWithInradius(circumradius / double.Sqrt(15D - (6D * double.Sqrt(5D))));

	public static IScene DodecahedronWithInradius(double inradius)
	{
		var dihedralAngle = double.Acos(-1D / double.Sqrt(5D));
		var azimuthStep = double.Pi / 5D;

		return Polyhedron(
			new Vector3Spherical(inradius, 0D, double.Pi),
			new Vector3Spherical(inradius, 0D * azimuthStep, dihedralAngle),
			new Vector3Spherical(inradius, 2D * azimuthStep, dihedralAngle),
			new Vector3Spherical(inradius, 4D * azimuthStep, dihedralAngle),
			new Vector3Spherical(inradius, 6D * azimuthStep, dihedralAngle),
			new Vector3Spherical(inradius, 8D * azimuthStep, dihedralAngle),
			new Vector3Spherical(inradius, 1D * azimuthStep, double.Pi - dihedralAngle),
			new Vector3Spherical(inradius, 3D * azimuthStep, double.Pi - dihedralAngle),
			new Vector3Spherical(inradius, 5D * azimuthStep, double.Pi - dihedralAngle),
			new Vector3Spherical(inradius, 7D * azimuthStep, double.Pi - dihedralAngle),
			new Vector3Spherical(inradius, 9D * azimuthStep, double.Pi - dihedralAngle),
			new Vector3Spherical(inradius, 0D, 0D));
	}

	public static IScene Empty() =>
		new Empty();

	public static IScene Full() =>
		new Full();

	public static IScene Icosahedron() =>
		IcosahedronWithCircumradius(1D);

	public static IScene IcosahedronWithCircumradius(double circumradius) =>
		IcosahedronWithInradius(circumradius / double.Sqrt(15D - (6D * double.Sqrt(5D))));

	public static IScene IcosahedronWithInradius(double inradius)
	{
		var dihedralAngle = double.Acos(-double.Sqrt(5D) / 3D);
		var secondInclination = double.Acos(-1D / 3D);
		var azimuthStep = double.Pi / 3D;
		var azimuthOffset = (double.Pi / 3D) - double.Acos(double.Sqrt(5D / 8D));

		return Polyhedron(
			new Vector3Spherical(inradius, 0D, double.Pi),
			new Vector3Spherical(inradius, 0D * azimuthStep, dihedralAngle),
			new Vector3Spherical(inradius, 2D * azimuthStep, dihedralAngle),
			new Vector3Spherical(inradius, 4D * azimuthStep, dihedralAngle),
			new Vector3Spherical(inradius, (1D * azimuthStep) - azimuthOffset, secondInclination),
			new Vector3Spherical(inradius, (1D * azimuthStep) + azimuthOffset, secondInclination),
			new Vector3Spherical(inradius, (3D * azimuthStep) - azimuthOffset, secondInclination),
			new Vector3Spherical(inradius, (3D * azimuthStep) + azimuthOffset, secondInclination),
			new Vector3Spherical(inradius, (5D * azimuthStep) - azimuthOffset, secondInclination),
			new Vector3Spherical(inradius, (5D * azimuthStep) + azimuthOffset, secondInclination),
			new Vector3Spherical(inradius, (0D * azimuthStep) - azimuthOffset, double.Pi - secondInclination),
			new Vector3Spherical(inradius, (0D * azimuthStep) + azimuthOffset, double.Pi - secondInclination),
			new Vector3Spherical(inradius, (2D * azimuthStep) - azimuthOffset, double.Pi - secondInclination),
			new Vector3Spherical(inradius, (2D * azimuthStep) + azimuthOffset, double.Pi - secondInclination),
			new Vector3Spherical(inradius, (4D * azimuthStep) - azimuthOffset, double.Pi - secondInclination),
			new Vector3Spherical(inradius, (4D * azimuthStep) + azimuthOffset, double.Pi - secondInclination),
			new Vector3Spherical(inradius, 1D * azimuthStep, double.Pi - dihedralAngle),
			new Vector3Spherical(inradius, 3D * azimuthStep, double.Pi - dihedralAngle),
			new Vector3Spherical(inradius, 5D * azimuthStep, double.Pi - dihedralAngle),
			new Vector3Spherical(inradius, 0D, 0D));
	}

	public static IScene Intersection(params List<IScene> scenes) =>
		scenes.Aggregate(Full(), IntersectedWith);

	public static IScene Octahedron() =>
		OctahedronWithCircumradius(1D);

	public static IScene OctahedronWithCircumradius(double circumradius) =>
		OctahedronWithInradius(circumradius / double.Sqrt(3D));

	public static IScene OctahedronWithInradius(double inradius)
	{
		var dihedralAngle = double.Acos(-1D / 3D);
		var azimuthStep = double.Pi / 3D;

		return Polyhedron(
			new Vector3Spherical(inradius, 0D, double.Pi),
			new Vector3Spherical(inradius, 0D * azimuthStep, dihedralAngle),
			new Vector3Spherical(inradius, 2D * azimuthStep, dihedralAngle),
			new Vector3Spherical(inradius, 4D * azimuthStep, dihedralAngle),
			new Vector3Spherical(inradius, 1D * azimuthStep, double.Pi - dihedralAngle),
			new Vector3Spherical(inradius, 3D * azimuthStep, double.Pi - dihedralAngle),
			new Vector3Spherical(inradius, 5D * azimuthStep, double.Pi - dihedralAngle),
			new Vector3Spherical(inradius, 0D, 0D));
	}

	public static IScene Plane(Vector3 normal) =>
		new Plane(normal);

	public static IScene PlaneThroughOrigin(Vector3 normal) =>
		Plane(normal).Translated(-normal);

	public static IScene Polyhedron(params List<Vector3> normals) =>
		Intersection([.. normals.Select(Plane)]);

	public static IScene Polyhedron(params List<Vector3Spherical> normals) =>
		Intersection([.. normals.Select(normal => (Vector3)normal).Select(Plane)]);

	public static IScene Sphere() =>
		SphereWithRadius(1D);

	public static IScene SphereWithRadius(double radius) =>
		new Sphere(radius);

	public static IScene TetrahedronFaceDownWithCircumradius(double circumradius) =>
		TetrahedronFaceDownWithInradius(circumradius / 3D);

	public static IScene TetrahedronFaceDownWithInradius(double inradius)
	{
		var theta0 = double.Pi;
		var theta1 = double.Acos(1D / 3D);
		var deltaPhi = double.Pi / 3D;

		return Polyhedron(
			new Vector3Spherical(inradius, 0D, theta0),
			new Vector3Spherical(inradius, 0D * deltaPhi, theta1),
			new Vector3Spherical(inradius, 2D * deltaPhi, theta1),
			new Vector3Spherical(inradius, 4D * deltaPhi, theta1));
	}

	public static IScene TetrahedronVertexDownWithCircumradius(double circumradius) =>
		TetrahedronVertexDownWithInradius(circumradius / 3D);

	public static IScene TetrahedronVertexDownWithInradius(double inradius)
	{
		var theta0 = double.Acos(-1D / 3D);
		var theta1 = 0D;
		var deltaPhi = double.Pi / 3D;

		return Polyhedron(
			new Vector3Spherical(inradius, 1D * deltaPhi, theta0),
			new Vector3Spherical(inradius, 3D * deltaPhi, theta0),
			new Vector3Spherical(inradius, 5D * deltaPhi, theta0),
			new Vector3Spherical(inradius, 0D, theta1));
	}

	public static IScene Union(params List<IScene> scenes) =>
		scenes.Aggregate(Empty(), UnitedWith);

	extension(IScene source)
	{
		public IScene Except(IScene scene) =>
			Intersection(source, scene.Inverted());

		public IScene IntersectedWith(IScene scene) =>
			new Intersection(source, scene);

		public IScene Inverted() =>
			new Inverted(source);

		public IScene Painted(ColorRgb color) =>
			new Painted(source, color);

		public IScene Rotated(double angle) =>
			source.Rotated(new(0D, 0D, 1D), angle);

		public IScene Rotated(Vector3 axis, double angle) =>
			source.Transformed(Matrix4.Rotation(axis, angle), Matrix4.Rotation(axis, -angle));

		public IScene Scaled(double factor) =>
			source.Transformed(Matrix4.Scaling(factor), Matrix4.Scaling(1D / factor));

		public IScene Transformed(Matrix4 forward, Matrix4 backward) =>
			new Transformed(source, forward, backward);

		public IScene Translated(Vector3 translation) =>
			source.Transformed(Matrix4.Translation(translation), Matrix4.Translation(-translation));

		public IScene Transparent() =>
			new Transparent(source);

		public IScene UnitedWith(IScene scene) =>
			new Union(source, scene);
	}
}
