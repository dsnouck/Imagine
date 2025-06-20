namespace Imagine.Models;

public readonly record struct ImageSettings(
	int Width,
	int Height,
	int Subsamples,
	double XMin,
	double Xmax,
	double YMin,
	double Ymax);
