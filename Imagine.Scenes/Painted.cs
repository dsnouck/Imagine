namespace Imagine.Scenes;

internal class Painted(IScene scene, ColorRgb color) : IScene
{
	public bool Contains(Vector3 point) =>
		scene.Contains(point);

	public List<Intercept> Intercepts(Line3 ray) =>
		scene.Intercepts(ray)
			.Select(intercept =>
				new Intercept(
					Distance: intercept.Distance,
					Normal: intercept.Normal,
					Color: color))
			.ToList();
}
