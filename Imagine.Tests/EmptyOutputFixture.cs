namespace Imagine.Tests;

public class EmptyOutputFixture : IAsyncLifetime
{
	public Task InitializeAsync()
	{
		if (Directory.Exists(Constants.OutputDirectory))
		{
			Directory.Delete(Constants.OutputDirectory, recursive: true);
		}

		return Task.CompletedTask;
	}

	public Task DisposeAsync() =>
		Task.CompletedTask;
}
