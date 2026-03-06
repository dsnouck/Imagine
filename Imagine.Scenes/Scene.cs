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

	public static IScene Except(this IScene scene, IScene otherScene) => Intersection(scene, otherScene.Inverted());

	public static IScene Full() => new Full();

	// TODO: Use extension block.
	public static IScene IntersectedWith(this IScene scene, IScene otherScene) =>
		new Intersection(scene, otherScene);

	// TODO: Use params List.
	public static IScene Intersection(params IScene[] scenes) => scenes.Aggregate(Full(), IntersectedWith);

	public static IScene Inverted(this IScene scene) => new Inverted(scene);

	public static IScene Plane(Vector3 normal) => new Plane(normal);

	// TODO: A List is also an Array.
	public static IScene Polyhedron(params Vector3[] normals) => Intersection(normals.Select(Plane).ToArray());

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

	public static IScene Transparent(this IScene scene) => new Transparent(scene);
}
