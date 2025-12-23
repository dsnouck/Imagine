namespace Imagine.Models;

public readonly record struct Vector3(double X, double Y, double Z)
{
	// TODO: Correctly order methods and operators.
	public static Vector3 operator +(Vector3 left, Vector3 right) =>
		new(left.X + right.X, left.Y + right.Y, left.Z + right.Z);

	public static Vector3 operator -(Vector3 left, Vector3 right) =>
		new(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
}
