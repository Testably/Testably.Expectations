using System;
using System.Threading.Tasks;
using Testably.Expectations.Core.Formatting;
using Xunit;

namespace Testably.Expectations.Tests.Core.Formatting;

public sealed partial class FormatterTests
{
	[Theory]
	[InlineData(true, "True")]
	[InlineData(false, "False")]
	public async Task Booleans_ShouldHaveCapitalizedFirstLetter(bool value, string expectedResult)
	{
		string result = Formatter.Format(value);

		await Expect.That(result).Is(expectedResult);
	}

	[Fact]
	public async Task Strings_ShouldUseDoubleQuotationMarks()
	{
		string value = "foo";

		string result = Formatter.Format(value);

		await Expect.That(result).Is("\"foo\"");
	}

	[Theory]
	[InlineData(4, "4")]
	[InlineData(4.1f, "4.1")]
	[InlineData(-3.8d, "-3.8")]
	[InlineData(12L, "12")]
	[InlineData(0x03, "3")]
	public async Task Numbers_ShouldReturnExpectedValue(object value, string expectedResult)
	{
		string result = Formatter.Format(value);

		await Expect.That(result).Is(expectedResult);
	}

	[Fact]
	public async Task Types_ShouldOnlyIncludeTheName()
	{
		Type value = typeof(FormatterTests);
		string result = Formatter.Format(value);

		await Expect.That(result).Is(nameof(FormatterTests));
	}
}
