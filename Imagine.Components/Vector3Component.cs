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

	public Vector3 CrossProduct(Vector3 vector, Vector3 otherVector) =>
		new(
			(vector.Y * otherVector.Z) - (vector.Z * otherVector.Y),
			(vector.Z * otherVector.X) - (vector.X * otherVector.Z),
			(vector.X * otherVector.Y) - (vector.Y * otherVector.X));

	// TODO: Check names of methods and parameters.
	public Vector3 Divide(Vector3 vector, double divisor) =>
		Multiply(vector, 1D / divisor);

	public double DotProduct(Vector3 vector, Vector3 otherVector) =>
		(vector.X * otherVector.X) + (vector.Y * otherVector.Y) + (vector.Z * otherVector.Z);

	public double Length(Vector3 vector) => Math.Sqrt(DotProduct(vector, vector));

	public Vector3 Multiply(Vector3 vector, double factor) =>
		new(factor * vector.X, factor * vector.Y, factor * vector.Z);

	public Vector3 Normalize(Vector3 vector) => Divide(vector, Length(vector));

	public Vector2 ToVector2(Vector3 vector) => new(vector.X, vector.Y);
}
