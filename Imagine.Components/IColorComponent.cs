namespace Imagine.Components;

public interface IColorComponent
{
	RgbColor Average(List<RgbColor> colors);

	Rgba32 ToRgba32(RgbColor color);
}
