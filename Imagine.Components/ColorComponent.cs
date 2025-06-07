namespace Imagine.Components;

public class ColorComponent : IColorComponent
{
	private const double Yellow = 1D;
	private const double Green = 2D;
	private const double Cyan = 3D;
	private const double Blue = 4D;
	private const double Magenta = 5D;
	private const double Red = 6D;

	public RgbColor Average(List<RgbColor> colors) =>
		new(colors.Average(color => color.Red), colors.Average(color => color.Green), colors.Average(color => color.Blue));

	public RgbColor ToRgb(HsvColor color)
	{
		var hue = color.Hue % 1D;
		if (hue < 0D)
		{
			hue++;
		}

		hue *= Red;

		var saturation = Math.Clamp(color.Saturation, 0D, 1D);
		var value = Math.Clamp(color.Value, 0D, 1D);

		var minimum = value * (1D - saturation);
		var intermediate = value * (1D - (saturation * Math.Abs((hue % 2D) - 1D)));
		var maximum = value;

		return hue switch
		{
			< Yellow => new RgbColor(maximum, intermediate, minimum),
			< Green => new RgbColor(intermediate, maximum, minimum),
			< Cyan => new RgbColor(minimum, maximum, intermediate),
			< Blue => new RgbColor(minimum, intermediate, maximum),
			< Magenta => new RgbColor(intermediate, minimum, maximum),
			_ => new RgbColor(maximum, minimum, intermediate),
		};
	}

	public Rgba32 ToRgba32(RgbColor color) => new(ToByte(color.Red), ToByte(color.Green), ToByte(color.Blue));

	private static byte ToByte(double value)
	{
		value = Math.Clamp(value, 0D, 1D);

		var result = Math.Floor((1D + byte.MaxValue) * value);
		result = Math.Clamp(result, byte.MinValue, byte.MaxValue);

		return (byte)result;
	}
}
