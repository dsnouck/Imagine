namespace Imagine.Components;

public class ColorComponent : IColorComponent
{
	public RgbColor Average(List<RgbColor> colors)
	{
		return new RgbColor(colors.Average(color => color.Red), colors.Average(color => color.Green), colors.Average(color => color.Blue));
	}

	public Rgba32 ToRgba32(RgbColor color)
	{
		return new Rgba32(ToByte(color.Red), ToByte(color.Green), ToByte(color.Blue));
	}

	private static byte ToByte(double value)
	{
		value = Math.Clamp(value, 0D, 1D);

		var result = Math.Floor((1D + byte.MaxValue) * value);
		result = Math.Clamp(result, byte.MinValue, byte.MaxValue);

		return (byte)result;
	}
}
