namespace Imagine.Models;

public readonly record struct Vector3(double X, double Y, double Z)
{
	public static readonly Vector3 Zero = new(0D, 0D, 0D);
	public static readonly Vector3 UnitX = new(1D, 0D, 0D);
	public static readonly Vector3 UnitY = new(0D, 1D, 0D);
	public static readonly Vector3 UnitZ = new(0D, 0D, 1D);

	public static explicit operator Vector3Spherical(Vector3 value) =>
		new(
			R: value.Length(),
			Phi: double.Atan2(value.Y, value.X).Modulo(2D * double.Pi),
			Theta: double.Acos(value.Z / value.Length()));

	public static explicit operator Vector2(Vector3 value) =>
		new(value.X, value.Y);

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
}
