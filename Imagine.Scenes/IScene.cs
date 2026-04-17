namespace Imagine.Scenes;

public interface IScene
{
	bool Contains(Vector3 point);

	List<Intercept> Intercepts(Line3 ray);
}
