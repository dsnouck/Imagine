namespace Imagine.Components;

public class Transparent(
	ISceneComponent scene)
	: ISceneComponent
{
	public bool Contains(Vector3 point) => scene.Contains(point);

	public List<Intercept> Intercepts(Line3 ray) => new();
}
