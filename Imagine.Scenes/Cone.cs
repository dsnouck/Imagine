namespace Imagine.Scenes;

internal class Cone : IScene
{
	public bool Contains(Vector3 point) => point.Dot(Mirrored(point)) < 0D;

	public List<Intercept> Intercepts(Line3 ray)
	{
		var mirroredRay = new Line3
		{
			Origin = Mirrored(ray.Origin),
			Direction = Mirrored(ray.Direction),
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
				var mirroredIntercept = Mirrored(intercept);

				return new Intercept(
					distance: distance,
					normal: mirroredIntercept.Normalized() * ray.Direction.Length());
			})
			.ToList();
	}

	private static Vector3 Mirrored(Vector3 point) => new(point.X, point.Y, -point.Z);

}
