namespace Imagine.Models;

public readonly record struct Matrix4(Vector4 Row0, Vector4 Row1, Vector4 Row2, Vector4 Row3)
{
	public static Matrix4 Rotation(Vector3 axis, float angle)
	{
		axis = axis.Normalized();
		var l = axis.X;
		var m = axis.Y;
		var n = axis.Z;
		var cosine = float.Cos(angle);
		var sine = float.Sin(angle);
		var oneMinusCosine = 1F - cosine;

		return new(
			new((l * l * oneMinusCosine) + cosine, (m * l * oneMinusCosine) - (n * sine), (n * l * oneMinusCosine) + (m * sine), 0F),
			new((l * m * oneMinusCosine) + (n * sine), (m * m * oneMinusCosine) + cosine, (n * m * oneMinusCosine) - (l * sine), 0F),
			new((l * n * oneMinusCosine) - (m * sine), (m * n * oneMinusCosine) + (l * sine), (n * n * oneMinusCosine) + cosine, 0F),
			new(0F, 0F, 0F, 1F));
	}

	public static Matrix4 Scaling(float factor) =>
		new(
			new(factor, 0F, 0F, 0F),
			new(0F, factor, 0F, 0F),
			new(0F, 0F, factor, 0F),
			new(0F, 0F, 0F, 1F));

	public static Matrix4 Translation(Vector3 translation) =>
		new(
			new(1F, 0F, 0F, translation.X),
			new(0F, 1F, 0F, translation.Y),
			new(0F, 0F, 1F, translation.Z),
			new(0F, 0F, 0F, 1F));

	public static Vector4 operator *(Matrix4 left, Vector4 right) =>
		new(
			left.Row0.Dot(right),
			left.Row1.Dot(right),
			left.Row2.Dot(right),
			left.Row3.Dot(right));
}
