namespace Imagine.Scenes;

public static class Scene
{
	public static IScene Cone() => new Cone();

	public static IScene Cube() =>
		Polyhedron(
			new Vector3(0D, 0D, -1D),
			new Vector3(1D, 0D, 0D),
			new Vector3(0D, 1D, 0D),
			new Vector3(-1D, 0D, 0D),
			new Vector3(0D, -1D, 0D),
			new Vector3(0D, 0D, 1D));

	public static IScene Cylinder() => new Cylinder();

	public static IScene Dodecahedron()
	{
		var dihedralAngle = double.Acos(-1D / double.Sqrt(5D));
		var azimuthStep = Math.PI / 5D;

		return Polyhedron(
			new Vector3Spherical(1D, Math.PI, 0D),
			new Vector3Spherical(1D, dihedralAngle, 0D * azimuthStep),
			new Vector3Spherical(1D, dihedralAngle, 2D * azimuthStep),
			new Vector3Spherical(1D, dihedralAngle, 4D * azimuthStep),
			new Vector3Spherical(1D, dihedralAngle, 6D * azimuthStep),
			new Vector3Spherical(1D, dihedralAngle, 8D * azimuthStep),
			new Vector3Spherical(1D, Math.PI - dihedralAngle, 1D * azimuthStep),
			new Vector3Spherical(1D, Math.PI - dihedralAngle, 3D * azimuthStep),
			new Vector3Spherical(1D, Math.PI - dihedralAngle, 5D * azimuthStep),
			new Vector3Spherical(1D, Math.PI - dihedralAngle, 7D * azimuthStep),
			new Vector3Spherical(1D, Math.PI - dihedralAngle, 9D * azimuthStep),
			new Vector3Spherical(1D, 0D, 0D));
	}

	public static IScene Empty() => new Empty();

	public static IScene Except(this IScene scene, IScene otherScene) => Intersection(scene, otherScene.Inverted());

	public static IScene Full() => new Full();

	public static IScene Icosahedron()
	{
		var dihedralAngle = double.Acos(-double.Sqrt(5D) / 3D);
		var secondInclination = double.Acos(-1D / 3D);
		var azimuthStep = Math.PI / 3D;
		var azimuthOffset = (Math.PI / 3D) - double.Acos(double.Sqrt(5D / 8D));

		return Polyhedron(
			new Vector3Spherical(1D, Math.PI, 0D),
			new Vector3Spherical(1D, dihedralAngle, 0D * azimuthStep),
			new Vector3Spherical(1D, dihedralAngle, 2D * azimuthStep),
			new Vector3Spherical(1D, dihedralAngle, 4D * azimuthStep),
			new Vector3Spherical(1D, secondInclination, (1D * azimuthStep) - azimuthOffset),
			new Vector3Spherical(1D, secondInclination, (1D * azimuthStep) + azimuthOffset),
			new Vector3Spherical(1D, secondInclination, (3D * azimuthStep) - azimuthOffset),
			new Vector3Spherical(1D, secondInclination, (3D * azimuthStep) + azimuthOffset),
			new Vector3Spherical(1D, secondInclination, (5D * azimuthStep) - azimuthOffset),
			new Vector3Spherical(1D, secondInclination, (5D * azimuthStep) + azimuthOffset),
			new Vector3Spherical(1D, Math.PI - secondInclination, (0D * azimuthStep) - azimuthOffset),
			new Vector3Spherical(1D, Math.PI - secondInclination, (0D * azimuthStep) + azimuthOffset),
			new Vector3Spherical(1D, Math.PI - secondInclination, (2D * azimuthStep) - azimuthOffset),
			new Vector3Spherical(1D, Math.PI - secondInclination, (2D * azimuthStep) + azimuthOffset),
			new Vector3Spherical(1D, Math.PI - secondInclination, (4D * azimuthStep) - azimuthOffset),
			new Vector3Spherical(1D, Math.PI - secondInclination, (4D * azimuthStep) + azimuthOffset),
			new Vector3Spherical(1D, Math.PI - dihedralAngle, 1D * azimuthStep),
			new Vector3Spherical(1D, Math.PI - dihedralAngle, 3D * azimuthStep),
			new Vector3Spherical(1D, Math.PI - dihedralAngle, 5D * azimuthStep),
			new Vector3Spherical(1D, 0D, 0D));
	}

	// TODO: Use extension block.
	public static IScene IntersectedWith(this IScene scene, IScene otherScene) =>
		new Intersection(scene, otherScene);

	// TODO: Use params List.
	public static IScene Intersection(params IScene[] scenes) => scenes.Aggregate(Full(), IntersectedWith);

	public static IScene Inverted(this IScene scene) => new Inverted(scene);

	public static IScene Octahedron()
	{
		var dihedralAngle = double.Acos(-1D / 3D);
		var azimuthStep = Math.PI / 3D;

		return Polyhedron(
			new Vector3Spherical(1D, Math.PI, 0D),
			new Vector3Spherical(1D, dihedralAngle, 0D * azimuthStep),
			new Vector3Spherical(1D, dihedralAngle, 2D * azimuthStep),
			new Vector3Spherical(1D, dihedralAngle, 4D * azimuthStep),
			new Vector3Spherical(1D, Math.PI - dihedralAngle, 1D * azimuthStep),
			new Vector3Spherical(1D, Math.PI - dihedralAngle, 3D * azimuthStep),
			new Vector3Spherical(1D, Math.PI - dihedralAngle, 5D * azimuthStep),
			new Vector3Spherical(1D, 0D, 0D));
	}

	public static IScene Painted(this IScene scene, ColorRgb color) => new Painted(scene, color);

	public static IScene Plane(Vector3 normal) => new Plane(normal);

	// TODO: A List is also an Array.
	public static IScene Polyhedron(params Vector3[] normals) => Intersection(normals.Select(Plane).ToArray());

	public static IScene Rotated(this IScene scene, double angle) => scene.Rotated(new Vector3(0D, 0D, 1D), angle);

	public static IScene Rotated(this IScene scene, Vector3 axis, double angle) =>
		scene.Transformed(Matrix4.Rotation(axis, angle), Matrix4.Rotation(axis, -angle));

	public static IScene Scaled(this IScene scene, double factor) =>
		scene.Transformed(Matrix4.Scaling(factor), Matrix4.Scaling(1D / factor));

	public static IScene Sphere() => new Sphere();

	public static IScene Tetrahedron()
	{
		var dihedralAngle = double.Acos(1D / 3D);
		var azimuthStep = 2D * Math.PI / 3D;

		return Polyhedron(
			new Vector3Spherical(1D, Math.PI, 0D),
			new Vector3Spherical(1D, dihedralAngle, 0D * azimuthStep),
			new Vector3Spherical(1D, dihedralAngle, 1D * azimuthStep),
			new Vector3Spherical(1D, dihedralAngle, 2D * azimuthStep));
	}

	public static IScene Transformed(this IScene scene, Matrix4 forward, Matrix4 backward) =>
		new Transformed(scene, forward, backward);

	public static IScene Translated(this IScene scene, Vector3 translation) =>
		scene.Transformed(Matrix4.Translation(translation), Matrix4.Translation(-translation));

	public static IScene Transparent(this IScene scene) => new Transparent(scene);

	public static IScene Union(params IScene[] scenes) => scenes.Aggregate(Empty(), UnitedWith);

	public static IScene UnitedWith(this IScene scene, IScene otherScene) => new Union(scene, otherScene);
}
