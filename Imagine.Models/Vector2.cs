namespace Imagine.Models;

public readonly record struct Vector2(float X, float Y)
{
	public readonly float Dot(Vector2 other) =>
		(X * other.X) + (Y * other.Y);

	public readonly float Length() =>
		float.Sqrt(Dot(this));

	public static Vector2 operator -(Vector2 left, Vector2 right) =>
		new(left.X - right.X, left.Y - right.Y);
}
