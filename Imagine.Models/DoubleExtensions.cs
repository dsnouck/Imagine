namespace Imagine.Models;

public static class DoubleExtensions
{
	extension(double source)
	{
		public double Modulo(double other) =>
			source - (other * double.Floor(source / other));
	}
}
