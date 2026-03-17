namespace Imagine.Scenes;

public static class Scene
{
	public static IScene Cone() => new Cone();

	public static IScene Cube() => CubeWithCircumradius(1D);

	public static IScene CubeWithCircumradius(double r) => CubeWithInradius(r / double.Sqrt(3D));

	public static IScene CubeWithInradius(double r) =>
		Polyhedron(
			new Vector3(0D, 0D, -r),
			new Vector3(r, 0D, 0D),
			new Vector3(0D, r, 0D),
			new Vector3(-r, 0D, 0D),
			new Vector3(0D, -r, 0D),
			new Vector3(0D, 0D, r));

	public static IScene Cylinder() => CylinderWithRadius(1D);

	public static IScene CylinderWithRadius(double r) => new Cylinder(r);

	public static IScene Dodecahedron() => DodecahedronWithCircumradius(1D);

	public static IScene DodecahedronWithCircumradius(double r) => DodecahedronWithInradius(r / double.Sqrt(15D - (6D * double.Sqrt(5D))));

	public static IScene DodecahedronWithInradius(double r)
	{
		var dihedralAngle = double.Acos(-1D / double.Sqrt(5D));
		var azimuthStep = Math.PI / 5D;

		// TODO: Use cartesian coordinates here instead of spherical coordinates when possible.
		return Polyhedron(
			new Vector3Spherical(r, Math.PI, 0D),
			new Vector3Spherical(r, dihedralAngle, 0D * azimuthStep),
			new Vector3Spherical(r, dihedralAngle, 2D * azimuthStep),
			new Vector3Spherical(r, dihedralAngle, 4D * azimuthStep),
			new Vector3Spherical(r, dihedralAngle, 6D * azimuthStep),
			new Vector3Spherical(r, dihedralAngle, 8D * azimuthStep),
			new Vector3Spherical(r, Math.PI - dihedralAngle, 1D * azimuthStep),
			new Vector3Spherical(r, Math.PI - dihedralAngle, 3D * azimuthStep),
			new Vector3Spherical(r, Math.PI - dihedralAngle, 5D * azimuthStep),
			new Vector3Spherical(r, Math.PI - dihedralAngle, 7D * azimuthStep),
			new Vector3Spherical(r, Math.PI - dihedralAngle, 9D * azimuthStep),
			new Vector3Spherical(r, 0D, 0D));
	}

	public static IScene Empty() => new Empty();

	public static IScene Except(this IScene scene, IScene otherScene) => Intersection(scene, otherScene.Inverted());

	public static IScene Full() => new Full();

	public static IScene Icosahedron() => IcosahedronWithCircumradius(1D);

	public static IScene IcosahedronWithCircumradius(double r) => IcosahedronWithInradius(r / double.Sqrt(15D - (6D * double.Sqrt(5D))));

	public static IScene IcosahedronWithInradius(double r)
	{
		var dihedralAngle = double.Acos(-double.Sqrt(5D) / 3D);
		var secondInclination = double.Acos(-1D / 3D);
		var azimuthStep = Math.PI / 3D;
		var azimuthOffset = (Math.PI / 3D) - double.Acos(double.Sqrt(5D / 8D));

		return Polyhedron(
			new Vector3Spherical(r, Math.PI, 0D),
			new Vector3Spherical(r, dihedralAngle, 0D * azimuthStep),
			new Vector3Spherical(r, dihedralAngle, 2D * azimuthStep),
			new Vector3Spherical(r, dihedralAngle, 4D * azimuthStep),
			new Vector3Spherical(r, secondInclination, (1D * azimuthStep) - azimuthOffset),
			new Vector3Spherical(r, secondInclination, (1D * azimuthStep) + azimuthOffset),
			new Vector3Spherical(r, secondInclination, (3D * azimuthStep) - azimuthOffset),
			new Vector3Spherical(r, secondInclination, (3D * azimuthStep) + azimuthOffset),
			new Vector3Spherical(r, secondInclination, (5D * azimuthStep) - azimuthOffset),
			new Vector3Spherical(r, secondInclination, (5D * azimuthStep) + azimuthOffset),
			new Vector3Spherical(r, Math.PI - secondInclination, (0D * azimuthStep) - azimuthOffset),
			new Vector3Spherical(r, Math.PI - secondInclination, (0D * azimuthStep) + azimuthOffset),
			new Vector3Spherical(r, Math.PI - secondInclination, (2D * azimuthStep) - azimuthOffset),
			new Vector3Spherical(r, Math.PI - secondInclination, (2D * azimuthStep) + azimuthOffset),
			new Vector3Spherical(r, Math.PI - secondInclination, (4D * azimuthStep) - azimuthOffset),
			new Vector3Spherical(r, Math.PI - secondInclination, (4D * azimuthStep) + azimuthOffset),
			new Vector3Spherical(r, Math.PI - dihedralAngle, 1D * azimuthStep),
			new Vector3Spherical(r, Math.PI - dihedralAngle, 3D * azimuthStep),
			new Vector3Spherical(r, Math.PI - dihedralAngle, 5D * azimuthStep),
			new Vector3Spherical(r, 0D, 0D));
	}

