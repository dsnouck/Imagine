namespace Imagine.Components;

public interface IVector3Component
{
	Vector3 CreateVector3FromSphericalCoordinates(double radius, double inclination, double azimuth);
}
