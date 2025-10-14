namespace Imagine.Components;

// TODO: Rename to IScene?
public interface ISceneComponent
{
	List<Intercept> Intercepts(Line3 ray);

	bool Contains(Vector3 point);
}
