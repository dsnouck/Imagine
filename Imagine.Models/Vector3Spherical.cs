namespace Imagine.Models;

public readonly record struct Vector3Spherical(double R, double Phi, double Theta)
{
	public static explicit operator Vector3(Vector3Spherical value)
	{
		(var sinPhi, var cosPhi) = double.SinCos(value.Phi);
		(var sinTheta, var cosTheta) = double.SinCos(value.Theta);

		return new(
			value.R * cosPhi * sinTheta,
			value.R * sinPhi * sinTheta,
			value.R * cosTheta);
	}
}
