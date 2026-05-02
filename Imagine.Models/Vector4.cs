namespace Imagine.Models;

public readonly record struct Vector4(float X, float Y, float Z, float W)
{
	public Vector4(Vector3 vector, float w)
		: this(vector.X, vector.Y, vector.Z, w)
	{
	}

	public static explicit operator Vector3(Vector4 value) =>
		new(value.X, value.Y, value.Z);

	public readonly float Dot(Vector4 other) =>
		(X * other.X) + (Y * other.Y) + (Z * other.Z) + (W * other.W);
}
