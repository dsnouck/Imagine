namespace Imagine.Components;

public class Plane(Vector3 normal, IVector3Component vector3Component) : ISceneComponent
{
	// TODO: Make smaller?
	private const double Epsilon = 0.001D;

	public bool Contains(Vector3 point) =>
		vector3Component.DotProduct(point, normal) <= vector3Component.DotProduct(normal, normal);

	public List<Intercept> Intercepts(Line3 ray)
	{
		var lineOfSight = ray;

		var dotProductNormalDirection = vector3Component.DotProduct(
			normal,
			lineOfSight.Direction);

		if (Math.Abs(dotProductNormalDirection) < Epsilon)
		{
			// The line of sight is approximately parallel to the plane.
			return new List<Intercept>();
		}

		var distance = vector3Component.DotProduct(
			normal,
			vector3Component.Subtract(
				normal,
				lineOfSight.Origin))
			/ dotProductNormalDirection;

		// TODO: Can we use new() here?
		return new List<Intercept>
		{
			new()
			{
				Distance = distance,
				Normal = vector3Component.Multiply(
					vector3Component.Normalize(normal),
					vector3Component.Length(lineOfSight.Direction)),
				Color = new RgbColor(1, 1, 1),
			},
		};
	}
}
