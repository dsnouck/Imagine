namespace Imagine.Scenes;

internal class Cylinder(Vector3 axis, double radius) : IScene
{
	public bool Contains(Vector3 point)
	{
		var pointPerpendicular = Perpendicular(point);

		return pointPerpendicular.Dot(pointPerpendicular) <= radius * radius;
	}

	public List<Intercept> Intercepts(Line3 ray)
	{
		var originPerpendicular = Perpendicular(ray.Origin);
		var directionPerpendicular = Perpendicular(ray.Direction);

		var distances = QuadraticSolver.Solve(
			directionPerpendicular.Dot(directionPerpendicular),
			directionPerpendicular.Dot(originPerpendicular) * 2D,
			originPerpendicular.Dot(originPerpendicular) - (radius * radius));

		return [.. distances
			.Select(distance =>
			{
				var pointPerpendicular = Perpendicular(ray.At(distance));

				return new Intercept(
					distance: distance,
					normal: pointPerpendicular.Normalized());
			})];
	}

	private Vector3 Perpendicular(Vector3 point)
	{
		var axisNormalized = axis.Normalized();

		return point - (axisNormalized * point.Dot(axisNormalized));
	}
}
