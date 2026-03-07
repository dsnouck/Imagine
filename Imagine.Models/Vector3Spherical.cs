namespace Imagine.Models;

// TODO: Switch Theta and Phi?
public readonly record struct Vector3Spherical(double R, double Theta, double Phi)
{
	public static implicit operator Vector3(Vector3Spherical vector)
	{
		var sinTheta = double.Sin(vector.Theta);
		var cosTheta = double.Cos(vector.Theta);
		var sinPhi = double.Sin(vector.Phi);
		var cosPhi = double.Cos(vector.Phi);

		return new(
			vector.R * sinTheta * cosPhi,
			vector.R * sinTheta * sinPhi,
			vector.R * cosTheta);
	}
}
