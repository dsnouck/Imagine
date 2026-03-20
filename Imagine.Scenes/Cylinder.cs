namespace Imagine.Scenes;

internal class Cylinder(double radius) : IScene
{
	public bool Contains(Vector3 point)
	{
		var horizontalPoint = Horizontal(point);

		return horizontalPoint.Dot(horizontalPoint) <= radius * radius;
	}

	public List<Intercept> Intercepts(Line3 ray)
	{
		var horizontalRay = new Line3(
			Origin: Horizontal(ray.Origin),
			Direction: Horizontal(ray.Direction));

		var distances = QuadraticSolver.Solve(
			horizontalRay.Direction.Dot(horizontalRay.Direction),
			horizontalRay.Direction.Dot(horizontalRay.Origin) * 2D,
			horizontalRay.Origin.Dot(horizontalRay.Origin) - (radius * radius));

		return distances
			.Select(distance =>
			{
				var intercept = ray.At(distance);
				var horizontalIntercept = Horizontal(intercept);

				return new Intercept(
					distance: distance,
					normal: horizontalIntercept.Normalized() * ray.Direction.Length());
			})
			.ToList();
	}

	private static Vector3 Horizontal(Vector3 point) => new(point.X, point.Y, 0D);
}
