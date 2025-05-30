namespace Imagine.Components;

public class ColorComponent : IColorComponent
{
	public Rgba32 ToRgba32(RgbColor color)
	{
		return new Rgba32(ToByte(color.R), ToByte(color.G), ToByte(color.B));
	}

	private static byte ToByte(double value)
	{
		value = Math.Clamp(value, 0D, 1D);
		var result = Math.Floor((1D + byte.MaxValue) * value);
		result = Math.Clamp(result, byte.MinValue, byte.MaxValue);
		return (byte)result;
	}
}
