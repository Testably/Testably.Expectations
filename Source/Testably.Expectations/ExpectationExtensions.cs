using System;
using System.Diagnostics.CodeAnalysis;
using Testably.Expectations.Core;
using Testably.Expectations.Expectations;
using Testably.Expectations.Expectations.Action;
using Testably.Expectations.Expectations.Bool;
using Testably.Expectations.Expectations.Int;
using Testably.Expectations.Expectations.String;

namespace Testably.Expectations;

public static class ExpectationExtensions
{
	public static NullableExpectation<T> EqualTo<T>(this ShouldBe shouldBe, T expected)
		=> shouldBe.WithExpectation(new BeEqualTo<T>(expected));

	public static NullableExpectation<object?> Null(this ShouldBe shouldBe)
		=> shouldBe.WithExpectation(new BeNull<object?>());

	public static ExpectationWhich<object?, TType> OfType<TType>(this ShouldBe shouldBe)
		=> shouldBe.WithExpectationMapping(new BeOfType<TType>());

	#region Action

	public static ExpectationWhich<Action, TException> TypeOf<TException>(
		this ShouldThrow shouldThrow)
		where TException : Exception
		=> shouldThrow.WithExpectationMapping(new ThrowException<TException>());

	public static ExpectationWhich<Action, Exception> Exception(this ShouldThrow shouldThrow)
		=> shouldThrow.WithExpectationMapping(new ThrowException<Exception>());

	#endregion

	#region Bool

	public static Expectation<bool> False(this ShouldBe shouldBe)
		=> shouldBe.WithExpectation(new BeFalse());

	public static Expectation<bool> True(this ShouldBe shouldBe)
		=> shouldBe.WithExpectation(new BeTrue());

	#endregion

	#region Int

	public static Expectation<int> GreaterThan(this ShouldBe shouldBe, int expected)
		=> shouldBe.WithExpectation(new BeGreaterThan(expected));

	#endregion

	#region String

	public static Expectation<string?> With(this ShouldStart shouldStart, string expected)
		=> shouldStart.WithExpectation(new StartWith(expected));

	public static Expectation<string?> With(this ShouldEnd shouldEnd, string expected)
		=> shouldEnd.WithExpectation(new EndWith(expected));

	#endregion

	#region Convenience Shortcuts

	public static Expectation<TStart, Exception> WhichMessage<TStart>(
		this ExpectationWhich<TStart, Exception> which,
		NullableExpectation<string> expectation)
		=> which.Which(m => m.Message, expectation);

	#endregion
}
