namespace Imagine.Components;

public interface IVector2Component
{
	double DotProduct(Vector2 multiplicand, Vector2 multiplier);

	double Length(Vector2 vector);

	Vector2 Subtract(Vector2 minuend, Vector2 subtrahend);
}
