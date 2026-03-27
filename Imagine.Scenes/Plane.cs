namespace Imagine.Scenes;

internal class Plane(Vector3 normal) : IScene
{
	private const double Epsilon = 0.001D;

	public bool Contains(Vector3 point) =>
		point.Dot(normal) <= normal.Dot(normal);

	public List<Intercept> Intercepts(Line3 ray)
	{
		var normalDotRayDirection = normal.Dot(ray.Direction);

		if (double.Abs(normalDotRayDirection) < Epsilon)
		{
			return [];
		}

		var distance = normal.Dot(normal - ray.Origin) / normalDotRayDirection;

		return
		[
			new(
				distance: distance,
				normal: normal.Normalized()),
		];
	}
}
