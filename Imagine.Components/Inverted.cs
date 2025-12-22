namespace Imagine.Components;

public class Inverted(
	IVector3Component vector3Component,
	ISceneComponent scene)
	: ISceneComponent
{
	public bool Contains(Vector3 point) => !scene.Contains(point);

	public List<Intercept> Intercepts(Line3 ray) =>
		scene.Intercepts(ray)
			.Select(intercept => new Intercept
			{
				Distance = intercept.Distance,
				Normal = vector3Component.Multiply(intercept.Normal, -1D),
				Color = intercept.Color,
			})
			.ToList();
}
