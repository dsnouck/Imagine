namespace Imagine.Scenes;

internal class Cone : IScene
{
	public bool Contains(Vector3 point)
	{
		// TODO: Introduce a method to mirror a point across the plane z = 0.
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
		var distances = QuadraticSolver.Solve(
			ray.Direction.Dot(mirroredRay.Direction),
			ray.Direction.Dot(mirroredRay.Origin) * 2D,
			ray.Origin.Dot(mirroredRay.Origin));

		return distances.
			Select(distance =>
			{
				var intercept = ray.At(distance);
				var mirroredIntercept = new Vector3
				{
					X = intercept.X,
					Y = intercept.Y,
					Z = -intercept.Z,
				};

				return new Intercept(
					distance: distance,
					normal: mirroredIntercept.Normalized() * ray.Direction.Length());
			})
			.ToList();
	}
}
