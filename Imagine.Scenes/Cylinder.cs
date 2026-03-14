namespace Imagine.Scenes;

public class Cylinder(double r) : IScene
{
	public bool Contains(Vector3 point)
	{
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
		var horizontalLineOfSight = new Line3
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
		var a = horizontalLineOfSight.Direction.Dot(horizontalLineOfSight.Direction);
		var b = horizontalLineOfSight.Direction.Dot(horizontalLineOfSight.Origin) * 2D;
		var c = horizontalLineOfSight.Origin.Dot(horizontalLineOfSight.Origin) - (r * r);

		var zeros = QuadraticSolver.Solve(a, b, c);

		return zeros
			.Select(zero =>
			{
				var surfaceIntersection = ray.At(zero);
				var horizontalSurfaceIntersection = new Vector3
				{
					X = surfaceIntersection.X,
					Y = surfaceIntersection.Y,
					Z = 0D,
				};

				return new Intercept(
					distance: zero,
					normal: horizontalSurfaceIntersection.Normalized() * ray.Direction.Length());
			})
			.ToList();
	}
}
