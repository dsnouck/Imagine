namespace Imagine.Models;

public readonly record struct Vector3Spherical(float R, float Phi, float Theta)
{
	public static explicit operator Vector3(Vector3Spherical value)
	{
		(var sinPhi, var cosPhi) = float.SinCos(value.Phi);
		(var sinTheta, var cosTheta) = float.SinCos(value.Theta);

		return new(
			value.R * cosPhi * sinTheta,
			value.R * sinPhi * sinTheta,
			value.R * cosTheta);
	}
}
