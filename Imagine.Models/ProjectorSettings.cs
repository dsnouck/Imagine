namespace Imagine.Models;

public readonly record struct ProjectorSettings(
	Vector3 Eye,
	Vector3 Focus,
	float HalfOpeningAngle,
	Color BackgroundColor)
{
	public static ProjectorSettings WithOpeningRadius(Vector3 eye, Vector3 focus, float openingRadius, Color backgroundColor) =>
		new(
			Eye: eye,
			Focus: focus,
			HalfOpeningAngle: float.Atan2(openingRadius, (focus - eye).Length()),
			BackgroundColor: backgroundColor);

	public static ProjectorSettings WithOpeningRadius(Vector3 eye, Vector3 focus, float openingRadius) =>
		WithOpeningRadius(
			eye: eye,
			focus: focus,
			openingRadius: openingRadius,
			backgroundColor: Color.Black);
}
