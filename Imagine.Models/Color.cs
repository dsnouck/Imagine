namespace Imagine.Models;

public readonly record struct Color(float R, float G, float B)
{
	public static readonly Color Black = new(0F, 0F, 0F);
	public static readonly Color Blue = new(0F, 0F, 1F);
	public static readonly Color Green = new(0F, 1F, 0F);
	public static readonly Color Red = new(1F, 0F, 0F);
	public static readonly Color White = new(1F, 1F, 1F);

	public static explicit operator Rgba32(Color value) =>
		new(ToByte(value.R), ToByte(value.G), ToByte(value.B));

	public static Color Average(List<Color> colors) =>
		new(colors.Average(color => color.R), colors.Average(color => color.G), colors.Average(color => color.B));

	public static Color operator +(Color left, Color right) =>
		new(left.R + right.R, left.G + right.G, left.B + right.B);

	public static Color operator *(Color left, float right) =>
		new(left.R * right, left.G * right, left.B * right);

	private static byte ToByte(float value)
	{
		value = float.Clamp(value, 0F, 1F);

		var result = float.Floor((1F + byte.MaxValue) * value);
		result = float.Clamp(result, byte.MinValue, byte.MaxValue);

		return (byte)result;
	}
}
