namespace Imagine.Models;

public readonly record struct ImageSettings(
	int Rows,
	int Columns,
	int Subsamples,
	double MinimumX,
	double MaximumX,
	double MinimumY,
	double MaximumY);
