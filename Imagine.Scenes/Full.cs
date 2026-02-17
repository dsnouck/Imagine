namespace Imagine.Scenes;

public class Full : IScene
{
	public bool Contains(Vector3 point) => true;

	public List<Intercept> Intercepts(Line3 ray) => new();
}
