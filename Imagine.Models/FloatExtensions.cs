namespace Imagine.Models;

public static class FloatExtensions
{
	extension(float source)
	{
		public float Modulo(float other) =>
			source - (other * float.Floor(source / other));
	}
}
