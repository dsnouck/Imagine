namespace Imagine.Tests;

public class EmptyOutputFixture : IAsyncLifetime
{
	public ValueTask InitializeAsync()
	{
		if (Directory.Exists(Constants.OutputDirectory))
		{
			Directory.Delete(Constants.OutputDirectory, recursive: true);
		}

		return ValueTask.CompletedTask;
	}

	public ValueTask DisposeAsync() =>
		ValueTask.CompletedTask;
}
