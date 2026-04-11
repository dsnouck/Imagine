namespace Imagine.Models;

public readonly record struct ProjectorSettings(
	Vector3 Eye,
	Vector3 Focus,
	double FieldOfView,
	Color BackgroundColor)
{
	public ProjectorSettings(Vector3 eye, Vector3 focus, double fieldOfView)
		: this(
			  Eye: eye,
			  Focus: focus,
			  FieldOfView: fieldOfView,
			  BackgroundColor: Color.Black)
	{
	}
}
