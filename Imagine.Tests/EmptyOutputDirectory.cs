namespace Imagine.Tests;

[TestClass]
public static class EmptyOutputDirectory
{
	[AssemblyInitialize]
	public static void AssemblyInitialize(TestContext context)
	{
		_ = context;

		if (Directory.Exists(Constants.OutputDirectory))
		{
			foreach (var path in Directory.EnumerateFileSystemEntries(Constants.OutputDirectory))
			{
				if (Directory.Exists(path))
				{
					Directory.Delete(path, recursive: true);
				}
				else
				{
					File.Delete(path);
				}
			}
		}
	}
}
