namespace Imagine.Models;

public readonly record struct ColorHsv(double H, double S, double V)
{
	public static explicit operator Color(ColorHsv value)
	{
		const double yellow = 1D;
		const double green = 2D;
		const double cyan = 3D;
		const double blue = 4D;
		const double magenta = 5D;
		const double red = 6D;

		var h = red * value.H.Modulo(1D);
		var s = double.Clamp(value.S, 0D, 1D);
		var v = double.Clamp(value.V, 0D, 1D);

		var min = v * (1D - s);
		var between = v * (1D - (s * double.Abs((h % 2D) - 1D)));
		var max = v;

		return h switch
		{
			< yellow => new(max, between, min),
			< green => new(between, max, min),
			< cyan => new(min, max, between),
			< blue => new(min, between, max),
			< magenta => new(between, min, max),
			_ => new(max, min, between),
		};
	}
}
