namespace Imagine.Tests;

internal static class FileAssertions
{
	extension(string source)
	{
		public void ShouldHaveSameContentAs(string file) =>
			File.ReadAllBytes(source).Should().Equal(File.ReadAllBytes(file));
	}
}
