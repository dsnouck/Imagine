namespace Imagine.Models;

// TODO: Switch Theta and Phi?
public readonly record struct Vector3Spherical(double R, double Theta, double Phi)
{
	public static implicit operator Vector3(Vector3Spherical value)
	{
		var sinTheta = double.Sin(value.Theta);
		var cosTheta = double.Cos(value.Theta);
		var sinPhi = double.Sin(value.Phi);
		var cosPhi = double.Cos(value.Phi);

		return new(
			value.R * sinTheta * cosPhi,
			value.R * sinTheta * sinPhi,
			value.R * cosTheta);
	}
}
