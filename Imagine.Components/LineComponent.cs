namespace Imagine.Components;

public class LineComponent : ILineComponent
{
	public Func<double, double> LineThrough(Vector2 firstPoint, Vector2 secondPoint)
	{
		var slope = (secondPoint.Y - firstPoint.Y) / (secondPoint.X - firstPoint.X);
		var yIntercept = ((firstPoint.Y * secondPoint.X) - (firstPoint.X * secondPoint.Y)) / (secondPoint.X - firstPoint.X);

		return x => (slope * x) + yIntercept;
	}
}
