namespace Imagine.Components;

public class Intersection(
	ISceneComponent scene,
	ISceneComponent otherScene,
	ILine3Component line3Component)
	: ISceneComponent
{
	public bool Contains(Vector3 point) => scene.Contains(point) && otherScene.Contains(point);

	public List<Intercept> Intercepts(Line3 ray)
	{
		var allSurfaceIntersections = new List<Intercept>();

		var sceneSurfaceIntersections = scene.Intercepts(ray);
		foreach (var surfaceIntersection in sceneSurfaceIntersections)
		{
			var point = line3Component.GetPointAtDistance(ray, surfaceIntersection.Distance);
			if (otherScene.Contains(point))
			{
				allSurfaceIntersections.Add(surfaceIntersection);
			}
		}

		var otherSceneSurfaceIntersections = otherScene.Intercepts(ray);
		foreach (var surfaceIntersection in otherSceneSurfaceIntersections)
		{
			var point = line3Component.GetPointAtDistance(ray, surfaceIntersection.Distance);
			if (scene.Contains(point))
			{
				allSurfaceIntersections.Add(surfaceIntersection);
			}
		}

		return allSurfaceIntersections;
	}
}
