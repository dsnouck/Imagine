namespace Imagine.Components;

using Imagine.Models;

public class Vector2Component : IVector2Component
{
	public double DotProduct(Vector2 multiplicand, Vector2 multiplier) =>
		(multiplicand.X * multiplier.X) + (multiplicand.Y * multiplier.Y);

	public double Length(Vector2 vector) => Math.Sqrt(DotProduct(vector, vector));

	public Vector2 Subtract(Vector2 minuend, Vector2 subtrahend) =>
		new(minuend.X - subtrahend.X, minuend.Y - subtrahend.Y);
}
