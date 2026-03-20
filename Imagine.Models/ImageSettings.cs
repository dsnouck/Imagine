namespace Imagine.Models;

public readonly record struct ImageSettings(
	int Width,
	int Height,
	int Subsamples,
	double XMin,
	double XMax,
	double YMin,
	double YMax)
{
	public ImageSettings(int width, int height, int subsamples)
		: this(
			  Width: width,
			  Height: height,
			  Subsamples: subsamples,
			  XMin: -1D,
			  XMax: 1D,
			  YMin: -((double)height / width),
			  YMax: (double)height / width)
	{
	}
}
