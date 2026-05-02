namespace Imagine.Models;

public readonly record struct ColorHsv(float H, float S, float V)
{
	public static explicit operator Color(ColorHsv value)
	{
		const float yellow = 1F;
		const float green = 2F;
		const float cyan = 3F;
		const float blue = 4F;
		const float magenta = 5F;
		const float red = 6F;

		var h = red * value.H.Modulo(1F);
		var s = float.Clamp(value.S, 0F, 1F);
		var v = float.Clamp(value.V, 0F, 1F);

		var min = v * (1F - s);
		var between = v * (1F - (s * float.Abs((h % 2F) - 1F)));
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
