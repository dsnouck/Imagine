namespace Imagine.Scenes;

internal class Cylinder(double r) : IScene
{
	public bool Contains(Vector3 point)
	{
		// TODO: Introduce a method to get the horizontal component of a vector.
		var horizontalPoint = new Vector3
		{
			X = point.X,
			Y = point.Y,
			Z = 0D,
		};

		return horizontalPoint.Dot(horizontalPoint) <= (r * r);
	}

	public List<Intercept> Intercepts(Line3 ray)
	{
		var horizontalRay = new Line3
		{
			Origin = new Vector3
			{
				X = ray.Origin.X,
				Y = ray.Origin.Y,
				Z = 0D,
			},
			Direction = new Vector3
			{
				X = ray.Direction.X,
				Y = ray.Direction.Y,
				Z = 0D,
			},
		};

		// These are the coefficients of the quadratic equation x ↦ ax² + bx + c we want to solve.
		var a = horizontalRay.Direction.Dot(horizontalRay.Direction);
		var b = horizontalRay.Direction.Dot(horizontalRay.Origin) * 2D;
		var c = horizontalRay.Origin.Dot(horizontalRay.Origin) - (r * r);

		var zeros = QuadraticSolver.Solve(a, b, c);

		return zeros
			.Select(zero =>
			{
				var intercept = ray.At(zero);
				var horizontalIntercept = new Vector3
				{
					X = intercept.X,
					Y = intercept.Y,
					Z = 0D,
				};

				return new Intercept(
					distance: zero,
					normal: horizontalIntercept.Normalized() * ray.Direction.Length());
			})
			.ToList();
	}
}
