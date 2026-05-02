namespace Imagine.Scenes;

public static class QuadraticSolver
{
	public static List<float> Solve(float a, float b, float c)
	{
		var d = (b * b) - (4F * a * c);

		if (d < 0F)
		{
			return [];
		}

		var sqrtD = float.Sqrt(d);

		return
		[
			(-b - sqrtD) / (2F * a),
			(-b + sqrtD) / (2F * a),
		];
	}
}
