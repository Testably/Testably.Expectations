namespace Testably.Expectations.Tests.Core.Exceptions;

public sealed class SkipExceptionTests
{
	[Theory]
	[AutoData]
	public async Task Message_ShouldBeSet(string message)
	{
		SkipException sut = new(message);

		await Expect.That(sut.Message).Is(message);
	}
}
