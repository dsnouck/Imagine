namespace Imagine.Scenes;

internal class Painted(IScene scene, Func<Vector3, Color> colors) : IScene
{
	internal Painted(IScene scene, Func<Vector3Spherical, Color> colors)
		: this(scene, (Vector3 point) => colors((Vector3Spherical)point))
	{
	}

	internal Painted(IScene scene, Color color)
		: this(scene, (Vector3 _) => color)
	{
	}

	internal Painted(IScene scene, Func<Vector3, ColorHsv> colors)
		: this(scene, point => (Color)colors(point))
	{
	}

	internal Painted(IScene scene, Func<Vector3Spherical, ColorHsv> colors)
		: this(scene, point => (Color)colors(point))
	{
	}

	internal Painted(IScene scene, ColorHsv color)
		: this(scene, (Color)color)
	{
	}

	public bool Contains(Vector3 point) =>
		scene.Contains(point);

	public List<Intercept> Intercepts(Line3 ray) =>
		[.. scene.Intercepts(ray)
			.Select(intercept =>
				new Intercept(
					Distance: intercept.Distance,
					Normal: intercept.Normal,
					Color: colors(ray.At(intercept.Distance))))];
}
