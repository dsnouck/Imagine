namespace Imagine.Components;

public interface ILineComponent
{
	Func<double, double> LineThrough(Vector2 firstPoint, Vector2 secondPoint);
}
