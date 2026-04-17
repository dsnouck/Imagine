namespace Imagine.Models;

public readonly record struct Intercept(
	double Distance,
	Vector3 Normal,
	Color Color)
{
	public Intercept(double distance, Vector3 normal)
		: this(
			  Distance: distance,
			  Normal: normal,
			  Color: Color.White)
	{
	}
}
