namespace Imagine.Components;

public interface ISamplerComponent
{
	List<List<RgbColor>> Sample(Func<Vector2, HsvColor> function, ImageSettings settings);

	List<List<RgbColor>> Sample(Func<Vector2, RgbColor> function, ImageSettings settings);

	List<List<List<RgbColor>>> Sample(Func<Vector3, HsvColor> function, MovieSettings settings);

	List<List<List<RgbColor>>> Sample(Func<Vector3, RgbColor> function, MovieSettings settings);
}
