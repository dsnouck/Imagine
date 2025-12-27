namespace Imagine.Models;

public readonly record struct ColorHsv(double Hue, double Saturation, double Value)
{
	// TODO: Other cast operators use paramter name value. Make this consistent.
	public static explicit operator ColorRgb(ColorHsv color)
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

		var saturation = double.Clamp(color.Saturation, 0D, 1D);
		var value = double.Clamp(color.Value, 0D, 1D);

		var min = value * (1D - saturation);
		var between = value * (1D - (saturation * double.Abs((hue % 2D) - 1D)));
		var max = value;

		return hue switch
		{
			< yellow => new ColorRgb(max, between, min),
			< green => new ColorRgb(between, max, min),
			< cyan => new ColorRgb(min, max, between),
			< blue => new ColorRgb(min, between, max),
			< magenta => new ColorRgb(between, min, max),
			_ => new ColorRgb(max, min, between),
		};
	}
}
