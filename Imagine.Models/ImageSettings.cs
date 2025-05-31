namespace Imagine.Models;

public readonly record struct ImageSettings(
	int Rows,
	int Columns,
	int Subsamples,
	double XMin,
	double XMax,
	double YMin,
	double YMax);
