namespace Testably.Expectations.Tests.Core.Formatting;

public sealed class DefaultFormatterTests
{
	[Fact]
	public async Task ShouldDisplayNestedObjects()
	{
		Dummy value = new()
		{
			Inner = new InnerDummy
			{
				InnerValue = "foo"
			},
			Value = 2
		};

		string result = Formatter.Format(value, FormattingOptions.SingleLine);

		await Expect.That(result).Is("""
		                             Dummy{ Inner = InnerDummy{ InnerValue = "foo" }, Value = 2 }
		                             """);
	}

	private class Dummy
	{
		// ReSharper disable once UnusedAutoPropertyAccessor.Local
		public InnerDummy? Inner { get; set; }

		// ReSharper disable once UnusedAutoPropertyAccessor.Local
		public int Value { get; set; }
	}

	private class InnerDummy
	{
		// ReSharper disable once UnusedAutoPropertyAccessor.Local
		public string? InnerValue { get; set; }
	}
}
