namespace Imagine.Models;

public readonly record struct Intercept(
	float Distance,
	Vector3 Normal,
	Color Color)
{
	public Intercept(float distance, Vector3 normal)
		: this(
			  Distance: distance,
			  Normal: normal,
			  Color: Color.White)
	{
	}
}
