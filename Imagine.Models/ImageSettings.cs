namespace Imagine.Models;

public readonly record struct ImageSettings(
	int Width,
	int Height,
	int Subsamples,
	float XMin,
	float XMax,
	float YMin,
	float YMax)
{
	public ImageSettings(int width, int height, int subsamples)
		: this(
			  Width: width,
			  Height: height,
			  Subsamples: subsamples,
			  XMin: -1F,
			  XMax: 1F,
			  YMin: -((float)height / width),
			  YMax: (float)height / width)
	{
	}
}
