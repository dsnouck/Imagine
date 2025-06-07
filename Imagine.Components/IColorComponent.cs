namespace Imagine.Components;

public interface IColorComponent
{
	RgbColor Average(List<RgbColor> colors);

	RgbColor ToRgb(HsvColor color);

	Rgba32 ToRgba32(RgbColor color);
}
