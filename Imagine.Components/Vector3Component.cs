namespace Imagine.Components;

public class Vector3Component : IVector3Component
{
	// TODO: Define Vector3Spherical.
	public Vector3 CreateVector3FromSphericalCoordinates(double radius, double inclination, double azimuth)
	{
		var sineOfInclination = Math.Sin(inclination);
		var cosineOfInclination = Math.Cos(inclination);
		var sineOfAzimuth = Math.Sin(azimuth);
		var cosineOfAzimuth = Math.Cos(azimuth);

		return new Vector3
		{
			X = radius * sineOfInclination * cosineOfAzimuth,
			Y = radius * sineOfInclination * sineOfAzimuth,
			Z = radius * cosineOfInclination,
		};
	}

	// TODO: Check names of methods and parameters.
	public Vector3 Normalize(Vector3 vector) => vector / vector.Length();

	public Vector2 ToVector2(Vector3 vector) => new(vector.X, vector.Y);
}
