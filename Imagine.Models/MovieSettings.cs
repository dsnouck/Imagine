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
	public static explicit operator ImageSettings(MovieSettings movieSettings)
		=> new(
			  Width: movieSettings.Width,
			  Height: movieSettings.Height,
			  Subsamples: movieSettings.Subsamples,
			  XMin: movieSettings.XMin,
			  XMax: movieSettings.XMax,
			  YMin: movieSettings.YMin,
			  YMax: movieSettings.YMax);
}
