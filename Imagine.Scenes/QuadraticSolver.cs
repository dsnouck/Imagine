namespace Imagine.Scenes;

public static class QuadraticSolver
{
	public static List<double> Solve(double a, double b, double c)
	{
		var d = (b * b) - (4D * a * c);

		if (d < 0D)
		{
			return new();
		}

		var sqrtD = double.Sqrt(d);

		return new()
		{
			(-b - sqrtD) / (2D * a),
			(-b + sqrtD) / (2D * a),
		};
	}
}
