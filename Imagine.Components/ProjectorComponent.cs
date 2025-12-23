namespace Imagine.Components;

// TODO: Cleanup dependencies.
public class ProjectorComponent(
	IColorComponent colorComponent,
	IVector3Component vector3Component,
	IFuncVector2Vector3Component funcVector2Vector3Component)
	: IProjectorComponent
{
	public Func<Vector2, RgbColor> Project(ISceneComponent scene, ProjectorSettings settings)
	{
		// TODO: Refactor. Introduce GetRays or similar method.
		var screen = GetScreen(settings);

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

			var intensity = Math.Abs(intercept.Normal.DotProduct(direction));

			return colorComponent.Multiply(intercept.Color, intensity);
		};

	}

	private Func<Vector2, Vector3> GetScreen(ProjectorSettings settings)
	{
		var viewingDirection = (settings.Focus - settings.Eye).Normalized();
		var centerScreen = settings.Eye + viewingDirection;
		var vertical = new Vector3 { X = 0D, Y = 0D, Z = 1D };
		var xVector = viewingDirection.CrossProduct(vertical).Normalized();
		var yVector = xVector.CrossProduct(viewingDirection).Normalized();
		var halfScreenExtent = Math.Tan(settings.FieldOfView * 0.5D);
		xVector *= halfScreenExtent;
		yVector *= halfScreenExtent;
		return funcVector2Vector3Component.CreatePlane(centerScreen, xVector, yVector);
	}
}
