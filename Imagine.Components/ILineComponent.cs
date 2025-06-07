namespace Imagine.Components;

public interface ILineComponent
{
	Func<double, double> Line(Vector2 from, Vector2 to);
}
