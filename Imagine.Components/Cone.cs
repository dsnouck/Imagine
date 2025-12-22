namespace Imagine.Components;

public class Cone(
	IFuncDoubleDoubleComponent funcDoubleDoubleComponent,
	ILine3Component line3Component,
	IVector3Component vector3Component)
	: ISceneComponent
{
	public bool Contains(Vector3 point)
	{
		var mirroredPoint = new Vector3
		{
			X = point.X,
			Y = point.Y,
			Z = -point.Z,
		};

		return vector3Component.DotProduct(
			point,
			mirroredPoint)
			< 0D;
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
		var a = vector3Component.DotProduct(
			ray.Direction,
			mirroredLineOfSight.Direction);
		var b = vector3Component.DotProduct(
			ray.Direction,
			mirroredLineOfSight.Origin)
			* 2D;
		var c = vector3Component.DotProduct(
			ray.Origin,
			mirroredLineOfSight.Origin);

		var zeros = funcDoubleDoubleComponent.GetRealZerosOfQuadraticFunction(a, b, c);

		return zeros.
			Select(zero =>
			{
				var surfaceIntersection = line3Component.GetPointAtDistance(ray, zero);
				var mirroredSurfaceIntersection = new Vector3
				{
					X = surfaceIntersection.X,
					Y = surfaceIntersection.Y,
					Z = -surfaceIntersection.Z,
				};

				return new Intercept
				{
					Distance = zero,
					Normal = vector3Component.Multiply(
							vector3Component.Normalize(mirroredSurfaceIntersection),
							vector3Component.Length(ray.Direction)),
					Color = new RgbColor(1D, 1D, 1D),
				};
			})
			.ToList();
	}
}
