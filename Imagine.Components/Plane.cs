namespace Imagine.Components;

public class Plane(Vector3 normal) : IScene
{
	// TODO: Make smaller?
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
			// The line of sight is approximately parallel to the plane.
			return new List<Intercept>();
		}

		var distance = normal.Dot(normal - lineOfSight.Origin) / dotProductNormalDirection;

		// TODO: Can we use new() here?
		return new List<Intercept>
		{
			// TODO: Use the correct override of new()
			new()
			{
				Distance = distance,
				Normal = normal.Normalized() * lineOfSight.Direction.Length(),
				Color = new ColorRgb(1, 1, 1),
			},
		};
	}
}
