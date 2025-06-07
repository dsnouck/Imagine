namespace Imagine.Components;

public interface IFileComponent
{
	void Save(List<List<HsvColor>> image, string name);

	void Save(List<List<RgbColor>> image, string name);
}
