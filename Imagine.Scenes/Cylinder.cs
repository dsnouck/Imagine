namespace Imagine.Scenes;

internal class Cylinder(double radius) : IScene
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

		return horizontalPoint.Dot(horizontalPoint) <= radius * radius;
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

		var distances = QuadraticSolver.Solve(
			horizontalRay.Direction.Dot(horizontalRay.Direction),
			horizontalRay.Direction.Dot(horizontalRay.Origin) * 2D,
			horizontalRay.Origin.Dot(horizontalRay.Origin) - (radius * radius));

		return distances
			.Select(distance =>
			{
				var intercept = ray.At(distance);
				var horizontalIntercept = new Vector3
				{
					X = intercept.X,
					Y = intercept.Y,
					Z = 0D,
				};

				return new Intercept(
					distance: distance,
					normal: horizontalIntercept.Normalized() * ray.Direction.Length());
			})
			.ToList();
	}
}
