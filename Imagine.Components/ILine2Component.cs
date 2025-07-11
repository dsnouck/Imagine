namespace Imagine.Components;

public interface ILine2Component
{
	Func<double, double> Line(Vector2 from, Vector2 to);
}
