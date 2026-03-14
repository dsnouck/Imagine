namespace Imagine.Models;

public readonly record struct ColorHsv(double Hue, double Saturation, double Value)
{
	public static explicit operator ColorRgb(ColorHsv value)
	{
		const double yellow = 1D;
		const double green = 2D;
		const double cyan = 3D;
		const double blue = 4D;
		const double magenta = 5D;
		const double red = 6D;

		var hue = value.Hue % 1D;
		if (hue < 0D)
		{
			hue++;
		}

		hue *= red;

		var saturation = double.Clamp(value.Saturation, 0D, 1D);
		var hsvValue = double.Clamp(value.Value, 0D, 1D);

		var min = hsvValue * (1D - saturation);
		var between = hsvValue * (1D - (saturation * double.Abs((hue % 2D) - 1D)));
		var max = hsvValue;

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
