using System;
using System.Threading.Tasks;
using Testably.Expectations.Core.Formatting;
using Xunit;

namespace Testably.Expectations.Tests.Core.Formatting.Formatters;

public sealed class StringFormatterTests
{
	[Fact]
	public async Task Strings_ShouldUseDoubleQuotationMarks()
	{
		string value = "foo";

		string result = Formatter.Format(value);

		await Expect.That(result).Is("\"foo\"");
	}
}
