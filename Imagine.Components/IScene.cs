namespace Imagine.Components;

public interface IScene
{
	List<Intercept> Intercepts(Line3 ray);

	bool Contains(Vector3 point);
}
