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
	double ZMax);
