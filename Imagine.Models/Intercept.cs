namespace Imagine.Models;

public readonly record struct Intercept(
	double Distance,
	Vector3 Normal,
	ColorRgb Color)
{
	public Intercept(double distance, Vector3 normal)
		: this(
			  Distance: distance,
			  Normal: normal,
			  Color: new(1D, 1D, 1D))
	{
	}
}
