namespace Imagine.Components;

public class Empty : ISceneComponent
{
	public bool Contains(Vector3 point) => false;

	public List<Intercept> Intercepts(Line3 ray) => new();
}
