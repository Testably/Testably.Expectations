using AutoFixture.Xunit2;
using System.Threading.Tasks;
using Xunit;

namespace Testably.Expectations.Tests;

public sealed class ExpectationExceptionTests
{
	[Theory]
	[AutoData]
	public async Task Message_ShouldBeSet(string message)
	{
		ExpectationException sut = new(message);

		await Expect.That(sut.Message).Is(message);
	}
}
