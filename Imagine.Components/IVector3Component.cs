namespace Imagine.Components;

public interface IVector3Component
{
	Vector3 CreateVector3FromSphericalCoordinates(double radius, double inclination, double azimuth);

	Vector3 Divide(Vector3 vector, double divisor);

	double Length(Vector3 vector);

	Vector3 Multiply(Vector3 vector, double factor);

	Vector3 Normalize(Vector3 vector);

	// TODO: Rename arguments.
	Vector2 ToVector2(Vector3 vector);
}
