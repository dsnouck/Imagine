namespace Imagine.Components;

public interface ISamplerComponent
{
	List<List<ColorRgb>> Sample(Func<Vector2, ColorHsv> function, ImageSettings settings);

	List<List<ColorRgb>> Sample(Func<Vector2, ColorRgb> function, ImageSettings settings);

	List<List<List<ColorRgb>>> Sample(Func<Vector3, ColorHsv> function, MovieSettings settings);

	List<List<List<ColorRgb>>> Sample(Func<Vector3, ColorRgb> function, MovieSettings settings);
}
