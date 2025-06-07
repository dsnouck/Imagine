namespace Imagine.Components;

public class LineComponent : ILineComponent
{
	public Func<double, double> Line(Vector2 from, Vector2 to)
	{
		var slope = (to.Y - from.Y) / (to.X - from.X);
		var intercept = ((from.Y * to.X) - (from.X * to.Y)) / (to.X - from.X);

		return x => (slope * x) + intercept;
	}
}
