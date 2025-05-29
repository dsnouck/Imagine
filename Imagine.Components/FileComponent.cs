namespace Imagine.Components;

public class FileComponent(IColorComponent colorComponent) : IFileComponent
{
	private const string Extension = "png";
	private const string Output = "output";

	public void Save(string name, List<List<RgbColor>> image)
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
