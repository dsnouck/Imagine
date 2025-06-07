namespace Imagine.Components;

public class FileComponent(IColorComponent colorComponent) : IFileComponent
{
	private const string Extension = "png";
	private const string Output = "output";

	public void Save(List<List<HsvColor>> image, string name)
	{
		var rgbImage = image.Select(row => row.Select(colorComponent.ToRgb).ToList()).ToList();
		Save(rgbImage, name);
	}

	public void Save(List<List<RgbColor>> image, string name)
	{
		Directory.CreateDirectory(Output);

		var rows = image.Count;
		var columns = image.First().Count;
		using var outputImage = new Image<Rgba32>(columns, rows);

		for (var row = 0; row < rows; row++)
		{
			for (var column = 0; column < columns; column++)
			{
				outputImage[column, row] = colorComponent.ToRgba32(image[row][column]);
			}
		}

		outputImage.Save($"{Output}/{name}.{Extension}");
	}
}
