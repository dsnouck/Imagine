namespace Imagine.Scenes;

public class Cone : IScene
{
	public bool Contains(Vector3 point)
	{
		var mirroredPoint = new Vector3
		{
			X = point.X,
			Y = point.Y,
			Z = -point.Z,
		};

		return point.Dot(mirroredPoint) < 0D;
	}

	public List<Intercept> Intercepts(Line3 ray)
	{
		var mirroredLineOfSight = new Line3
		{
			Origin = new Vector3
			{
				X = ray.Origin.X,
				Y = ray.Origin.Y,
				Z = -ray.Origin.Z,
			},
			Direction = new Vector3
			{
				X = ray.Direction.X,
				Y = ray.Direction.Y,
				Z = -ray.Direction.Z,
			},
		};

		// These are the coefficients of the quadratic equation x ↦ ax² + bx + c we want to solve.
		var a = ray.Direction.Dot(mirroredLineOfSight.Direction);
		var b = ray.Direction.Dot(mirroredLineOfSight.Origin) * 2D;
		var c = ray.Origin.Dot(mirroredLineOfSight.Origin);

		var zeros = QuadraticSolver.Solve(a, b, c);

		return zeros.
			Select(zero =>
			{
				var surfaceIntersection = ray.At(zero);
				var mirroredSurfaceIntersection = new Vector3
				{
					X = surfaceIntersection.X,
					Y = surfaceIntersection.Y,
					Z = -surfaceIntersection.Z,
				};

				return new Intercept
				{
					Distance = zero,
					Normal = mirroredSurfaceIntersection.Normalized() * ray.Direction.Length(),
					Color = new ColorRgb(1D, 1D, 1D),
				};
			})
			.ToList();
	}
}
