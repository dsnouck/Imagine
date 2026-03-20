namespace Imagine.Models;

public readonly record struct Vector3Spherical(double R, double Phi, double Theta)
{
	public static explicit operator Vector3(Vector3Spherical value)
	{
		var sinPhi = double.Sin(value.Phi);
		var cosPhi = double.Cos(value.Phi);
		var sinTheta = double.Sin(value.Theta);
		var cosTheta = double.Cos(value.Theta);

		return new(
			value.R * cosPhi * sinTheta,
			value.R * sinPhi * sinTheta,
			value.R * cosTheta);
	}
}
