namespace Imagine.Tools;

public static class Saver
{
	private const string OutputDirectory = "output";
	private const string FramesDirectory = $"{OutputDirectory}/frames";

	public static string Save(List<List<ColorRgb>> image, string name) => Save(image, OutputDirectory, name);

	public static string Save(List<List<List<ColorRgb>>> movie, string name) => Save(movie, OutputDirectory, name);

	private static string Save(List<List<ColorRgb>> image, string directory, string name)
	{
		Directory.CreateDirectory(directory);
		var file = $"{directory}/{name}.png";

		var height = image.Count;
		var width = image.First().Count;
		using var outputImage = new Image<Rgba32>(width, height);

		for (var row = 0; row < height; row++)
		{
			for (var column = 0; column < width; column++)
			{
				outputImage[column, row] = (Rgba32)image[row][column];
			}
		}

		outputImage.Save(file);

		return file;
	}

	private static string Save(List<List<List<ColorRgb>>> movie, string directory, string name)
	{
		Directory.CreateDirectory(directory);
		var file = $"{directory}/{name}.mp4";

		for (var frame = 0; frame < movie.Count; frame++)
		{
			Save(movie[frame], FramesDirectory, $"{name}-{frame:D4}");
		}

		using var process = new Process
		{
			StartInfo = new()
			{
				FileName = "ffmpeg",
				Arguments = $"-y -framerate 30 -i {FramesDirectory}/{name}-%04d.png -c:v libx264 -pix_fmt yuv420p {file}",
				RedirectStandardOutput = true,
				UseShellExecute = false,
				CreateNoWindow = true,
			},
		};

		process.Start();
		process.WaitForExit();

		return file;
	}
}
