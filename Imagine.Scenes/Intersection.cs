namespace Imagine.Scenes;

internal class Intersection(IScene scene, IScene otherScene) : IScene
{
	public bool Contains(Vector3 point) =>
		scene.Contains(point) && otherScene.Contains(point);

	public List<Intercept> Intercepts(Line3 ray)
	{
		var allIntercepts = new List<Intercept>();

		var sceneIntercepts = scene.Intercepts(ray);
		foreach (var intercept in sceneIntercepts)
		{
			var point = ray.At(intercept.Distance);
			if (otherScene.Contains(point))
			{
				allIntercepts.Add(intercept);
			}
		}

		var otherSceneIntercepts = otherScene.Intercepts(ray);
		foreach (var intercept in otherSceneIntercepts)
		{
			var point = ray.At(intercept.Distance);
			if (scene.Contains(point))
			{
				allIntercepts.Add(intercept);
			}
		}

		return allIntercepts;
	}
}
