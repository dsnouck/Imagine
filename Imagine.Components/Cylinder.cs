namespace Imagine.Components;

public class Cylinder(
	IFuncDoubleDoubleComponent funcDoubleDoubleComponent,
	ILine3Component line3Component,
	IVector3Component vector3Component)
	: ISceneComponent
{
	// TODO: Make radius a property.
	public bool Contains(Vector3 point)
	{
		var horizontalPoint = new Vector3
		{
			X = point.X,
			Y = point.Y,
			Z = 0D,
		};

		// TODO: Use Length?
		return horizontalPoint.DotProduct(horizontalPoint) <= 1D;
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
		var a = horizontalLineOfSight.Direction.DotProduct(horizontalLineOfSight.Direction);
		var b = horizontalLineOfSight.Direction.DotProduct(horizontalLineOfSight.Origin) * 2D;
		var c = horizontalLineOfSight.Origin.DotProduct(horizontalLineOfSight.Origin) - 1D;

		var zeros = funcDoubleDoubleComponent.GetRealZerosOfQuadraticFunction(a, b, c);

		return zeros
			.Select(zero =>
			{
				var surfaceIntersection = line3Component.GetPointAtDistance(ray, zero);
				var horizontalSurfaceIntersection = new Vector3
				{
					X = surfaceIntersection.X,
					Y = surfaceIntersection.Y,
					Z = 0D,
				};

				return new Intercept
				{
					Distance = zero,
					Normal = vector3Component.Normalize(horizontalSurfaceIntersection) *
						vector3Component.Length(ray.Direction),
					Color = new RgbColor(1D, 1D, 1D),
				};
			})
			.ToList();
	}
}
