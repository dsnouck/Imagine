namespace Imagine.Components;

public interface IMatrix4Component
{
	Matrix4 CreateRotationMatrix(Vector3 axis, double angle);

	Matrix4 CreateScalingMatrix(double factor);

	Matrix4 CreateTranslationMatrix(Vector3 translation);

	Vector4 Multiply(Matrix4 matrix, Vector4 vector);
}
