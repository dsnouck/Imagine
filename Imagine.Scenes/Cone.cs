namespace Imagine.Scenes;

internal class Cone(Vector3 axis, double angle) : IScene
{
	private readonly Vector3 axisNormalized = axis.Normalized();
	private readonly double k = (1D + double.Cos(angle)) / 2D;

	public bool Contains(Vector3 point) =>
		k * point.Dot(point) <= point.Dot(axisNormalized) * point.Dot(axisNormalized);

	public List<Intercept> Intercepts(Line3 ray)
	{
		var distances = QuadraticSolver.Solve(
			(k * ray.Direction.Dot(ray.Direction)) - (ray.Direction.Dot(axisNormalized) * ray.Direction.Dot(axisNormalized)),
			2D * ((k * ray.Origin.Dot(ray.Direction)) - (ray.Origin.Dot(axisNormalized) * ray.Direction.Dot(axisNormalized))),
			(k * ray.Origin.Dot(ray.Origin)) - (ray.Origin.Dot(axisNormalized) * ray.Origin.Dot(axisNormalized)));

		return [.. distances.
			Select(distance =>
				new Intercept(
					distance: distance,
					normal: ((ray.At(distance) * k) - (axisNormalized * ray.At(distance).Dot(axisNormalized))).Normalized()))];
	}
}
