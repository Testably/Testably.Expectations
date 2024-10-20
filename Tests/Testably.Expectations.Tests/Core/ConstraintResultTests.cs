using AutoFixture.Xunit2;
using System.Threading.Tasks;
using Testably.Expectations.Core.Constraints;
using Xunit;

namespace Testably.Expectations.Tests.Core;

public sealed class ConstraintResultTests
{
	[Theory]
	[AutoData]
	public async Task Failure_WithoutValue_ShouldStoreTexts(string expectationText,
		string resultText)
	{
		ConstraintResult.Failure sut = new(expectationText, resultText);

		await Expect.That(sut.ExpectationText).Is(expectationText);
		await Expect.That(sut.ResultText).Is(resultText);
	}

	[Theory]
	[AutoData]
	public async Task Failure_WithValue_ShouldStoreValueAndTexts(string expectationText,
		string resultText)
	{
		Dummy value = new()
		{
			Value = 1
		};

		ConstraintResult.Failure<Dummy> sut = new(value, expectationText, resultText);

		await Expect.That(sut.Value).IsEquivalentTo(value);
		await Expect.That(sut.ExpectationText).Is(expectationText);
		await Expect.That(sut.ResultText).Is(resultText);
	}

	[Theory]
	[AutoData]
	public async Task Invert_FromFailure_ShouldKeepExpectationText(string expectationText,
		string resultText)
	{
		ConstraintResult.Failure sut = new(expectationText, resultText);

		ConstraintResult result = sut.Invert();

		await Expect.That(result).Is<ConstraintResult.Success>()
			.Which(s => s.ExpectationText, e => e.Is(expectationText));
	}

	[Theory]
	[AutoData]
	public async Task Invert_FromFailure_ShouldUpdateExpectationText(string expectationText,
		string resultText)
	{
		ConstraintResult.Failure sut = new("foo", "bar");

		ConstraintResult result = sut.Invert(_ => expectationText, _ => resultText);

		await Expect.That(result).Is<ConstraintResult.Success>()
			.Which(s => s.ExpectationText, e => e.Is(expectationText));
	}

	[Theory]
	[AutoData]
	public async Task Invert_FromFailureWithValue_ShouldIncludeValue(string expectationText,
		string resultText)
	{
		Dummy value = new()
		{
			Value = 1
		};
		ConstraintResult.Failure<Dummy> sut = new(value, expectationText, resultText);

		ConstraintResult result = sut.Invert();

		await Expect.That(result).Is<ConstraintResult.Success<Dummy>>()
			.Which(s => s.Value, e => e.IsEquivalentTo(value));
	}

	[Theory]
	[AutoData]
	public async Task Invert_FromFailureWithValue_ShouldKeepExpectationText(string expectationText,
		string resultText)
	{
		Dummy value = new()
		{
			Value = 1
		};
		ConstraintResult.Failure<Dummy> sut = new(value, expectationText, resultText);

		ConstraintResult result = sut.Invert();

		await Expect.That(result).Is<ConstraintResult.Success<Dummy>>()
			.Which(s => s.ExpectationText, e => e.Is(expectationText));
	}

	[Theory]
	[AutoData]
	public async Task Invert_FromFailureWithValue_ShouldUpdateExpectationText(
		string expectationText,
		string resultText)
	{
		Dummy value = new()
		{
			Value = 1
		};
		ConstraintResult.Failure<Dummy> sut = new(value, "foo", "bar");

		ConstraintResult result = sut.Invert(_ => expectationText, _ => resultText);

		await Expect.That(result).Is<ConstraintResult.Success<Dummy>>()
			.Which(s => s.ExpectationText, e => e.Is(expectationText));
	}

	[Theory]
	[AutoData]
	public async Task Invert_FromSuccess_ShouldKeepExpectationTextAndUseDefaultResultText(
		string expectationText)
	{
		ConstraintResult.Success sut = new(expectationText);

		ConstraintResult result = sut.Invert();

		await Expect.That(result).Is<ConstraintResult.Failure>()
			.Which(s => s.ExpectationText, e => e.Is(expectationText))
			.Which(s => s.ResultText, e => e.Is("it did"));
	}

	[Theory]
	[AutoData]
	public async Task Invert_FromSuccess_ShouldUpdateExpectationAndDefaultResultText(
		string expectationText, string resultText)
	{
		ConstraintResult.Success sut = new("foo");

		ConstraintResult result = sut.Invert(_ => expectationText, _ => resultText);

		await Expect.That(result).Is<ConstraintResult.Failure>()
			.Which(p => p.ExpectationText, e => e.Is(expectationText))
			.Which(p => p.ResultText, e => e.Is(resultText));
	}

	[Theory]
	[AutoData]
	public async Task Invert_FromSuccessWithValue_ShouldIncludeValue(string expectationText)
	{
		Dummy value = new()
		{
			Value = 1
		};
		ConstraintResult.Success<Dummy> sut = new(value, expectationText);

		ConstraintResult result = sut.Invert();

		await Expect.That(result).Is<ConstraintResult.Failure<Dummy>>()
			.Which(p => p.Value, e => e.IsEquivalentTo(value));
	}

	[Theory]
	[AutoData]
	public async Task Invert_FromSuccessWithValue_ShouldKeepExpectationTextAndUseDefaultResultText(
		string expectationText)
	{
		Dummy value = new()
		{
			Value = 1
		};
		ConstraintResult.Success<Dummy> sut = new(value, expectationText);

		ConstraintResult result = sut.Invert();

		await Expect.That(result).Is<ConstraintResult.Failure<Dummy>>()
			.Which(p => p.ExpectationText, e => e.Is(expectationText))
			.Which(p => p.ResultText, e => e.Is("it did"));
	}

	[Theory]
	[AutoData]
	public async Task Invert_FromSuccessWithValue_ShouldUpdateExpectationAndResultText(
		string expectationText, string resultText)
	{
		Dummy value = new()
		{
			Value = 1
		};
		ConstraintResult.Success<Dummy> sut = new(value, "foo");

		ConstraintResult result = sut.Invert(_ => expectationText, _ => resultText);

		await Expect.That(result).Is<ConstraintResult.Failure<Dummy>>()
			.Which(p => p.ExpectationText, e => e.Is(expectationText))
			.Which(p => p.ResultText, e => e.Is(resultText));
	}

	[Theory]
	[AutoData]
	public async Task Success_WithValue_ShouldStoreValue(string expectationText)
	{
		Dummy value = new()
		{
			Value = 1
		};

		ConstraintResult.Success<Dummy> sut = new(value, expectationText);

		await Expect.That(sut.Value).IsEquivalentTo(value);
		await Expect.That(sut.ExpectationText).Is(expectationText);
	}

	[Theory]
	[AutoData]
	public async Task ToString_Failure_ShouldBeExpectationTextWithPrependedFailed(
		string expectationText)
	{
		ConstraintResult.Failure sut = new(expectationText, "result text");

		string result = sut.ToString();

		await Expect.That(result).Is($"FAILED {expectationText}");
	}

	[Theory]
	[AutoData]
	public async Task ToString_Success_ShouldBeExpectationTextWithPrependedSucceeded(
		string expectationText)
	{
		ConstraintResult.Success sut = new(expectationText);

		string result = sut.ToString();

		await Expect.That(result).Is($"SUCCEEDED {expectationText}");
	}

	private class Dummy
	{
		public int Value { get; set; }
	}
}
