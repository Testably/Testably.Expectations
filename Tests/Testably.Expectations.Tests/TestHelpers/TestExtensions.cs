﻿using System.Runtime.CompilerServices;
using Testably.Expectations.Core;

namespace Testably.Expectations.Tests.TestHelpers;

public static class TestExtensions
{
	public static Expectation<object?> AFailedTest(this ShouldBe shouldBe,
		string expectationText,
		string resultText)
		=> shouldBe.WithExpectation(
			new TestExpectation<object?>(
				new ExpectationResult.Failure(expectationText, resultText)));

	public static Expectation<object?> Variable(this ShouldBe shouldBe,
		bool variableValue,
		[CallerArgumentExpression(nameof(variableValue))] string variableExpression = "")
		=> shouldBe.WithExpectation(
			new TestExpectation<object?>(variableValue
				? new ExpectationResult.Success(variableExpression)
				: new ExpectationResult.Failure(variableExpression, "it did")));

	public static ExpectationWhichShould<TSource, TSource> AMappedTest<TSource>(
		this ShouldBe shouldBe,
		string expectationText)
		=> shouldBe.WithExpectation(
			new MappedTestExpectation<TSource, TSource>(expectationText));

	public static Expectation<object> AnExpectation(this ShouldBe shouldBe, bool isSuccessful)
		=> shouldBe.WithExpectation(
			new TestExpectation<object>(isSuccessful, $"to be {isSuccessful}",
				$"found {!isSuccessful}"));

	public static NullableExpectation<object> ANullableExpectation(this ShouldBe shouldBe,
		bool isSuccessful)
		=> shouldBe.WithExpectation(
			new NullableTestExpectation<object>(isSuccessful, $"to be {isSuccessful}",
				$"found {!isSuccessful}"));

	public static Expectation<object?> ASuccessfulTest(this ShouldBe shouldBe,
		string expectationText)
		=> shouldBe.WithExpectation(
			new TestExpectation<object?>(new ExpectationResult.Success(expectationText)));

	private class TestExpectation<T> : IExpectation<T>
	{
		private readonly ExpectationResult _result;

		public TestExpectation(ExpectationResult result)
		{
			_result = result;
		}

		public TestExpectation(bool isSuccessful,
			string expectationText = "",
			string resultText = "")
		{
			_result = isSuccessful
				? new ExpectationResult.Success(expectationText)
				: new ExpectationResult.Failure(expectationText, resultText);
		}

		#region IExpectation<T> Members

		public ExpectationResult IsMetBy(T actual)
			=> _result;

		#endregion

		/// <inheritdoc />
		public override string ToString()
			=> _result is ExpectationResult.Success ? "Success" : "Failure";
	}

	private class NullableTestExpectation<T> : INullableExpectation<T>
	{
		private readonly ExpectationResult _result;

		public NullableTestExpectation(bool isSuccessful,
			string expectationText,
			string resultText)
		{
			_result = isSuccessful
				? new ExpectationResult.Success(expectationText)
				: new ExpectationResult.Failure(expectationText, resultText);
		}

		#region INullableExpectation<T> Members

		public ExpectationResult IsMetBy(T actual)
			=> _result;

		#endregion

		/// <inheritdoc />
		public override string ToString()
			=> _result is ExpectationResult.Success ? "Success" : "Failure";
	}

	private class MappedTestExpectation<TSource, TProperty> : IExpectation<TSource, TProperty>
	{
		private readonly string _expectationText;

		public MappedTestExpectation(string expectationText)
		{
			_expectationText = expectationText;
		}

		#region IExpectation<TSource,TProperty> Members

		/// <inheritdoc />
		public ExpectationResult IsMetBy(TSource actual)
			=> new ExpectationResult.Success<TSource>(actual, _expectationText);

		#endregion

		/// <inheritdoc />
		public override string ToString()
			=> $"Map({typeof(TSource).Name} -> {typeof(TProperty).Name})";
	}
}
