namespace Imagine.Scenes;

public static class QuadraticSolver
{
	public static List<double> Solve(double a, double b, double c)
	{
		var d = (b * b) - (4D * a * c);

		if (d < 0D)
		{
			return [];
		}

		var sqrtD = double.Sqrt(d);

		return
		[
			(-b - sqrtD) / (2D * a),
			(-b + sqrtD) / (2D * a),
		];
	}
}
