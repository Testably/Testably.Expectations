//using AutoFixture.Xunit2;
//using Testably.Expectations.Core;
//using Xunit;

//namespace Testably.Expectations.Tests.Core;

//public sealed class ExpectationResultTests
//{
//	[Theory]
//	[AutoData]
//	public void Failure_WithoutValue_ShouldStoreTexts(string expectationText, string resultText)
//	{
//		ExpectationResult.Failure sut = new(expectationText, resultText);

//		ExpectVoid.That(sut.ExpectationText, Should.Be.EqualTo(expectationText));
//		ExpectVoid.That(sut.ResultText, Should.Be.EqualTo(resultText));
//	}

//	[Theory]
//	[AutoData]
//	public void Failure_WithValue_ShouldStoreValueAndTexts(string expectationText,
//		string resultText)
//	{
//		Dummy value = new()
//		{
//			Value = 1
//		};

//		ExpectationResult.Failure<Dummy> sut = new(value, expectationText, resultText);

//		ExpectVoid.That(sut.Value, Should.Be.EqualTo(value));
//		ExpectVoid.That(sut.ExpectationText, Should.Be.EqualTo(expectationText));
//		ExpectVoid.That(sut.ResultText, Should.Be.EqualTo(resultText));
//	}

//	[Theory]
//	[AutoData]
//	public void Invert_FromFailure_ShouldKeepExpectationText(string expectationText,
//		string resultText)
//	{
//		ExpectationResult.Failure sut = new(expectationText, resultText);

//		ExpectationResult result = sut.Invert();

//		ExpectVoid.That(result, Should.Be.OfType<ExpectationResult.Success>()
//			.Which(p => p.ExpectationText, Should.Be.EqualTo(expectationText)));
//	}

//	[Theory]
//	[AutoData]
//	public void Invert_FromFailure_ShouldUpdateExpectationText(string expectationText,
//		string resultText)
//	{
//		ExpectationResult.Failure sut = new("foo", "bar");

//		ExpectationResult result = sut.Invert(_ => expectationText, _ => resultText);

//		ExpectVoid.That(result, Should.Be.OfType<ExpectationResult.Success>()
//			.Which(p => p.ExpectationText, Should.Be.EqualTo(expectationText)));
//	}

//	[Theory]
//	[AutoData]
//	public void Invert_FromFailureWithValue_ShouldIncludeValue(string expectationText,
//		string resultText)
//	{
//		Dummy value = new()
//		{
//			Value = 1
//		};
//		ExpectationResult.Failure<Dummy> sut = new(value, expectationText, resultText);

//		ExpectationResult result = sut.Invert();

//		ExpectVoid.That(result, Should.Be.OfType<ExpectationResult.Success<Dummy>>()
//			.Which(p => p.Value, Should.Be.EqualTo(value)));
//	}

//	[Theory]
//	[AutoData]
//	public void Invert_FromFailureWithValue_ShouldKeepExpectationText(string expectationText,
//		string resultText)
//	{
//		Dummy value = new()
//		{
//			Value = 1
//		};
//		ExpectationResult.Failure<Dummy> sut = new(value, expectationText, resultText);

//		ExpectationResult result = sut.Invert();

//		ExpectVoid.That(result, Should.Be.OfType<ExpectationResult.Success<Dummy>>()
//			.Which(p => p.ExpectationText, Should.Be.EqualTo(expectationText)));
//	}

//	[Theory]
//	[AutoData]
//	public void Invert_FromFailureWithValue_ShouldUpdateExpectationText(string expectationText,
//		string resultText)
//	{
//		Dummy value = new()
//		{
//			Value = 1
//		};
//		ExpectationResult.Failure<Dummy> sut = new(value, "foo", "bar");

//		ExpectationResult result = sut.Invert(_ => expectationText, _ => resultText);

//		ExpectVoid.That(result, Should.Be.OfType<ExpectationResult.Success<Dummy>>()
//			.Which(p => p.ExpectationText, Should.Be.EqualTo(expectationText)));
//	}

//	[Theory]
//	[AutoData]
//	public void Invert_FromSuccess_ShouldKeepExpectationTextAndUseDefaultResultText(
//		string expectationText)
//	{
//		ExpectationResult.Success sut = new(expectationText);

