namespace Imagine.Models;

public readonly record struct MovieSettings(
	int Frames,
	int Width,
	int Height,
	int Subsamples,
	float XMin,
	float XMax,
	float YMin,
	float YMax,
	float ZMin,
	float ZMax)
{
	public MovieSettings(int frames, int width, int height, int subsamples, float zMin, float zMax)
		: this(
			  Frames: frames,
			  Width: width,
			  Height: height,
			  Subsamples: subsamples,
			  XMin: -1F,
			  XMax: 1F,
			  YMin: -((float)height / width),
			  YMax: (float)height / width,
			  ZMin: zMin,
			  ZMax: zMax)
	{
	}

	public MovieSettings(int frames, int width, int height, int subsamples)
		: this(
			  frames: frames,
			  width: width,
			  height: height,
			  subsamples: subsamples,
			  zMin: 0F,
			  zMax: 1F)
	{
	}

	public static explicit operator ImageSettings(MovieSettings movieSettings) =>
		new(
			  Width: movieSettings.Width,
			  Height: movieSettings.Height,
			  Subsamples: movieSettings.Subsamples,
			  XMin: movieSettings.XMin,
			  XMax: movieSettings.XMax,
			  YMin: movieSettings.YMin,
			  YMax: movieSettings.YMax);
}
