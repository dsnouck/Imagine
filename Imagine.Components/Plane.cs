namespace Imagine.Components;

public class Plane(Vector3 normal, IVector3Component vector3Component) : ISceneComponent
{
	// TODO: Make smaller?
	private const double Epsilon = 0.001D;

	// TODO: Place expression bodies on their own lines or on the same line?
	public bool Contains(Vector3 point) => point.DotProduct(normal) <= normal.DotProduct(normal);

	public List<Intercept> Intercepts(Line3 ray)
	{
		// TODO: Remove variable?
		var lineOfSight = ray;

		var dotProductNormalDirection = normal.DotProduct(lineOfSight.Direction);

		if (Math.Abs(dotProductNormalDirection) < Epsilon)
		{
			// The line of sight is approximately parallel to the plane.
			return new List<Intercept>();
		}

		var distance = normal.DotProduct(normal - lineOfSight.Origin) / dotProductNormalDirection;

		// TODO: Can we use new() here?
		return new List<Intercept>
		{
			// TODO: Use the correct override of new()
			new()
			{
				Distance = distance,
				Normal = vector3Component.Normalize(normal) * vector3Component.Length(lineOfSight.Direction),
				Color = new RgbColor(1, 1, 1),
			},
		};
	}
}
