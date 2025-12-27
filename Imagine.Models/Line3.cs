namespace Imagine.Models;

public readonly record struct Line3(Vector3 Origin, Vector3 Direction)
{
	public Vector3 At(double distance) =>
		Origin + (Direction * distance);
}
