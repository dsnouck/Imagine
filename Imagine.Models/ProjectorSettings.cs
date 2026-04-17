namespace Imagine.Models;

public readonly record struct ProjectorSettings(
	Vector3 Eye,
	Vector3 Focus,
	double HalfOpeningAngle,
	Color BackgroundColor)
{
	public static ProjectorSettings WithOpeningRadius(Vector3 eye, Vector3 focus, double openingRadius, Color backgroundColor) =>
		new(
			Eye: eye,
			Focus: focus,
			HalfOpeningAngle: double.Atan2(openingRadius, (focus - eye).Length()),
			BackgroundColor: backgroundColor);

	public static ProjectorSettings WithOpeningRadius(Vector3 eye, Vector3 focus, double openingRadius) =>
		WithOpeningRadius(
			eye: eye,
			focus: focus,
			openingRadius: openingRadius,
			backgroundColor: Color.Black);
}
