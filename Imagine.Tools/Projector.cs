namespace Imagine.Tools;

using Color = Models.Color;

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
		var xVector = viewingDirection.Cross(Vector3.UnitZ).Normalized();
		var yVector = xVector.Cross(viewingDirection).Normalized();
		var halfScreenExtent = float.Tan(settings.HalfOpeningAngle);
		xVector *= halfScreenExtent;
		yVector *= halfScreenExtent;

		return Screen(centerScreen, xVector, yVector);
	}

	private static Func<Vector2, Vector3> Screen(Vector3 origin, Vector3 xDirection, Vector3 yDirection) =>
		point => origin + (xDirection * point.X) + (yDirection * point.Y);
}
