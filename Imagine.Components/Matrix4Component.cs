namespace Imagine.Components;

public class Matrix4Component : IMatrix4Component
{
	private readonly IVector3Component vector3Component;
	private readonly IVector4Component vector4Component;

	public Matrix4Component(
		IVector3Component vector3Component,
		IVector4Component vector4Component)
	{
		this.vector3Component = vector3Component;
		this.vector4Component = vector4Component;
	}

	public Matrix4 CreateRotationMatrix(Vector3 axis, double angle)
	{
		axis = vector3Component.Normalize(axis);
		var l = axis.X;
		var m = axis.Y;
		var n = axis.Z;
		var cosine = Math.Cos(angle);
		var sine = Math.Sin(angle);
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
			X = vector4Component.DotProduct(matrix.FirstRow, vector),
			Y = vector4Component.DotProduct(matrix.SecondRow, vector),
			Z = vector4Component.DotProduct(matrix.ThirdRow, vector),
			W = vector4Component.DotProduct(matrix.FourthRow, vector),
		};
	}
}
