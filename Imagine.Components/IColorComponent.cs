namespace Imagine.Components;

public interface IColorComponent
{
	RgbColor Average(List<RgbColor> colors);

	RgbColor Multiply(RgbColor color, double factor);

	RgbColor ToRgb(HsvColor color);

	Rgba32 ToRgba32(RgbColor color);
}
