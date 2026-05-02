namespace Imagine.Models;

public readonly record struct Vector3(float X, float Y, float Z)
{
	public static readonly Vector3 Zero = new(0F, 0F, 0F);
	public static readonly Vector3 UnitX = new(1F, 0F, 0F);
	public static readonly Vector3 UnitY = new(0F, 1F, 0F);
	public static readonly Vector3 UnitZ = new(0F, 0F, 1F);

	public static explicit operator Vector3Spherical(Vector3 value) =>
		new(
			value.Length(),
			float.Atan2(value.Y, value.X).Modulo(2F * float.Pi),
			float.Acos(value.Z / value.Length()));

	public static explicit operator Vector2(Vector3 value) =>
		new(value.X, value.Y);

	public readonly Vector3 Cross(Vector3 other) =>
		new((Y * other.Z) - (Z * other.Y), (Z * other.X) - (X * other.Z), (X * other.Y) - (Y * other.X));

	public readonly float Dot(Vector3 other) =>
		(X * other.X) + (Y * other.Y) + (Z * other.Z);

	public readonly float Length() =>
		float.Sqrt(Dot(this));

	public readonly Vector3 Normalized() =>
		this / Length();

	public static Vector3 operator +(Vector3 left, Vector3 right) =>
		new(left.X + right.X, left.Y + right.Y, left.Z + right.Z);

	public static Vector3 operator -(Vector3 left, Vector3 right) =>
		new(left.X - right.X, left.Y - right.Y, left.Z - right.Z);

	public static Vector3 operator *(Vector3 left, float right) =>
		new(left.X * right, left.Y * right, left.Z * right);

	public static Vector3 operator /(Vector3 left, float right) =>
		left * (1F / right);

	public static Vector3 operator -(Vector3 value) =>
		new(-value.X, -value.Y, -value.Z);
}
