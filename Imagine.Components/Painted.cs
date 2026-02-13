namespace Imagine.Components;

public class Painted(IScene sceneComponent, ColorRgb color) : IScene
{
	public bool Contains(Vector3 point) => sceneComponent.Contains(point);

	public List<Intercept> Intercepts(Line3 ray) =>
		sceneComponent.Intercepts(ray)
			.Select(intercept => new Intercept(intercept.Distance, intercept.Normal, color))
			.ToList();
}
