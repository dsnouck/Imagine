namespace Imagine.Components;

public class FuncDoubleDoubleComponent : IFuncDoubleDoubleComponent
{
	public List<double> GetRealZerosOfQuadraticFunction(double a, double b, double c)
	{
		// TODO: Do we really need this method?
		var discriminant = (b * b) - (4D * a * c);
		if (discriminant < 0D)
		{
			return new List<double>();
		}

		var squareRootOfDiscriminant = double.Sqrt(discriminant);
		var divisor = 1D / (2D * a);

		return new List<double>
			{
				(-b - squareRootOfDiscriminant) * divisor,
				(-b + squareRootOfDiscriminant) * divisor,
			};
	}
}
