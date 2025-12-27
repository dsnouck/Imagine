namespace Imagine.Models;

public readonly record struct ColorRgb(double Red, double Green, double Blue)
{
	// TODO: Use a maximum line length of 120 characters.
	public static ColorRgb Average(List<ColorRgb> colors) =>
		new(colors.Average(color => color.Red), colors.Average(color => color.Green), colors.Average(color => color.Blue));

	public static ColorRgb operator *(ColorRgb left, double right) =>
		new(left.Red * right, left.Green * right, left.Blue * right);

	public static explicit operator Rgba32(ColorRgb color) =>
		new(ToByte(color.Red), ToByte(color.Green), ToByte(color.Blue));

	private static byte ToByte(double value)
	{
		value = double.Clamp(value, 0D, 1D);

		var result = double.Floor((1D + byte.MaxValue) * value);
		result = double.Clamp(result, byte.MinValue, byte.MaxValue);

		return (byte)result;
	}
}
