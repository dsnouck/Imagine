namespace Imagine.Scenes;

public class Plane(Vector3 normal) : IScene
{
	private const double Epsilon = 0.001D;

	// TODO: Place expression bodies on their own lines or on the same line?
	public bool Contains(Vector3 point) => point.Dot(normal) <= normal.Dot(normal);

	public List<Intercept> Intercepts(Line3 ray)
	{
		// TODO: Remove variable?
		var lineOfSight = ray;

		var dotProductNormalDirection = normal.Dot(lineOfSight.Direction);

		if (double.Abs(dotProductNormalDirection) < Epsilon)
		{
			// TODO: Remove unnecessary comments!
			// The line of sight is approximately parallel to the plane.
			return new List<Intercept>();
		}

		var distance = normal.Dot(normal - lineOfSight.Origin) / dotProductNormalDirection;

		// TODO: Can we use new() everywhere?
		return new()
		{
			new(
				distance: distance,
				normal: normal.Normalized() * lineOfSight.Direction.Length()),
		};
	}
}
