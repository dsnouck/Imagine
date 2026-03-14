namespace Imagine.Models;

public readonly record struct Intercept(double Distance, Vector3 Normal, ColorRgb Color)
{
	public Intercept(double distance, Vector3 normal)
		: this(distance, normal, new ColorRgb(1D, 1D, 1D))
	{
	}
}
