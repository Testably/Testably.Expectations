#if NET6_0_OR_GREATER
using Testably.Expectations.Formatting;

namespace Testably.Expectations.Tests.Formatting.Formatters;

public sealed class EnumFormatterTests
{
	[Theory]
	[InlineData(MyEnum.Foo, "Foo")]
	[InlineData(MyEnum.Bar, "Bar")]
	public async Task ShouldUseStringRepresentation(MyEnum value, string expectedResult)
	{
		string result = Formatter.Format(value);

		await That(result).Should().Be(expectedResult);
	}

	public enum MyEnum
	{
		Foo,
		Bar
	}
}
#endif
