namespace Imagine.Models;

public readonly record struct Vector3(double X, double Y, double Z)
{
	public readonly Vector3 Cross(Vector3 other) =>
		new((Y * other.Z) - (Z * other.Y), (Z * other.X) - (X * other.Z), (X * other.Y) - (Y * other.X));

	public readonly double Dot(Vector3 other) =>
		(X * other.X) + (Y * other.Y) + (Z * other.Z);

	public readonly double Length() =>
		double.Sqrt(Dot(this));

	public readonly Vector3 Normalized() =>
		this / Length();

	public static Vector3 operator +(Vector3 left, Vector3 right) =>
		new(left.X + right.X, left.Y + right.Y, left.Z + right.Z);

	public static Vector3 operator -(Vector3 left, Vector3 right) =>
		new(left.X - right.X, left.Y - right.Y, left.Z - right.Z);

	public static Vector3 operator *(Vector3 left, double right) =>
		new(left.X * right, left.Y * right, left.Z * right);

	public static Vector3 operator /(Vector3 left, double right) =>
		left * (1D / right);

	public static Vector3 operator -(Vector3 value) =>
		new(-value.X, -value.Y, -value.Z);

	// TODO: Make cast operators explicit.
	// TODO: Cast operators or constructors?
	public static implicit operator Vector2(Vector3 value) =>
		new(value.X, value.Y);
}
