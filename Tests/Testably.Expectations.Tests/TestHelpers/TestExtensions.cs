﻿using Testably.Expectations.Core;

namespace Testably.Expectations.Tests.TestHelpers;

public static class TestExtensions
{
	public static Expectation<object> AFailedTest(this ShouldBe shouldBe, string expectationText,
		string resultText)
		=> shouldBe.WithExpectation(
			new TestExpectation<object>(
				new ExpectationResult.Failure(expectationText, resultText)));

	public static Expectation<object> w(this ShouldBe shouldBe, string expectationText,
		string resultText)
		=> shouldBe.WithExpectation(
			new TestExpectation<object>(
				new ExpectationResult.Failure(expectationText, resultText)));

	public static ExpectationWhich<TSource, TSource> AMappedTest<TSource>(
		this ShouldBe shouldBe)
		=> shouldBe.WithExpectation(
			new MappedTestExpectation<TSource, TSource>());

	public static Expectation<object> ASuccessfulTest(this ShouldBe shouldBe)
		=> shouldBe.WithExpectation(new TestExpectation<object>(new ExpectationResult.Success()));

	private class TestExpectation<T> : IExpectation<T>
	{
		private readonly ExpectationResult _result;

		public TestExpectation(ExpectationResult result)
		{
			_result = result;
		}

		#region IExpectation<T> Members

		public ExpectationResult IsMetBy(T actual)
			=> _result;

		#endregion
	}

	private class MappedTestExpectation<TSource, TProperty> : IExpectation<TSource, TProperty>
	{
		#region IExpectation<TSource,TProperty> Members

		/// <inheritdoc />
		public ExpectationResult IsMetBy(TSource actual)
			=> new ExpectationResult.Success<TSource>(actual);

		#endregion
	}
}
