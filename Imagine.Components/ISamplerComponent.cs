namespace Imagine.Components;

public interface ISamplerComponent
{
	List<List<RgbColor>> Sample(Func<Vector2, HsvColor> function, ImageSettings settings);

	List<List<RgbColor>> Sample(Func<Vector2, RgbColor> function, ImageSettings settings);
}
