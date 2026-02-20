namespace Imagine.Scenes;

// TODO: Make implementations of IScene internal.
public class Sphere : IScene
{
	public bool Contains(Vector3 point) => point.Dot(point) <= 1D;

	public List<Intercept> Intercepts(Line3 ray)
	{
		// These are the coefficients of the quadratic equation x ↦ ax² + bx + c we want to solve.
		// TODO: Inline.
		var a = ray.Direction.Dot(ray.Direction);
		var b = ray.Direction.Dot(ray.Origin) * 2D;
		var c = ray.Origin.Dot(ray.Origin) - 1D;

		var zeros = QuadraticSolver.Solve(a, b, c);

		// TODO: When we want to enable transformations, the distance should be relative to the length of the direction vector. What about the normal?
		// TODO: Make Normal lazy.
		// TODO: Make Color lazy.
		// TODO: Create an Intercept constructor with a default color.
		// TODO: Create inline method for lambda.
		return zeros.
			Select(zero => new Intercept(
				Distance: zero,
				Normal: ray.At(zero).Normalized() * ray.Direction.Length(),
				Color: new ColorRgb(1D, 1D, 1D)))
			.ToList();
	}
}
