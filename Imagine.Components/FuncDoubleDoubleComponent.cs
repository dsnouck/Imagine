namespace Imagine.Components;

public class FuncDoubleDoubleComponent : IFuncDoubleDoubleComponent
{
	public Func<double, double> CreateLineThrough(Vector2 point, Vector2 otherPoint)
	{
		var slope =
			(otherPoint.Y - point.Y)
			/ (otherPoint.X - point.X);
		var yIntercept =
			((point.Y * otherPoint.X) - (point.X * otherPoint.Y))
			/ (otherPoint.X - point.X);

		return x => (x * slope) + yIntercept;
	}

	public List<double> GetRealZerosOfQuadraticFunction(double a, double b, double c)
	{
		// TODO: Do we really need this method?
		var discriminant = (b * b) - (4D * a * c);
		if (discriminant < 0D)
		{
			return new List<double>();
		}

		var squareRootOfDiscriminant = Math.Sqrt(discriminant);
		var divisor = 1D / (2D * a);

		return new List<double>
			{
				(-b - squareRootOfDiscriminant) * divisor,
				(-b + squareRootOfDiscriminant) * divisor,
			};
	}
}
