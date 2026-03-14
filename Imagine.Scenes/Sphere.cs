namespace Imagine.Scenes;

// TODO: Make implementations of IScene internal.
public class Sphere(double r) : IScene
{
	public bool Contains(Vector3 point) => point.Dot(point) <= r * r;

	public List<Intercept> Intercepts(Line3 ray)
	{
		// These are the coefficients of the quadratic equation x ↦ ax² + bx + c we want to solve.
		// TODO: Inline.
		var a = ray.Direction.Dot(ray.Direction);
		var b = ray.Direction.Dot(ray.Origin) * 2D;
		var c = ray.Origin.Dot(ray.Origin) - (r * r);

		var zeros = QuadraticSolver.Solve(a, b, c);

		// TODO: Create inline method for lambda.
		return zeros.
			Select(zero => new Intercept(
				distance: zero,
				normal: ray.At(zero).Normalized() * ray.Direction.Length()))
			.ToList();
	}
}
