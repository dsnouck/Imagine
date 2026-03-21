namespace Imagine.Models;

public readonly record struct Vector2(double X, double Y)
{
	public readonly double Dot(Vector2 other) =>
		(X * other.X) + (Y * other.Y);

	public readonly double Length() =>
		double.Sqrt(Dot(this));

	public static Vector2 operator -(Vector2 left, Vector2 right) =>
		new(left.X - right.X, left.Y - right.Y);
}
