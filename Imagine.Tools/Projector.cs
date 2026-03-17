namespace Imagine.Tools;

public static class Projector
{
	public static Func<Vector2, ColorRgb> Project(IScene scene, ProjectorSettings settings)
	{
		var screen = Screen(settings);

		return point =>
		{
			var direction = (screen(point) - settings.Eye).Normalized();
			var lineOfSight = new Line3
			{
				Origin = settings.Eye,
				Direction = direction,
			};
			var intercepts = scene.Intercepts(lineOfSight)
				.Where(surfaceIntersection => surfaceIntersection.Distance > 0D)
				.OrderBy(surfaceIntersection => surfaceIntersection.Distance)
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
		// TODO: Use new() everywhere!
		var vertical = new Vector3 { X = 0D, Y = 0D, Z = 1D };
		var xVector = viewingDirection.Cross(vertical).Normalized();
		var yVector = xVector.Cross(viewingDirection).Normalized();
		var halfScreenExtent = double.Tan(settings.FieldOfView * 0.5D);
		xVector *= halfScreenExtent;
		yVector *= halfScreenExtent;
		return Plane(centerScreen, xVector, yVector);
	}

	private static Func<Vector2, Vector3> Plane(Vector3 origin, Vector3 xDirection, Vector3 yDirection) =>
		point => origin + (xDirection * point.X) + (yDirection * point.Y);
}
