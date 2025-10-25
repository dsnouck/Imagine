namespace Imagine.Components;

public class Full : ISceneComponent
{
	public bool Contains(Vector3 point) => true;

	public List<Intercept> Intercepts(Line3 ray) => new();
}
