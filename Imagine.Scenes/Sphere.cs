namespace Imagine.Scenes;

internal class Sphere(double radius) : IScene
{
	public bool Contains(Vector3 point) =>
		point.Dot(point) <= radius * radius;

	public List<Intercept> Intercepts(Line3 ray)
	{
		var distances = QuadraticSolver.Solve(
			ray.Direction.Dot(ray.Direction),
			ray.Direction.Dot(ray.Origin) * 2D,
			ray.Origin.Dot(ray.Origin) - (radius * radius));

		return distances.
			Select(distance =>
				new Intercept(
					distance: distance,
					normal: ray.At(distance).Normalized() * ray.Direction.Length()))
			.ToList();
	}
}
