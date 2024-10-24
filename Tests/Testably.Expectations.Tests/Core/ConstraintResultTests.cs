using Testably.Expectations.Core.Constraints;

namespace Testably.Expectations.Tests.Core;

public sealed class ConstraintResultTests
{
	[Theory]
	[AutoData]
	public async Task Failure_WithoutValue_ShouldStoreTexts(string expectationText,
		string resultText)
	{
		ConstraintResult.Failure subject = new(expectationText, resultText);

		await Expect.That(subject.ExpectationText).Should().Is(expectationText);
		await Expect.That(subject.ResultText).Should().Is(resultText);
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

		ConstraintResult.Failure<Dummy> subject = new(value, expectationText, resultText);

		await Expect.That(subject.Value).Should().BeEquivalentTo(value);
		await Expect.That(subject.ExpectationText).Should().Is(expectationText);
		await Expect.That(subject.ResultText).Should().Is(resultText);
	}

	[Theory]
	[AutoData]
	public async Task Invert_FromFailure_ShouldKeepExpectationText(string expectationText,
		string resultText)
	{
		ConstraintResult.Failure subject = new(expectationText, resultText);

		ConstraintResult result = subject.Invert();

		await Expect.That(result).Should().Be<ConstraintResult.Success>()
			.Which(s => s.ExpectationText, e => e.Is(expectationText));
	}

	[Theory]
	[AutoData]
	public async Task Invert_FromFailure_ShouldUpdateExpectationText(string expectationText,
		string resultText)
	{
		ConstraintResult.Failure subject = new("foo", "bar");

		ConstraintResult result = subject.Invert(_ => expectationText, _ => resultText);

		await Expect.That(result).Should().Be<ConstraintResult.Success>()
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
		ConstraintResult.Failure<Dummy> subject = new(value, expectationText, resultText);

		ConstraintResult result = subject.Invert();

		await Expect.That(result).Should().Be<ConstraintResult.Success<Dummy>>()
			.Which(s => s.Value, e => e.BeEquivalentTo(value));
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
		ConstraintResult.Failure<Dummy> subject = new(value, expectationText, resultText);

		ConstraintResult result = subject.Invert();

		await Expect.That(result).Should().Be<ConstraintResult.Success<Dummy>>()
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
		ConstraintResult.Failure<Dummy> subject = new(value, "foo", "bar");

		ConstraintResult result = subject.Invert(_ => expectationText, _ => resultText);

		await Expect.That(result).Should().Be<ConstraintResult.Success<Dummy>>()
			.Which(s => s.ExpectationText, e => e.Is(expectationText));
	}

	[Theory]
	[AutoData]
	public async Task Invert_FromSuccess_ShouldKeepExpectationTextAndUseDefaultResultText(
		string expectationText)
	{
		ConstraintResult.Success subject = new(expectationText);

		ConstraintResult result = subject.Invert();

		await Expect.That(result).Should().Be<ConstraintResult.Failure>()
			.Which(s => s.ExpectationText, e => e.Is(expectationText))
			.Which(s => s.ResultText, e => e.Is("it did"));
	}

	[Theory]
	[AutoData]
	public async Task Invert_FromSuccess_ShouldUpdateExpectationAndDefaultResultText(
		string expectationText, string resultText)
	{
		ConstraintResult.Success subject = new("foo");

		ConstraintResult result = subject.Invert(_ => expectationText, _ => resultText);

		await Expect.That(result).Should().Be<ConstraintResult.Failure>()
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
		ConstraintResult.Success<Dummy> subject = new(value, expectationText);

		ConstraintResult result = subject.Invert();

		await Expect.That(result).Should().Be<ConstraintResult.Failure<Dummy>>()
			.Which(p => p.Value, e => e.BeEquivalentTo(value));
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
		ConstraintResult.Success<Dummy> subject = new(value, expectationText);

		ConstraintResult result = subject.Invert();

		await Expect.That(result).Should().Be<ConstraintResult.Failure<Dummy>>()
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
		ConstraintResult.Success<Dummy> subject = new(value, "foo");

		ConstraintResult result = subject.Invert(_ => expectationText, _ => resultText);

		await Expect.That(result).Should().Be<ConstraintResult.Failure<Dummy>>()
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

		ConstraintResult.Success<Dummy> subject = new(value, expectationText);

		await Expect.That(subject.Value).Should().BeEquivalentTo(value);
		await Expect.That(subject.ExpectationText).Should().Is(expectationText);
	}

	[Theory]
	[AutoData]
	public async Task ToString_Failure_ShouldBeExpectationTextWithPrependedFailed(
		string expectationText)
	{
		ConstraintResult.Failure subject = new(expectationText, "result text");

		string result = subject.ToString();

		await Expect.That(result).Should().Is($"FAILED {expectationText}");
	}

	[Theory]
	[AutoData]
	public async Task ToString_Success_ShouldBeExpectationTextWithPrependedSucceeded(
		string expectationText)
	{
		ConstraintResult.Success subject = new(expectationText);

		string result = subject.ToString();

		await Expect.That(result).Should().Is($"SUCCEEDED {expectationText}");
	}

	private class Dummy
	{
		public int Value { get; set; }
	}
}
