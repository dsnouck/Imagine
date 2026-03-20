namespace Imagine.Scenes;

internal class Plane(Vector3 normal) : IScene
{
	private const double Epsilon = 0.001D;

	// TODO: Place expression bodies on their own lines or on the same line?
	public bool Contains(Vector3 point) => point.Dot(normal) <= normal.Dot(normal);

	public List<Intercept> Intercepts(Line3 ray)
	{
		var normalDotRayDirection = normal.Dot(ray.Direction);

		if (double.Abs(normalDotRayDirection) < Epsilon)
		{
			// TODO: Remove unnecessary comments!
			return new();
		}

		var distance = normal.Dot(normal - ray.Origin) / normalDotRayDirection;

		return new()
		{
			new(
				distance: distance,
				normal: normal.Normalized() * ray.Direction.Length()),
		};
	}
}
