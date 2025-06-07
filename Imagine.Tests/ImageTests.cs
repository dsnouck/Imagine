namespace Imagine.Tests;

public class ImageTests
{
	private const int Rows = 512;
	private const int Columns = 512;

	private readonly IColorComponent colorComponent;
	private readonly IFileComponent fileComponent;
	private readonly ILineComponent lineComponent;
	private readonly ISamplerComponent samplerComponent;
	private readonly IVector2Component vector2Component;

	public ImageTests()
	{
		colorComponent = new ColorComponent();
		fileComponent = new FileComponent(colorComponent);
		lineComponent = new LineComponent();
		samplerComponent = new SamplerComponent(colorComponent, lineComponent);
		vector2Component = new Vector2Component();
	}

	[Fact]
	public void HsvRed()
	{
		const string name = "hsv-red";

		var image = Enumerable.Repeat(
			Enumerable.Repeat(
				new HsvColor(1D, 1D, 1D),
				Columns).ToList(),
			Rows).ToList();

		fileComponent.Save(image, name);
	}

	[Fact]
	public void RgbRed()
	{
		const string name = "rgb-red";

		var image = Enumerable.Repeat(
			Enumerable.Repeat(
				new RgbColor(1D, 0D, 0D),
				Columns).ToList(),
			Rows).ToList();

		fileComponent.Save(image, name);
	}

	[Fact]
	public void HsvGradient()
	{
		const string name = "hsv-gradient";

		var center = new Vector2(0.5D, 0.5D);
		var settings = new ImageSettings(
			Rows: Rows,
			Columns: Columns,
			Subsamples: 2,
			MinimumX: 0D,
			MaximumX: 1D,
			MinimumY: 0D,
			MaximumY: 1D);

		HsvColor Function(Vector2 point)
		{
			var r = vector2Component.Length(vector2Component.Subtract(point, center));

			var hue = (2D * point.X) - 1D;
			var saturation = r < 0.5D ? 1D - (2D * r) : 0D;
			var value = point.Y;

			return new HsvColor(hue, saturation, value);
		}

		var image = samplerComponent.Sample(Function, settings);
		fileComponent.Save(image, name);
	}

	[Fact]
	public void RgbGradient()
	{
		const string name = "rgb-gradient";

		var center = new Vector2(0.5D, 0.5D);
		var settings = new ImageSettings(
			Rows: Rows,
			Columns: Columns,
			Subsamples: 2,
			MinimumX: 0D,
			MaximumX: 1D,
			MinimumY: 0D,
			MaximumY: 1D);

		RgbColor Function(Vector2 point)
		{
			var r = vector2Component.Length(vector2Component.Subtract(point, center));

			var red = point.X;
			var green = r < 0.5D ? 1D - (2D * r) : 0D;
			var blue = point.Y;

			return new RgbColor(red, green, blue);
		}

		var image = samplerComponent.Sample(Function, settings);
		fileComponent.Save(image, name);
	}
}
