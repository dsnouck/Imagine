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
			var direction = vector3Component.Normalize(screen(point) - settings.Eye);
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

			var intensity = Math.Abs(vector3Component.DotProduct(intercept.Normal, direction));

			return colorComponent.Multiply(intercept.Color, intensity);
		};

	}

	private Func<Vector2, Vector3> GetScreen(ProjectorSettings settings)
	{
		var viewingDirection = vector3Component.Normalize(settings.Focus - settings.Eye);
		var centerScreen = settings.Eye + viewingDirection;
		var vertical = new Vector3 { X = 0D, Y = 0D, Z = 1D };
		var xVector = vector3Component.Normalize(
			vector3Component.CrossProduct(
				viewingDirection,
				vertical));
		var yVector = vector3Component.Normalize(
				vector3Component.CrossProduct(
					xVector,
					viewingDirection));
		var halfScreenExtent = Math.Tan(settings.FieldOfView * 0.5D);
		xVector = vector3Component.Multiply(xVector, halfScreenExtent);
		yVector = vector3Component.Multiply(yVector, halfScreenExtent);
		return funcVector2Vector3Component.CreatePlane(centerScreen, xVector, yVector);
	}
}
