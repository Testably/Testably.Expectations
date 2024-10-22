using Testably.Expectations.Formatting;

namespace Testably.Expectations.Tests.Core.Formatting.Formatters;

public sealed class NumberFormatterTests
{
	[Theory]
	[InlineData(4, "4")]
	[InlineData(4.1f, "4.1")]
	[InlineData(-3.8d, "-3.8")]
	[InlineData(12L, "12")]
	[InlineData(0x03, "3")]
	public async Task Numbers_ShouldReturnExpectedValue(object value, string expectedResult)
	{
		string result = Formatter.Format(value);

		await Expect.That(result).Should().Is(expectedResult);
	}
}
