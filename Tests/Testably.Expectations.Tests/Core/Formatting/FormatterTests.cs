using Xunit;

namespace Testably.Expectations.Tests.Core.Formatting;

public sealed class FormatterTests
{
	[Fact]
	public void StringFormatter_ShouldUseDoubleQuotationMarks()
	{
		string? sut = "foo";

		void Act()
			=> Expect.That(sut, Should.Be.Null());

		Expect.That(Act, Should.Throw.Exception()
			.WhichMessage(Should.Be.EqualTo("Expected sut to be <null>, but found \"foo\".")));
	}
}
