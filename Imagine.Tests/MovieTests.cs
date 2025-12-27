namespace Imagine.Tests;

public class MovieTests
{
	private readonly IFileComponent fileComponent;
	private readonly ILine2Component line2Component;
	private readonly ISamplerComponent samplerComponent;

	public MovieTests()
	{
		fileComponent = new FileComponent();
		line2Component = new Line2Component();
		samplerComponent = new SamplerComponent(line2Component);
	}

	[Fact]
	public void Hsv()
	{
		const string name = "hsv";

		var settings = new MovieSettings(
			Frames: 256,
			Width: 256,
			Height: 256,
			Subsamples: 2,
			XMin: 0D,
			XMax: 1D,
			YMin: 0D,
			YMax: 1D,
			ZMin: 0D,
			ZMax: 2D);

		static ColorHsv Function(Vector3 point)
		{
			var z = point.Z < 1D ? point.Z : 2D - point.Z;
			var center = new Vector2(z, z);
			var point2 = (Vector2)point;
			var r = (point2 - center).Length();

			var hue = (2D * point.X) - 1D;
			var saturation = r < 0.25D ? 1D - (4D * r) : 0D;
			var value = point.Y;

			return new ColorHsv(hue, saturation, value);
		}

		var movie = samplerComponent.Sample(Function, settings);
		fileComponent.Save(movie, name);
	}

	[Fact]
	public void Red()
	{
		const string name = "red";

		const int frames = 256;
		const int width = 256;
		const int height = 256;
		var red = new ColorRgb(1D, 0D, 0D);

		var movie = Enumerable.Repeat(
			Enumerable.Repeat(
				Enumerable.Repeat(
					red,
					width).ToList(),
				height).ToList(),
			frames).ToList();

		fileComponent.Save(movie, name);
	}

	[Fact]
	public void Rgb()
	{
		const string name = "rgb";

		var settings = new MovieSettings(
			Frames: 256,
			Width: 256,
			Height: 256,
			Subsamples: 2,
			XMin: 0D,
			XMax: 1D,
			YMin: 0D,
			YMax: 1D,
			ZMin: 0D,
			ZMax: 2D);

		static ColorRgb Function(Vector3 point)
		{
			var z = point.Z < 1D ? point.Z : 2D - point.Z;
			var center = new Vector2(z, z);
			var point2 = (Vector2)point;
			var r = (point2 - center).Length();

			var red = point.X;
			var green = r < 0.25D ? 1D - (4D * r) : 0D;
			var blue = point.Y;

			return new ColorRgb(red, green, blue);
		}

		var movie = samplerComponent.Sample(Function, settings);
		fileComponent.Save(movie, name);
	}
}
