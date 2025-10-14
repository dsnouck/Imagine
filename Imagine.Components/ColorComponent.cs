namespace Imagine.Components;

public class ColorComponent : IColorComponent
{
	public RgbColor Average(List<RgbColor> colors) =>
		new(colors.Average(color => color.Red), colors.Average(color => color.Green), colors.Average(color => color.Blue));

	public RgbColor ToRgb(HsvColor color)
	{
		const double yellow = 1D;
		const double green = 2D;
		const double cyan = 3D;
		const double blue = 4D;
		const double magenta = 5D;
		const double red = 6D;

		var hue = color.Hue % 1D;
		if (hue < 0D)
		{
			hue++;
		}

		hue *= red;

		var saturation = Math.Clamp(color.Saturation, 0D, 1D);
		var value = Math.Clamp(color.Value, 0D, 1D);

		var min = value * (1D - saturation);
		var between = value * (1D - (saturation * Math.Abs((hue % 2D) - 1D)));
		var max = value;

		return hue switch
		{
			< yellow => new RgbColor(max, between, min),
			< green => new RgbColor(between, max, min),
			< cyan => new RgbColor(min, max, between),
			< blue => new RgbColor(min, between, max),
			< magenta => new RgbColor(between, min, max),
			_ => new RgbColor(max, min, between),
		};
	}

	// TODO: Order methods logically.
	public RgbColor Multiply(RgbColor color, double factor) => new(color.Red * factor, color.Green * factor, color.Blue * factor);

	public Rgba32 ToRgba32(RgbColor color) => new(ToByte(color.Red), ToByte(color.Green), ToByte(color.Blue));

	private static byte ToByte(double value)
	{
		value = Math.Clamp(value, 0D, 1D);

		var result = Math.Floor((1D + byte.MaxValue) * value);
		result = Math.Clamp(result, byte.MinValue, byte.MaxValue);

		return (byte)result;
	}
}
