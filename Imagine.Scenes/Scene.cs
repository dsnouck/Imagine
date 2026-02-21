namespace Imagine.Scenes;

public static class Scene
{
	public static IScene Cone() => new Cone();

	public static IScene Full() => new Full();

	public static IScene IntersectedWith(this IScene scene, IScene otherScene) =>
		new Intersection(scene, otherScene);

	// TODO: Use params List.
	public static IScene Intersection(List<IScene> scenes) =>
		scenes.Aggregate(
			Full(),
			(scene, otherScene) => scene.IntersectedWith(otherScene));

	public static IScene Plane(Vector3 normal) => new Plane(normal);

	public static IScene Sphere() => new Sphere();
}
