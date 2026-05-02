namespace Imagine.Scenes;

internal class Cylinder(Vector3 axis, float radius) : IScene
{
	private readonly Vector3 axisNormalized = axis.Normalized();

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
			directionPerpendicular.Dot(originPerpendicular) * 2F,
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

	private Vector3 Perpendicular(Vector3 point) =>
		point - (axisNormalized * point.Dot(axisNormalized));
}
