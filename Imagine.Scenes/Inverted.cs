namespace Imagine.Scenes;

public class Inverted(IScene scene) : IScene
{
	public bool Contains(Vector3 point) => !scene.Contains(point);

	public List<Intercept> Intercepts(Line3 ray) =>
		scene.Intercepts(ray)
			.Select(intercept => new Intercept
			{
				Distance = intercept.Distance,
				Normal = -intercept.Normal,
				Color = intercept.Color,
			})
			.ToList();
}
