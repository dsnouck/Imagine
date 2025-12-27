namespace Imagine.Components;

public class FileComponent : IFileComponent
{
	private const string OutputDirectory = "output";
	private const string FramesDirectory = $"{OutputDirectory}/frames";

	public void Save(List<List<ColorRgb>> image, string name) => Save(image, OutputDirectory, name);

	public void Save(List<List<List<ColorRgb>>> movie, string name)
	{
		Directory.CreateDirectory($"{FramesDirectory}");
		Directory.CreateDirectory($"{OutputDirectory}");

		var frames = movie.Count;
		for (var frame = 0; frame < frames; frame++)
		{
			Save(movie[frame], FramesDirectory, $"{name}-{frame:D4}");
		}

		using var process = new Process
		{
			StartInfo = new ProcessStartInfo
			{
				FileName = "ffmpeg",
				Arguments = $"-y -framerate 30 -i {FramesDirectory}/{name}-%04d.png -c:v libx264 -pix_fmt yuv420p {OutputDirectory}/{name}.mp4",
				RedirectStandardOutput = true,
				UseShellExecute = false,
				CreateNoWindow = true,
			},
		};

		process.Start();
		process.WaitForExit();
	}

	private void Save(List<List<ColorRgb>> image, string directory, string name)
	{
		Directory.CreateDirectory(directory);

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

		outputImage.Save($"{directory}/{name}.png");
	}
}
