namespace Imagine.Components;

public class Line3Component(IVector3Component vector3Component) : ILine3Component
{
	public Vector3 GetPointAtDistance(Line3 line, double distance) =>
		line.Origin + vector3Component.Multiply(line.Direction, distance);
}
