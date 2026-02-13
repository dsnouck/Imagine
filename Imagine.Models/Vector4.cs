namespace Imagine.Models;

public readonly record struct Vector4(double X, double Y, double Z, double W)
{
	public readonly double Dot(Vector4 other) =>
		(X * other.X) + (Y * other.Y) + (Z * other.Z) + (W * other.W);
}
