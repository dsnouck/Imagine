namespace Imagine.Scenes;

internal class Empty : IScene
{
	public bool Contains(Vector3 point) =>
		false;

	public List<Intercept> Intercepts(Line3 ray) =>
		[];
}