//		ExpectationResult result = sut.Invert();

//		ExpectVoid.That(result, Should.Be.OfType<ExpectationResult.Failure>()
//			.Which(p => p.ExpectationText, Should.Be.EqualTo(expectationText)).And()
//			.Which(p => p.ResultText, Should.Be.EqualTo("it did")));
//	}

//	[Theory]
//	[AutoData]
//	public void Invert_FromSuccess_ShouldUpdateExpectationAndDefaultResultText(
//		string expectationText, string resultText)
//	{
//		ExpectationResult.Success sut = new("foo");

//		ExpectationResult result = sut.Invert(_ => expectationText, _ => resultText);

//		ExpectVoid.That(result, Should.Be.OfType<ExpectationResult.Failure>()
//			.Which(p => p.ExpectationText, Should.Be.EqualTo(expectationText)).And()
//			.Which(p => p.ResultText, Should.Be.EqualTo(resultText)));
//	}

//	[Theory]
//	[AutoData]
//	public void Invert_FromSuccessWithValue_ShouldIncludeValue(string expectationText)
//	{
//		Dummy value = new()
//		{
//			Value = 1
//		};
//		ExpectationResult.Success<Dummy> sut = new(value, expectationText);

//		ExpectationResult result = sut.Invert();

//		ExpectVoid.That(result, Should.Be.OfType<ExpectationResult.Failure<Dummy>>()
//			.Which(p => p.Value, Should.Be.EqualTo(value)));
//	}

//	[Theory]
//	[AutoData]
//	public void Invert_FromSuccessWithValue_ShouldKeepExpectationTextAndUseDefaultResultText(
//		string expectationText)
//	{
//		Dummy value = new()
//		{
//			Value = 1
//		};
//		ExpectationResult.Success<Dummy> sut = new(value, expectationText);

//		ExpectationResult result = sut.Invert();

//		ExpectVoid.That(result, Should.Be.OfType<ExpectationResult.Failure<Dummy>>()
//			.Which(p => p.ExpectationText, Should.Be.EqualTo(expectationText)).And()
//			.Which(p => p.ResultText, Should.Be.EqualTo("it did")));
//	}

//	[Theory]
//	[AutoData]
//	public void Invert_FromSuccessWithValue_ShouldUpdateExpectationAndResultText(
//		string expectationText, string resultText)
//	{
//		Dummy value = new()
//		{
//			Value = 1
//		};
//		ExpectationResult.Success<Dummy> sut = new(value, "foo");

//		ExpectationResult result = sut.Invert(_ => expectationText, _ => resultText);

//		ExpectVoid.That(result, Should.Be.OfType<ExpectationResult.Failure<Dummy>>()
//			.Which(p => p.ExpectationText, Should.Be.EqualTo(expectationText)).And()
//			.Which(p => p.ResultText, Should.Be.EqualTo(resultText)));
//	}

//	[Theory]
//	[AutoData]
//	public void Success_WithValue_ShouldStoreValue(string expectationText)
//	{
//		Dummy value = new()
//		{
//			Value = 1
//		};

//		ExpectationResult.Success<Dummy> sut = new(value, expectationText);

//		ExpectVoid.That(sut.Value, Should.Be.EqualTo(value));
//		ExpectVoid.That(sut.ExpectationText, Should.Be.EqualTo(expectationText));
//	}

//	[Theory]
//	[AutoData]
//	public void ToString_Failure_ShouldBeExpectationTextWithPrependedFailed(string expectationText)
//	{
//		ExpectationResult.Failure sut = new(expectationText, "result text");

//		string result = sut.ToString();

//		ExpectVoid.That(result, Should.Be.EqualTo($"FAILED {expectationText}"));
//	}

//	[Theory]
//	[AutoData]
//	public void ToString_Success_ShouldBeExpectationTextWithPrependedSucceeded(
//		string expectationText)
//	{
//		ExpectationResult.Success sut = new(expectationText);

//		string result = sut.ToString();

//		ExpectVoid.That(result, Should.Be.EqualTo($"SUCCEEDED {expectationText}"));
//	}

//	private class Dummy
//	{
//		public int Value { get; set; }
//	}
//}
