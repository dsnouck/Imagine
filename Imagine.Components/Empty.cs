namespace Imagine.Components;

public class Empty : IScene
{
	public bool Contains(Vector3 point) => false;

	public List<Intercept> Intercepts(Line3 ray) => new();
}
