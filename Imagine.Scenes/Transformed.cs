namespace Imagine.Scenes;

internal class Transformed(IScene scene, Matrix4 forward, Matrix4 backward) : IScene
{
	public bool Contains(Vector3 point) => scene.Contains(BackwardPoint(point));

	public List<Intercept> Intercepts(Line3 ray)
	{
		var backwardRay = new Line3
		{
			Origin = BackwardPoint(ray.Origin),
			Direction = BackwardDirection(ray.Direction),
		};

		return scene.Intercepts(backwardRay)
			.Select(intercept =>
				new Intercept(
					Distance: intercept.Distance,
					Normal: ForwardDirection(intercept.Normal),
					Color: intercept.Color))
			.ToList();
	}

	private Vector3 BackwardDirection(Vector3 direction) => (Vector3)(backward * new Vector4(direction, 0D));

	private Vector3 BackwardPoint(Vector3 point) => (Vector3)(backward * new Vector4(point, 1D));

	private Vector3 ForwardDirection(Vector3 direction) => (Vector3)(forward * new Vector4(direction, 0D));
}
