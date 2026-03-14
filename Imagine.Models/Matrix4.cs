namespace Imagine.Models;

// TODO: Rename properties to something like Row0?
public readonly record struct Matrix4(Vector4 FirstRow, Vector4 SecondRow, Vector4 ThirdRow, Vector4 FourthRow)
{
	public static Matrix4 Rotation(Vector3 axis, double angle)
	{
		axis = axis.Normalized();
		var l = axis.X;
		var m = axis.Y;
		var n = axis.Z;
		var cosine = double.Cos(angle);
		var sine = double.Sin(angle);
		var oneMinusCosine = 1D - cosine;

		// TODO: Using just new instead of new Matrix4 and new Vector4 produces a warning!
		return new Matrix4(
			new Vector4(
				(l * l * oneMinusCosine) + cosine,
				(m * l * oneMinusCosine) - (n * sine),
				(n * l * oneMinusCosine) + (m * sine),
				0D),
			new Vector4(
				(l * m * oneMinusCosine) + (n * sine),
				(m * m * oneMinusCosine) + cosine,
				(n * m * oneMinusCosine) - (l * sine),
				0D),
			new Vector4(
				(l * n * oneMinusCosine) - (m * sine),
				(m * n * oneMinusCosine) + (l * sine),
				(n * n * oneMinusCosine) + cosine,
				0D),
			new Vector4(
				0D,
				0D,
				0D,
				1D));
	}

	public static Matrix4 Scaling(double factor) =>
		new(
			new(factor, 0D, 0D, 0D),
			new(0D, factor, 0D, 0D),
			new(0D, 0D, factor, 0D),
			new(0D, 0D, 0D, 1D));

	public static Matrix4 Translation(Vector3 translation) =>
		new(
			new(1D, 0D, 0D, translation.X),
			new(0D, 1D, 0D, translation.Y),
			new(0D, 0D, 1D, translation.Z),
			new(0D, 0D, 0D, 1D));

	public static Vector4 operator *(Matrix4 left, Vector4 right) =>
		new(
			left.FirstRow.Dot(right),
			left.SecondRow.Dot(right),
			left.ThirdRow.Dot(right),
			left.FourthRow.Dot(right));
}
