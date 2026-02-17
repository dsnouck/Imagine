namespace Imagine.Scenes;

public class Union(IScene scene, IScene otherScene) : IScene
{
	public bool Contains(Vector3 point) => scene.Contains(point) || otherScene.Contains(point);

	public List<Intercept> Intercepts(Line3 ray)
	{
		var allSurfaceIntersections = new List<Intercept>();

		var sceneSurfaceIntersections = scene.Intercepts(ray);
		foreach (var surfaceIntersection in sceneSurfaceIntersections)
		{
			var point = ray.At(surfaceIntersection.Distance);
			if (!otherScene.Contains(point))
			{
				allSurfaceIntersections.Add(surfaceIntersection);
			}
		}

		var otherSceneSurfaceIntersections = otherScene.Intercepts(ray);
		foreach (var surfaceIntersection in otherSceneSurfaceIntersections)
		{
			var point = ray.At(surfaceIntersection.Distance);
			if (!scene.Contains(point))
			{
				allSurfaceIntersections.Add(surfaceIntersection);
			}
		}

		return allSurfaceIntersections;
	}
}
