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

		await That(subject.ExpectationText).Should().Be(expectationText);
		await That(subject.ResultText).Should().Be(resultText);
	}

	[Theory]
	[AutoData]
	public async Task Failure_WithValue_ShouldStoreValueAndTexts(string expectationText,
		string resultText)
	{
		Dummy value = new() { Value = 1 };

		ConstraintResult.Failure<Dummy> subject = new(value, expectationText, resultText);

		await That(subject.Value).Should().Be(value).Equivalent();
		await That(subject.ExpectationText).Should().Be(expectationText);
		await That(subject.ResultText).Should().Be(resultText);
	}

	[Theory]
	[AutoData]
	public async Task Invert_FromFailure_ShouldKeepExpectationText(string expectationText,
		string resultText)
	{
		ConstraintResult.Failure subject = new(expectationText, resultText);

		ConstraintResult result = subject.Invert();

		await That(result).Should().Be<ConstraintResult.Success>()
			.Which(s => s.ExpectationText).Should(e => e.Be(expectationText));
	}

	[Theory]
	[AutoData]
	public async Task Invert_FromFailure_ShouldUpdateExpectationText(string expectationText,
		string resultText)
	{
		ConstraintResult.Failure subject = new("foo", "bar");

		ConstraintResult result = subject.Invert(_ => expectationText, _ => resultText);

		await That(result).Should().Be<ConstraintResult.Success>()
			.Which(s => s.ExpectationText).Should(e => e.Be(expectationText));
	}

	[Theory]
	[AutoData]
	public async Task Invert_FromFailureWithValue_ShouldIncludeValue(string expectationText,
		string resultText)
	{
		Dummy value = new() { Value = 1 };
		ConstraintResult.Failure<Dummy> subject = new(value, expectationText, resultText);

		ConstraintResult result = subject.Invert();

		await That(result).Should().Be<ConstraintResult.Success<Dummy>>()
			.Which(s => s.Value).Should(e => e.Be(value).Equivalent());
	}

	[Theory]
	[AutoData]
	public async Task Invert_FromFailureWithValue_ShouldKeepExpectationText(string expectationText,
		string resultText)
	{
		Dummy value = new() { Value = 1 };
		ConstraintResult.Failure<Dummy> subject = new(value, expectationText, resultText);

		ConstraintResult result = subject.Invert();

		await That(result).Should().Be<ConstraintResult.Success<Dummy>>()
			.Which(s => s.ExpectationText).Should(e => e.Be(expectationText));
	}

	[Theory]
	[AutoData]
	public async Task Invert_FromFailureWithValue_ShouldUpdateExpectationText(
		string expectationText,
		string resultText)
	{
		Dummy value = new() { Value = 1 };
		ConstraintResult.Failure<Dummy> subject = new(value, "foo", "bar");

		ConstraintResult result = subject.Invert(_ => expectationText, _ => resultText);

		await That(result).Should().Be<ConstraintResult.Success<Dummy>>()
			.Which(s => s.ExpectationText).Should(e => e.Be(expectationText));
	}

	[Theory]
	[AutoData]
	public async Task Invert_FromSuccess_ShouldKeepExpectationTextAndUseDefaultResultText(
		string expectationText)
	{
		ConstraintResult.Success subject = new(expectationText);

		ConstraintResult result = subject.Invert();

		await That(result).Should().Be<ConstraintResult.Failure>()
			.Which(s => s.ExpectationText).Should(e => e.Be(expectationText))
			.Which(s => s.ResultText).Should(e => e.Be("it did"));
	}

	[Theory]
	[AutoData]
	public async Task Invert_FromSuccess_ShouldUpdateExpectationAndDefaultResultText(
		string expectationText, string resultText)
	{
		ConstraintResult.Success subject = new("foo");

		ConstraintResult result = subject.Invert(_ => expectationText, _ => resultText);

		await That(result).Should().Be<ConstraintResult.Failure>()
			.Which(p => p.ExpectationText).Should(e => e.Be(expectationText))
			.Which(p => p.ResultText).Should(e => e.Be(resultText));
	}

	[Theory]
	[AutoData]
	public async Task Invert_FromSuccessWithValue_ShouldIncludeValue(string expectationText)
	{
		Dummy value = new() { Value = 1 };
		ConstraintResult.Success<Dummy> subject = new(value, expectationText);

		ConstraintResult result = subject.Invert();

		await That(result).Should().Be<ConstraintResult.Failure<Dummy>>()
			.Which(p => p.Value).Should(e => e.Be(value).Equivalent());
	}

	[Theory]
	[AutoData]
	public async Task Invert_FromSuccessWithValue_ShouldKeepExpectationTextAndUseDefaultResultText(
		string expectationText)
	{
		Dummy value = new() { Value = 1 };
		ConstraintResult.Success<Dummy> subject = new(value, expectationText);

		ConstraintResult result = subject.Invert();

		await That(result).Should().Be<ConstraintResult.Failure<Dummy>>()
			.Which(p => p.ExpectationText).Should(e => e.Be(expectationText))
			.Which(p => p.ResultText).Should(e => e.Be("it did"));
	}

	[Theory]
	[AutoData]
	public async Task Invert_FromSuccessWithValue_ShouldUpdateExpectationAndResultText(
		string expectationText, string resultText)
	{
		Dummy value = new() { Value = 1 };
		ConstraintResult.Success<Dummy> subject = new(value, "foo");

		ConstraintResult result = subject.Invert(_ => expectationText, _ => resultText);

		await That(result).Should().Be<ConstraintResult.Failure<Dummy>>()
			.Which(p => p.ExpectationText).Should(e => e.Be(expectationText))
			.Which(p => p.ResultText).Should(e => e.Be(resultText));
	}

	[Theory]
	[AutoData]
	public async Task Success_WithValue_ShouldStoreValue(string expectationText)
	{
		Dummy value = new() { Value = 1 };

		ConstraintResult.Success<Dummy> subject = new(value, expectationText);

		await That(subject.Value).Should().Be(value).Equivalent();
		await That(subject.ExpectationText).Should().Be(expectationText);
	}

	[Theory]
	[AutoData]
	public async Task ToString_Failure_ShouldBeExpectationTextWithPrependedFailed(
		string expectationText)
	{
		ConstraintResult.Failure subject = new(expectationText, "result text");

		string result = subject.ToString();

		await That(result).Should().Be($"FAILED {expectationText}");
	}

	[Theory]
	[AutoData]
	public async Task ToString_Success_ShouldBeExpectationTextWithPrependedSucceeded(
		string expectationText)
	{
		ConstraintResult.Success subject = new(expectationText);

		string result = subject.ToString();

		await That(result).Should().Be($"SUCCEEDED {expectationText}");
	}

	private sealed class Dummy
	{
		public int Value { get; set; }
	}
}
