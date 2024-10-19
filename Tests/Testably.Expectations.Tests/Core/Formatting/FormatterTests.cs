using System.Threading.Tasks;
using Xunit;

namespace Testably.Expectations.Tests.Core.Formatting;

public sealed class FormatterTests
{
	[Fact]
	public async Task StringFormatter_ShouldUseDoubleQuotationMarks()
	{
		string sut = "foo";

		async Task Act()
			=> await That(sut).IsNull();

		await That(Act).ThrowsException()
			.Which.HasMessage("""
			                  Expected that sut
			                  is null,
			                  but found "foo"
			                  at Expect.That(sut).IsNull()
			                  """);
	}
}


