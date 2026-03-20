namespace Imagine.Scenes;

public static class QuadraticSolver
{
	public static List<double> Solve(double a, double b, double c)
	{
		var discriminant = (b * b) - (4D * a * c);
		if (discriminant < 0D)
		{
			return new();
		}

		var squareRootOfDiscriminant = double.Sqrt(discriminant);
		var divisor = 1D / (2D * a);

		return new()
		{
			(-b - squareRootOfDiscriminant) * divisor,
			(-b + squareRootOfDiscriminant) * divisor,
		};
	}
}
