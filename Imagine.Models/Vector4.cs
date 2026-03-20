namespace Imagine.Models;

public readonly record struct Vector4(double X, double Y, double Z, double W)
{
	public Vector4(Vector3 vector, double w)
		: this(vector.X, vector.Y, vector.Z, w)
	{
	}

	public static explicit operator Vector3(Vector4 value) => new(value.X, value.Y, value.Z);

	public readonly double Dot(Vector4 other) =>
		(X * other.X) + (Y * other.Y) + (Z * other.Z) + (W * other.W);
}
