using AutoFixture.Xunit2;
using Testably.Expectations.Core;
using Xunit;

namespace Testably.Expectations.Tests.Core;

public sealed class ExpectationResultTests
{
	[Theory]
	[AutoData]
	public void Copy_FromFailure_ShouldIncludeValue(string expectationText, string resultText)
	{
		Dummy value = new()
		{
			Value = 1
		};
		ExpectationResult.Failure sut = new(expectationText, resultText);

		ExpectationResult result =
			ExpectationResult.Copy(sut, value);

		Expect.That(result, Should.Be.OfType<ExpectationResult.Failure<Dummy>>()
			.Which(p => p.Value, Should.Be.EqualTo(value)).And()
			.Which(p => p.ExpectationText, Should.Be.EqualTo(expectationText)).And()
			.Which(p => p.ResultText, Should.Be.EqualTo(resultText)).And()
			.Be.OfType<ExpectationResult>());
	}

	[Theory]
	[AutoData]
	public void Copy_FromFailure_ShouldIncludeValueAndOverwriteText(string expectationText,
		string resultText)
	{
		Dummy value = new()
		{
			Value = 1
		};
		ExpectationResult.Failure sut = new("foo", "bar");

		ExpectationResult result =
			ExpectationResult.Copy(sut, value, _ => expectationText, _ => resultText);

		Expect.That(result, Should.Be.OfType<ExpectationResult.Failure<Dummy>>()
			.Which(p => p.Value, Should.Be.EqualTo(value)).And()
			.Which(p => p.ExpectationText, Should.Be.EqualTo(expectationText)).And()
			.Which(p => p.ResultText, Should.Be.EqualTo(resultText)).And()
			.Be.OfType<ExpectationResult>());
	}

	[Fact]
	public void Copy_FromSuccess_ShouldIncludeValue()
	{
		Dummy value = new()
		{
			Value = 1
		};
		ExpectationResult.Success sut = new();

		ExpectationResult result = ExpectationResult.Copy(sut, value);

		Expect.That(result, Should.Be.OfType<ExpectationResult.Success<Dummy>>()
			.Which(p => p.Value, Should.Be.EqualTo(value)));
	}

	[Theory]
	[AutoData]
	public void Failure_WithoutValue_ShouldStoreTexts(string expectationText, string resultText)
	{
		ExpectationResult.Failure sut = new(expectationText, resultText);

		Expect.That(sut.ExpectationText, Should.Be.EqualTo(expectationText));
		Expect.That(sut.ResultText, Should.Be.EqualTo(resultText));
	}

	[Theory]
	[AutoData]
	public void Failure_WithValue_ShouldStoreValueAndTexts(string expectationText,
		string resultText)
	{
		Dummy value = new()
		{
			Value = 1
		};

		ExpectationResult.Failure<Dummy> sut = new(value, expectationText, resultText);

		Expect.That(sut.Value, Should.Be.EqualTo(value));
		Expect.That(sut.ExpectationText, Should.Be.EqualTo(expectationText));
		Expect.That(sut.ResultText, Should.Be.EqualTo(resultText));
	}

	[Fact]
	public void Success_WithValue_ShouldStoreValue()
	{
		Dummy value = new()
		{
			Value = 1
		};

		ExpectationResult.Success<Dummy> sut = new(value);

		Expect.That(sut.Value, Should.Be.EqualTo(value));
	}

	private class Dummy
	{
		public int Value { get; set; }
	}
}