	public static IScene IntersectedWith(this IScene scene, IScene otherScene) =>
		new Intersection(scene, otherScene);

	public static IScene Intersection(params IScene[] scenes) => scenes.Aggregate(Full(), IntersectedWith);

	public static IScene Inverted(this IScene scene) => new Inverted(scene);

	public static IScene Octahedron() => OctahedronWithCircumradius(1D);

	public static IScene OctahedronWithCircumradius(double r) => OctahedronWithInradius(r / double.Sqrt(3D));

	public static IScene OctahedronWithInradius(double r)
	{
		var dihedralAngle = double.Acos(-1D / 3D);
		var azimuthStep = Math.PI / 3D;

		return Polyhedron(
			new Vector3Spherical(r, Math.PI, 0D),
			new Vector3Spherical(r, dihedralAngle, 0D * azimuthStep),
			new Vector3Spherical(r, dihedralAngle, 2D * azimuthStep),
			new Vector3Spherical(r, dihedralAngle, 4D * azimuthStep),
			new Vector3Spherical(r, Math.PI - dihedralAngle, 1D * azimuthStep),
			new Vector3Spherical(r, Math.PI - dihedralAngle, 3D * azimuthStep),
			new Vector3Spherical(r, Math.PI - dihedralAngle, 5D * azimuthStep),
			new Vector3Spherical(r, 0D, 0D));
	}

	public static IScene Painted(this IScene scene, ColorRgb color) => new Painted(scene, color);

	public static IScene Plane(Vector3 normal) => new Plane(normal);

	public static IScene PlaneThroughOrigin(Vector3 normal) => Plane(normal).Translated(-normal);

	public static IScene Polyhedron(params Vector3[] normals) => Intersection(normals.Select(Plane).ToArray());

	public static IScene Rotated(this IScene scene, double angle) => scene.Rotated(new Vector3(0D, 0D, 1D), angle);

	public static IScene Rotated(this IScene scene, Vector3 axis, double angle) =>
		scene.Transformed(Matrix4.Rotation(axis, angle), Matrix4.Rotation(axis, -angle));

	public static IScene Scaled(this IScene scene, double factor) =>
		scene.Transformed(Matrix4.Scaling(factor), Matrix4.Scaling(1D / factor));

	public static IScene Sphere() => SphereWithRadius(1D);

	public static IScene SphereWithRadius(double r) => new Sphere(r);

	public static IScene Tetrahedron() => TetrahedronWithCircumradius(1D);

	// TODO: Rename arguments named r to circumradius and inradius respectively.
	public static IScene TetrahedronWithCircumradius(double r) => TetrahedronWithInradius(r / 3D);

	public static IScene TetrahedronWithInradius(double r)
	{
		var dihedralAngle = double.Acos(1D / 3D);
		var azimuthStep = 2D * Math.PI / 3D;

		return Polyhedron(
			new Vector3Spherical(r, Math.PI, 0D),
			new Vector3Spherical(r, dihedralAngle, 0D * azimuthStep),
			new Vector3Spherical(r, dihedralAngle, 1D * azimuthStep),
			new Vector3Spherical(r, dihedralAngle, 2D * azimuthStep));
	}

	public static IScene Transformed(this IScene scene, Matrix4 forward, Matrix4 backward) =>
		new Transformed(scene, forward, backward);

	public static IScene Translated(this IScene scene, Vector3 translation) =>
		scene.Transformed(Matrix4.Translation(translation), Matrix4.Translation(-translation));

	public static IScene Transparent(this IScene scene) => new Transparent(scene);

	public static IScene Union(params IScene[] scenes) => scenes.Aggregate(Empty(), UnitedWith);

	public static IScene UnitedWith(this IScene scene, IScene otherScene) => new Union(scene, otherScene);
}
