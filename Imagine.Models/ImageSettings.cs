namespace Imagine.Models;

// TODO: Rename to SamplerSettings?
public readonly record struct ImageSettings(
	int Width,
	int Height,
	int Subsamples,
	double XMin,
	double XMax,
	double YMin,
	double YMax);
