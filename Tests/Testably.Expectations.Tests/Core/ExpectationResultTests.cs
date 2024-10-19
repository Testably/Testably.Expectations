using AutoFixture.Xunit2;
using System.Threading.Tasks;
using Testably.Expectations.Core;
using Xunit;

namespace Testably.Expectations.Tests.Core;

public sealed class ExpectationResultTests
{
	[Theory]
	[AutoData]
	public async Task Failure_WithoutValue_ShouldStoreTexts(string expectationText, string resultText)
	{
		ExpectationResult.Failure sut = new(expectationText, resultText);

		await That(sut.ExpectationText).Is(expectationText);
		await That(sut.ResultText).Is(resultText);
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

		ExpectationResult.Failure<Dummy> sut = new(value, expectationText, resultText);

		await That(sut.Value).IsEquivalentTo(value);
		await That(sut.ExpectationText).Is(expectationText);
		await That(sut.ResultText).Is(resultText);
	}

	[Theory]
	[AutoData]
	public async Task Invert_FromFailure_ShouldKeepExpectationText(string expectationText,
		string resultText)
	{
		ExpectationResult.Failure sut = new(expectationText, resultText);

		ExpectationResult result = sut.Invert();

		await That(result).Is<ExpectationResult.Success>()
			.Which(s => s.ExpectationText,
				e => e.Is(expectationText));
	}

	//[Theory]
	//[AutoData]
	//public async Task Invert_FromFailure_ShouldUpdateExpectationText(string expectationText,
	//	string resultText)
	//{
	//	ExpectationResult.Failure sut = new("foo", "bar");

	//	ExpectationResult result = sut.Invert(_ => expectationText, _ => resultText);

	//	await Expect.That(result, Should.Be.OfType<ExpectationResult.Success>()
	//		.Which(p => p.ExpectationText).Is(expectationText));
	//}

	//[Theory]
	//[AutoData]
	//public async Task Invert_FromFailureWithValue_ShouldIncludeValue(string expectationText,
	//	string resultText)
	//{
	//	Dummy value = new()
	//	{
	//		Value = 1
	//	};
	//	ExpectationResult.Failure<Dummy> sut = new(value, expectationText, resultText);

	//	ExpectationResult result = sut.Invert();

	//	await Expect.That(result, Should.Be.OfType<ExpectationResult.Success<Dummy>>()
	//		.Which(p => p.Value).Is(value));
	//}

	//[Theory]
	//[AutoData]
	//public async Task Invert_FromFailureWithValue_ShouldKeepExpectationText(string expectationText,
	//	string resultText)
	//{
	//	Dummy value = new()
	//	{
	//		Value = 1
	//	};
	//	ExpectationResult.Failure<Dummy> sut = new(value, expectationText, resultText);

	//	ExpectationResult result = sut.Invert();

	//	await Expect.That(result, Should.Be.OfType<ExpectationResult.Success<Dummy>>()
	//		.Which(p => p.ExpectationText).Is(expectationText));
	//}

	//[Theory]
	//[AutoData]
	//public async Task Invert_FromFailureWithValue_ShouldUpdateExpectationText(string expectationText,
	//	string resultText)
	//{
	//	Dummy value = new()
	//	{
	//		Value = 1
	//	};
	//	ExpectationResult.Failure<Dummy> sut = new(value, "foo", "bar");

	//	ExpectationResult result = sut.Invert(_ => expectationText, _ => resultText);

	//	await Expect.That(result, Should.Be.OfType<ExpectationResult.Success<Dummy>>()
	//		.Which(p => p.ExpectationText).Is(expectationText));
	//}

	//[Theory]
	//[AutoData]
	//public async Task Invert_FromSuccess_ShouldKeepExpectationTextAndUseDefaultResultText(
	//	string expectationText)
	//{
	//	ExpectationResult.Success sut = new(expectationText);

	//	ExpectationResult result = sut.Invert();

	//	await Expect.That(result, Should.Be.OfType<ExpectationResult.Failure>()
	//		.Which(p => p.ExpectationText).Is(expectationText)).And()
	//		.Which(p => p.ResultText).Is("it did"));
	//}

	//[Theory]
	//[AutoData]
	//public async Task Invert_FromSuccess_ShouldUpdateExpectationAndDefaultResultText(
	//	string expectationText, string resultText)
	//{
	//	ExpectationResult.Success sut = new("foo");

	//	ExpectationResult result = sut.Invert(_ => expectationText, _ => resultText);

	//	await Expect.That(result, Should.Be.OfType<ExpectationResult.Failure>()
	//		.Which(p => p.ExpectationText).Is(expectationText)).And()
	//		.Which(p => p.ResultText).Is(resultText));
	//}

	//[Theory]
	//[AutoData]
	//public async Task Invert_FromSuccessWithValue_ShouldIncludeValue(string expectationText)
	//{
	//	Dummy value = new()
	//	{
	//		Value = 1
	//	};
	//	ExpectationResult.Success<Dummy> sut = new(value, expectationText);

	//	ExpectationResult result = sut.Invert();

	//	await Expect.That(result, Should.Be.OfType<ExpectationResult.Failure<Dummy>>()
	//		.Which(p => p.Value).Is(value));
	//}

	//[Theory]
	//[AutoData]
	//public async Task Invert_FromSuccessWithValue_ShouldKeepExpectationTextAndUseDefaultResultText(
	//	string expectationText)
	//{
	//	Dummy value = new()
	//	{
	//		Value = 1
	//	};
	//	ExpectationResult.Success<Dummy> sut = new(value, expectationText);

	//	ExpectationResult result = sut.Invert();

	//	await Expect.That(result, Should.Be.OfType<ExpectationResult.Failure<Dummy>>()
	//		.Which(p => p.ExpectationText).Is(expectationText)).And()
	//		.Which(p => p.ResultText).Is("it did"));
	//}

	//[Theory]
	//[AutoData]
	//public async Task Invert_FromSuccessWithValue_ShouldUpdateExpectationAndResultText(
	//	string expectationText, string resultText)
	//{
	//	Dummy value = new()
	//	{
	//		Value = 1
	//	};
	//	ExpectationResult.Success<Dummy> sut = new(value, "foo");

	//	ExpectationResult result = sut.Invert(_ => expectationText, _ => resultText);

	//	await Expect.That(result, Should.Be.OfType<ExpectationResult.Failure<Dummy>>()
	//		.Which(p => p.ExpectationText).Is(expectationText)).And()
	//		.Which(p => p.ResultText).Is(resultText));
	//}

	[Theory]
	[AutoData]
	public async Task Success_WithValue_ShouldStoreValue(string expectationText)
	{
		Dummy value = new()
		{
			Value = 1
		};

		ExpectationResult.Success<Dummy> sut = new(value, expectationText);

		await That(sut.Value).IsEquivalentTo(value);
		await That(sut.ExpectationText).Is(expectationText);
	}

	[Theory]
	[AutoData]
	public async Task ToString_Failure_ShouldBeExpectationTextWithPrependedFailed(string expectationText)
	{
		ExpectationResult.Failure sut = new(expectationText, "result text");

		string result = sut.ToString();

		await That(result).Is($"FAILED {expectationText}");
	}

	[Theory]
	[AutoData]
	public async Task ToString_Success_ShouldBeExpectationTextWithPrependedSucceeded(
		string expectationText)
	{
		ExpectationResult.Success sut = new(expectationText);

		string result = sut.ToString();

		await That(result).Is($"SUCCEEDED {expectationText}");
	}

	private class Dummy
	{
		public int Value { get; set; }
	}
}


