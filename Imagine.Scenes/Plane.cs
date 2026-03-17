namespace Imagine.Scenes;

internal class Plane(Vector3 normal) : IScene
{
	private const double Epsilon = 0.001D;

	// TODO: Place expression bodies on their own lines or on the same line?
	public bool Contains(Vector3 point) => point.Dot(normal) <= normal.Dot(normal);

	public List<Intercept> Intercepts(Line3 ray)
	{
		// TODO: Rename names using dotProduct.
		var dotProductNormalDirection = normal.Dot(ray.Direction);

		if (double.Abs(dotProductNormalDirection) < Epsilon)
		{
			// TODO: Remove unnecessary comments!
			// The line of sight is approximately parallel to the plane.
			return new List<Intercept>();
		}

		var distance = normal.Dot(normal - ray.Origin) / dotProductNormalDirection;

		// TODO: Can we use new() everywhere?
		return new()
		{
			new(
				distance: distance,
				normal: normal.Normalized() * ray.Direction.Length()),
		};
	}
}
