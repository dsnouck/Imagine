namespace Imagine.Tests;

public class ImageTests
{
	private readonly IColorComponent colorComponent;
	private readonly IFileComponent fileComponent;

	public ImageTests()
	{
		colorComponent = new ColorComponent();
		fileComponent = new FileComponent(colorComponent);
	}

	[Fact]
	public void Red()
	{
		var image = Enumerable.Repeat(Enumerable.Repeat(new RgbColor(1, 0, 0), 640).ToList(), 480).ToList();
		fileComponent.Save("red", image);
	}
}
