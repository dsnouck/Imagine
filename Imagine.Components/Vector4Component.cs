namespace Imagine.Components;

public class Vector4Component : IVector4Component
{
	public double DotProduct(Vector4 vector, Vector4 otherVector)
	{
		return
			(vector.X * otherVector.X) +
			(vector.Y * otherVector.Y) +
			(vector.Z * otherVector.Z) +
			(vector.W * otherVector.W);
	}
}
