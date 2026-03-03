namespace Imagine.Scenes;

public static class Scene
{
	public static IScene Cone() => new Cone();

	public static IScene Cylinder() => new Cylinder();

	public static IScene Full() => new Full();

	// TODO: Use extension block.
	public static IScene IntersectedWith(this IScene scene, IScene otherScene) =>
		new Intersection(scene, otherScene);

	// TODO: Use params List.
	public static IScene Intersection(params IScene[] scenes) =>
		scenes.Aggregate(
			Full(),
			(scene, otherScene) => scene.IntersectedWith(otherScene));

	public static IScene Plane(Vector3 normal) => new Plane(normal);

	public static IScene Polyhedron(params Vector3[] normals) => Intersection(normals.Select(Plane).ToArray());

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
}
