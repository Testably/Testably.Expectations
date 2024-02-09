using System;
using Testably.Expectations.Core;
using Testably.Expectations.Expectations;
using Testably.Expectations.Expectations.Action;
using Testably.Expectations.Expectations.Bool;
using Testably.Expectations.Expectations.Int;
using Testably.Expectations.Expectations.String;

namespace Testably.Expectations;

public static class ExpectationExtensions
{
	public static NullableExpectation<T?> EqualTo<T>(this ShouldBe shouldBe, T expected)
		=> shouldBe.WithExpectation(new BeEqualTo<T?>(expected));

	public static ExpectationWhich<Action, Exception> Exception(this ShouldThrow shouldThrow)
		=> shouldThrow.WithExpectation(new ThrowException<Exception>());

	public static Expectation<bool> False(this ShouldBe shouldBe)
		=> shouldBe.WithExpectation(new BeFalse());

	public static Expectation<int> GreaterThan(this ShouldBe shouldBe, int expected)
		=> shouldBe.WithExpectation(new BeGreaterThan(expected));

	public static NullableExpectation<object?> Null(this ShouldBe shouldBe)
		=> shouldBe.WithExpectation(new BeNull<object?>());

	public static ExpectationWhich<object?, TType> OfType<TType>(this ShouldBe shouldBe)
		=> shouldBe.WithExpectation(new BeOfType<TType>());

	public static Expectation<bool> True(this ShouldBe shouldBe)
		=> shouldBe.WithExpectation(new BeTrue());

	public static ExpectationWhich<Action, TException> TypeOf<TException>(
		this ShouldThrow shouldThrow)
		where TException : Exception
		=> shouldThrow.WithExpectation(new ThrowException<TException>());

	public static Expectation<TStart, TException> WhichMessage<TStart, TException>(
		this ExpectationWhich<TStart, TException> which,
		NullableExpectation<string?> expectation)
		where TException : Exception
		=> which.Which(m => m.Message, expectation);

	public static Expectation<string?> With(this ShouldStart shouldStart, string expected)
		=> shouldStart.WithExpectation(new StartWith(expected));

	public static Expectation<string?> With(this ShouldEnd shouldEnd, string expected)
		=> shouldEnd.WithExpectation(new EndWith(expected));
}
