namespace Imagine.Models;

public readonly record struct ProjectorSettings(
	Vector3 Eye,
	Vector3 Focus,
	double FieldOfView,
	ColorRgb BackgroundColor)
{
	public ProjectorSettings(Vector3 eye, Vector3 focus, double fieldOfView)
		: this(
			  Eye: eye,
			  Focus: focus,
			  FieldOfView: fieldOfView,
			  BackgroundColor: new(0D, 0D, 0D))
	{
	}
}
