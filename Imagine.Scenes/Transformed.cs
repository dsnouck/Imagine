namespace Imagine.Scenes;

// TODO: Rename to scene, forward, backward?
internal class Transformed(IScene scene, Matrix4 transformation, Matrix4 backwardTransformation) : IScene
{
	public bool Contains(Vector3 point) => scene.Contains(TransformedBackPoint(point));

	public List<Intercept> Intercepts(Line3 ray)
	{
		// TODO Rename all lineOfSight to ray!
		var transformedLineOfSight = new Line3
		{
			Origin = TransformedBackPoint(ray.Origin),
			Direction = TransformedBackDirection(ray.Direction),
		};

		return scene.Intercepts(transformedLineOfSight)
			.Select(intercept =>
				new Intercept(
					Distance: intercept.Distance,
					Normal: TransformedDirection(intercept.Normal),
					Color: intercept.Color))
			.ToList();
	}

	private Vector3 TransformedDirection(Vector3 direction)
	{
		var direction4 = new Vector4
		{
			X = direction.X,
			Y = direction.Y,
			Z = direction.Z,
			W = 0D,
		};
		var transformedDirection4 = transformation * direction4;

		return new Vector3
		{
			X = transformedDirection4.X,
			Y = transformedDirection4.Y,
			Z = transformedDirection4.Z,
		};
	}

	private Vector3 TransformedBackDirection(Vector3 direction)
	{
		var direction4 = new Vector4
		{
			X = direction.X,
			Y = direction.Y,
			Z = direction.Z,
			W = 0D,
		};
		var transformedDirection4 = backwardTransformation * direction4;

		return new Vector3
		{
			X = transformedDirection4.X,
			Y = transformedDirection4.Y,
			Z = transformedDirection4.Z,
		};
	}

	private Vector3 TransformedBackPoint(Vector3 point)
	{
		var point4 = new Vector4
		{
			X = point.X,
			Y = point.Y,
			Z = point.Z,
			W = 1D,
		};
		var transformedPoint4 = backwardTransformation * point4;

		return new Vector3
		{
			X = transformedPoint4.X,
			Y = transformedPoint4.Y,
			Z = transformedPoint4.Z,
		};
	}
}
