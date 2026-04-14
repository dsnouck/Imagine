namespace Imagine.Models;

public readonly record struct Color(double R, double G, double B)
{
	public static readonly Color Black = new(0D, 0D, 0D);
	public static readonly Color Blue = new(0D, 0D, 1D);
	public static readonly Color Green = new(0D, 1D, 0D);
	public static readonly Color Red = new(1D, 0D, 0D);
	public static readonly Color White = new(1D, 1D, 1D);

	public static explicit operator Rgba32(Color value) =>
		new(ToByte(value.R), ToByte(value.G), ToByte(value.B));

	public static Color Average(List<Color> colors) =>
		new(colors.Average(color => color.R), colors.Average(color => color.G), colors.Average(color => color.B));

	public static Color operator *(Color left, double right) =>
		new(left.R * right, left.G * right, left.B * right);

	private static byte ToByte(double value)
	{
		value = double.Clamp(value, 0D, 1D);

		var result = double.Floor((1D + byte.MaxValue) * value);
		result = double.Clamp(result, byte.MinValue, byte.MaxValue);

		return (byte)result;
	}
}
