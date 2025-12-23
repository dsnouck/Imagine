namespace Imagine.Models;

public readonly record struct Vector3(double X, double Y, double Z)
{
	// TODO: Correctly order methods and operators.
	// TODO: Rename methods.
	public Vector3 CrossProduct(Vector3 other) =>
		new((Y * other.Z) - (Z * other.Y), (Z * other.X) - (X * other.Z), (X * other.Y) - (Y * other.X));

	public double DotProduct(Vector3 other) =>
		(X * other.X) + (Y * other.Y) + (Z * other.Z);

	public double Length() => double.Sqrt(DotProduct(this));

	// TODO: Check names of methods and parameters.
	public Vector3 Normalized() => this / Length();

	public static Vector3 operator +(Vector3 left, Vector3 right) =>
		new(left.X + right.X, left.Y + right.Y, left.Z + right.Z);

	// TODO: Use operator + for this implementation?
	public static Vector3 operator -(Vector3 left, Vector3 right) =>
		new(left.X - right.X, left.Y - right.Y, left.Z - right.Z);

	public static Vector3 operator *(Vector3 left, double right) =>
		new(left.X * right, left.Y * right, left.Z * right);

	// TODO: Use operator * or not?
	public static Vector3 operator /(Vector3 left, double right) =>
		left * (1D / right);

	public static explicit operator Vector2(Vector3 vector) => new(vector.X, vector.Y);
}
