namespace Imagine.Scenes;

internal class Cone : IScene
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
		var mirroredRay = new Line3
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

		// TODO: Remove useless comments.
		// These are the coefficients of the quadratic equation x ↦ ax² + bx + c we want to solve.
		var a = ray.Direction.Dot(mirroredRay.Direction);
		var b = ray.Direction.Dot(mirroredRay.Origin) * 2D;
		var c = ray.Origin.Dot(mirroredRay.Origin);

		var zeros = QuadraticSolver.Solve(a, b, c);

		return zeros.
			Select(zero =>
			{
				var intercept = ray.At(zero);
				var mirroredIntercept = new Vector3
				{
					X = intercept.X,
					Y = intercept.Y,
					Z = -intercept.Z,
				};

				return new Intercept(
					distance: zero,
					normal: mirroredIntercept.Normalized() * ray.Direction.Length());
			})
			.ToList();
	}
}
