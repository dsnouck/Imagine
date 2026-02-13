namespace Imagine.Components;

public class Matrix4Component : IMatrix4Component
{
	public Matrix4 CreateRotationMatrix(Vector3 axis, double angle)
	{
		axis = axis.Normalized();
		var l = axis.X;
		var m = axis.Y;
		var n = axis.Z;
		var cosine = double.Cos(angle);
		var sine = double.Sin(angle);
		var oneMinusCosine = 1D - cosine;

		return new Matrix4
		{
			FirstRow = new Vector4
			{
				X = (l * l * oneMinusCosine) + cosine,
				Y = (m * l * oneMinusCosine) - (n * sine),
				Z = (n * l * oneMinusCosine) + (m * sine),
				W = 0D,
			},
			SecondRow = new Vector4
			{
				X = (l * m * oneMinusCosine) + (n * sine),
				Y = (m * m * oneMinusCosine) + cosine,
				Z = (n * m * oneMinusCosine) - (l * sine),
				W = 0D,
			},
			ThirdRow = new Vector4
			{
				X = (l * n * oneMinusCosine) - (m * sine),
				Y = (m * n * oneMinusCosine) + (l * sine),
				Z = (n * n * oneMinusCosine) + cosine,
				W = 0D,
			},
			FourthRow = new Vector4
			{
				X = 0D,
				Y = 0D,
				Z = 0D,
				W = 1D,
			},
		};
	}

	public Matrix4 CreateScalingMatrix(double factor)
	{
		return new Matrix4
		{
			FirstRow = new Vector4
			{
				X = factor,
				Y = 0D,
				Z = 0D,
				W = 0D,
			},
			SecondRow = new Vector4
			{
				X = 0D,
				Y = factor,
				Z = 0D,
				W = 0D,
			},
			ThirdRow = new Vector4
			{
				X = 0D,
				Y = 0D,
				Z = factor,
				W = 0D,
			},
			FourthRow = new Vector4
			{
				X = 0D,
				Y = 0D,
				Z = 0D,
				W = 1D,
			},
		};
	}

	public Matrix4 CreateTranslationMatrix(Vector3 translation)
	{
		return new Matrix4
		{
			FirstRow = new Vector4
			{
				X = 1D,
				Y = 0D,
				Z = 0D,
				W = translation.X,
			},
			SecondRow = new Vector4
			{
				X = 0D,
				Y = 1D,
				Z = 0D,
				W = translation.Y,
			},
			ThirdRow = new Vector4
			{
				X = 0D,
				Y = 0D,
				Z = 1D,
				W = translation.Z,
			},
			FourthRow = new Vector4
			{
				X = 0D,
				Y = 0D,
				Z = 0D,
				W = 1D,
			},
		};
	}

	public Vector4 Multiply(Matrix4 matrix, Vector4 vector)
	{
		return new Vector4
		{
			X = matrix.FirstRow.Dot(vector),
			Y = matrix.SecondRow.Dot(vector),
			Z = matrix.ThirdRow.Dot(vector),
			W = matrix.FourthRow.Dot(vector),
		};
	}
}
