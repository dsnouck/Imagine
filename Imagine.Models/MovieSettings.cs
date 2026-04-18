namespace Imagine.Models;

public readonly record struct MovieSettings(
	int Frames,
	int Width,
	int Height,
	int Subsamples,
	double XMin,
	double XMax,
	double YMin,
	double YMax,
	double ZMin,
	double ZMax)
{
	public MovieSettings(int frames, int width, int height, int subsamples)
		: this(
			  Frames: frames,
			  Width: width,
			  Height: height,
			  Subsamples: subsamples,
			  XMin: -1D,
			  XMax: 1D,
			  YMin: -((double)height / width),
			  YMax: (double)height / width,
			  ZMin: 0D,
			  ZMax: 1D)
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
