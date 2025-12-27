namespace Imagine.Models;

public readonly record struct ProjectorSettings(
	Vector3 Eye,
	Vector3 Focus,
	// TODO: Rename? Use width/something else instead of angle?
	double FieldOfView,
	ColorRgb BackgroundColor);
