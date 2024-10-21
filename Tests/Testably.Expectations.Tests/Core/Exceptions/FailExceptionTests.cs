using AutoFixture.Xunit2;
using System.Threading.Tasks;
using Xunit;

namespace Testably.Expectations.Tests.Core.Exceptions;

public sealed class FailExceptionTests
{
	[Theory]
	[AutoData]
	public async Task Message_ShouldBeSet(string message)
	{
		FailException sut = new(message);

		await Expect.That(sut.Message).Is(message);
	}
}
