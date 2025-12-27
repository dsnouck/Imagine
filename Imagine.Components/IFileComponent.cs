namespace Imagine.Components;

public interface IFileComponent
{
	void Save(List<List<ColorRgb>> image, string name);

	void Save(List<List<List<ColorRgb>>> movie, string name);
}
