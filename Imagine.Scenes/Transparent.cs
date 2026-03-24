namespace Imagine.Scenes;

internal class Transparent(IScene scene) : IScene
{
	public bool Contains(Vector3 point) =>
		scene.Contains(point);

	public List<Intercept> Intercepts(Line3 ray) =>
		[];
}
