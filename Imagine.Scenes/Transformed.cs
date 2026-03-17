namespace Imagine.Scenes;

// TODO: Rename to scene, forward, backward?
internal class Transformed(IScene scene, Matrix4 forward, Matrix4 backward) : IScene
{
	public bool Contains(Vector3 point) => scene.Contains(BackwardPoint(point));

	public List<Intercept> Intercepts(Line3 ray)
	{
		var backwardRay = new Line3
		{
			Origin = BackwardPoint(ray.Origin),
			Direction = BackwardDirection(ray.Direction),
		};

		return scene.Intercepts(backwardRay)
			.Select(intercept =>
				new Intercept(
					Distance: intercept.Distance,
					Normal: ForwardDirection(intercept.Normal),
					Color: intercept.Color))
			.ToList();
	}

	private Vector3 BackwardDirection(Vector3 direction)
	{
		var direction4 = new Vector4
		{
			X = direction.X,
			Y = direction.Y,
			Z = direction.Z,
			W = 0D,
		};

		var backwardDirection4 = backward * direction4;

		return new Vector3
		{
			X = backwardDirection4.X,
			Y = backwardDirection4.Y,
			Z = backwardDirection4.Z,
		};
	}

	private Vector3 BackwardPoint(Vector3 point)
	{
		var point4 = new Vector4
		{
			X = point.X,
			Y = point.Y,
			Z = point.Z,
			W = 1D,
		};

		var backwardPoint4 = backward * point4;

		return new Vector3
		{
			X = backwardPoint4.X,
			Y = backwardPoint4.Y,
			Z = backwardPoint4.Z,
		};
	}

	private Vector3 ForwardDirection(Vector3 direction)
	{
		var direction4 = new Vector4
		{
			X = direction.X,
			Y = direction.Y,
			Z = direction.Z,
			W = 0D,
		};

		var forwardDirection4 = forward * direction4;

		return new Vector3
		{
			X = forwardDirection4.X,
			Y = forwardDirection4.Y,
			Z = forwardDirection4.Z,
		};
	}
}
