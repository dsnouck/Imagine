namespace Imagine.Tools;

public static class Projector
{
	public static Func<Vector2, Color> Project(IScene scene, ProjectorSettings settings)
	{
		var bundle = Bundle(settings);

		return point =>
		{
			var ray = bundle(point);

			var intercepts = scene.Intercepts(ray)
				.Where(intercept => intercept.Distance > 0F)
				.OrderBy(intercept => intercept.Distance)
				.ToList();

			if (!intercepts.Any())
			{
				return settings.BackgroundColor;
			}

			var intercept = intercepts.First();
			var intensity = float.Abs(intercept.Normal.Dot(ray.Direction));

			return intercept.Color * intensity;
		};
	}

	private static Func<Vector2, Line3> Bundle(ProjectorSettings settings)
	{
		var screen = Screen(settings);

		return point =>
			new(
				Origin: settings.Eye,
				Direction: (screen(point) - settings.Eye).Normalized());
	}

	private static Func<Vector2, Vector3> Screen(ProjectorSettings settings)
	{
		var viewingDirection = (settings.Focus - settings.Eye).Normalized();
		var centerScreen = settings.Eye + viewingDirection;
		var horizontalViewingDirection = new Vector3(viewingDirection.X, viewingDirection.Y, 0F);
		var horizontalLength = horizontalViewingDirection.Length();
		horizontalViewingDirection /= horizontalLength;
		var xVector = new Vector3(
			horizontalViewingDirection.Y,
			-horizontalViewingDirection.X,
			0F);
		var yVector = new Vector3(
			-horizontalViewingDirection.X * viewingDirection.Z,
			-horizontalViewingDirection.Y * viewingDirection.Z,
			horizontalLength);
		var halfScreenExtent = float.Tan(settings.HalfOpeningAngle);
		xVector *= halfScreenExtent;
		yVector *= halfScreenExtent;

		return Screen(centerScreen, xVector, yVector);
	}

	private static Func<Vector2, Vector3> Screen(Vector3 origin, Vector3 xDirection, Vector3 yDirection) =>
		point => origin + (xDirection * point.X) + (yDirection * point.Y);
}
