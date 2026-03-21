namespace Imagine.Tools;

public static class Projector
{
	public static Func<Vector2, ColorRgb> Project(IScene scene, ProjectorSettings settings)
	{
		var screen = Screen(settings);

		return point =>
		{
			var direction = (screen(point) - settings.Eye).Normalized();

			var ray = new Line3(
				Origin: settings.Eye,
				Direction: direction);

			var intercepts = scene.Intercepts(ray)
				.Where(intercept => intercept.Distance > 0D)
				.OrderBy(intercept => intercept.Distance)
				.ToList();

			if (!intercepts.Any())
			{
				return settings.BackgroundColor;
			}

			var intercept = intercepts.First();
			var intensity = double.Abs(intercept.Normal.Dot(direction));

			return intercept.Color * intensity;
		};
	}

	private static Func<Vector2, Vector3> Screen(ProjectorSettings settings)
	{
		var viewingDirection = (settings.Focus - settings.Eye).Normalized();
		var centerScreen = settings.Eye + viewingDirection;
		var vertical = new Vector3(0D, 0D, 1D);
		var xVector = viewingDirection.Cross(vertical).Normalized();
		var yVector = xVector.Cross(viewingDirection).Normalized();
		var halfScreenExtent = double.Tan(settings.FieldOfView * 0.5D);
		xVector *= halfScreenExtent;
		yVector *= halfScreenExtent;

		return Screen(centerScreen, xVector, yVector);
	}

	private static Func<Vector2, Vector3> Screen(Vector3 origin, Vector3 xDirection, Vector3 yDirection) =>
		point => origin + (xDirection * point.X) + (yDirection * point.Y);
}
