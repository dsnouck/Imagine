namespace Imagine.Components;

public class Vector3Component : IVector3Component
{
	public Vector2 ToVector2(Vector3 vector) => new(vector.X, vector.Y);
}
