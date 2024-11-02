using Testably.Expectations.Formatting;

namespace Testably.Expectations.Tests.Formatting;

public sealed class DefaultFormatterTests
{
	[Fact]
	public async Task ShouldDisplayNestedObjects()
	{
		Dummy value = new()
		{
			Inner = new InnerDummy { InnerValue = "foo" },
			Value = 2
		};

		string result = Formatter.Format(value, FormattingOptions.SingleLine);

		await That(result).Should().Be("""
		                               Dummy{ Inner = InnerDummy{ InnerValue = "foo" }, Value = 2 }
		                               """);
	}

	[Fact]
	public async Task WhenClassContainsField_ShouldDisplayFieldValue()
	{
		object value = new ClassWithField { Value = 42 };

		string result = Formatter.Format(value, FormattingOptions.SingleLine);

		await That(result).Should().Be("ClassWithField{ Value = 42 }");
	}

	[Fact]
	public async Task WhenClassIsEmpty_ShouldDisplayClassName()
	{
		object value = new EmptyClass();

		string result = Formatter.Format(value, FormattingOptions.SingleLine);

		await That(result).Should().Be("EmptyClass{ }");
	}

	[Fact]
	public async Task WhenClassMemberThrowsException_ShouldDisplayException()
	{
		Exception exception = new("foo");
		object value = new ClassWithExceptionProperty(exception);

		string result = Formatter.Format(value, FormattingOptions.SingleLine);

		await That(result).Should()
			.Be("ClassWithExceptionProperty{ Value = [Member 'Value' threw an exception: 'foo'] }");
	}

	[Fact]
	public async Task WhenObject_ShouldDisplayHashCode()
	{
		object value = new();

		string result = Formatter.Format(value, FormattingOptions.SingleLine);

		await That(result).Should().Be("System.Object (HashCode=*)").AsWildcard();
	}

	private class ClassWithExceptionProperty(Exception exception)
	{
		// ReSharper disable once UnusedMember.Local
		public int Value => throw exception;
	}

	private class ClassWithField
	{
		// ReSharper disable once NotAccessedField.Local
		public int Value = 2;
	}

	private class Dummy
	{
		// ReSharper disable once UnusedAutoPropertyAccessor.Local
		public InnerDummy? Inner { get; set; }

		// ReSharper disable once UnusedAutoPropertyAccessor.Local
		public int Value { get; set; }
	}

	private class EmptyClass;

	private class InnerDummy
	{
		// ReSharper disable once UnusedAutoPropertyAccessor.Local
		public string? InnerValue { get; set; }
	}
}
