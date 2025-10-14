namespace Imagine.Components;

public class Sphere(
	IVector3Component vector3Component,
	IFuncDoubleDoubleComponent funcDoubleDoubleComponent,
	ILine3Component line3Component)
	: ISceneComponent
{
	public bool Contains(Vector3 point) => vector3Component.DotProduct(point, point) <= 1D;

	public List<Intercept> Intercepts(Line3 ray)
	{
		// These are the coefficients of the quadratic equation x ↦ ax² + bx + c we want to solve.
		var a = vector3Component.DotProduct(
			ray.Direction,
			ray.Direction);
		var b = vector3Component.DotProduct(
			ray.Direction,
			ray.Origin)
			* 2D;
		var c = vector3Component.DotProduct(
			ray.Origin,
			ray.Origin)
			- 1D;

		var zeros = funcDoubleDoubleComponent.GetRealZerosOfQuadraticFunction(a, b, c);

		// TODO: When we want to enable transformations, the distance should be relative to the length of the direction vector.
		return zeros.
			Select(zero => new Intercept(
				Distance: zero,
				Normal: vector3Component.Multiply(vector3Component.Normalize(line3Component.GetPointAtDistance(ray, zero)), vector3Component.Length(ray.Direction)),
				Color: new RgbColor(1D, 0D, 0D)))
			.ToList();
	}
}
