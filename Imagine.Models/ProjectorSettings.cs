namespace Imagine.Models;

public readonly record struct ProjectorSettings(
	Vector3 Eye,
	Vector3 Focus,
	double HalfOpeningAngle,
	Color BackgroundColor)
{
	public ProjectorSettings(Vector3 eye, Vector3 focus, double halfOpeningAngle)
		: this(
			  Eye: eye,
			  Focus: focus,
			  HalfOpeningAngle: halfOpeningAngle,
			  BackgroundColor: Color.Black)
	{
	}
}
