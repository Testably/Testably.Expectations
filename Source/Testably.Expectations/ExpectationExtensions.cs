using System;
using System.Diagnostics;
using Testably.Expectations.Core;
using Testably.Expectations.Expectations;
using Testably.Expectations.Expectations.Action;
using Testably.Expectations.Expectations.Bool;
using Testably.Expectations.Expectations.Int;
using Testably.Expectations.Expectations.String;

namespace Testably.Expectations;

/// <summary>
///     Extension methods for creating expectations.
/// </summary>
[StackTraceHidden]
public static class ExpectationExtensions
{
	/// <summary>
	///     Expect the actual value to be equal to <paramref name="expected" />.
	/// </summary>
	public static NullableExpectation<T?> EqualTo<T>(this ShouldBe shouldBe, T expected)
		=> shouldBe.WithExpectation(new BeEqualTo<T?>(expected));

	/// <summary>
	///     Expect the <see cref="Action" /> to throw an exception.
	/// </summary>
	public static ExpectationWhichShould<Action, Exception> Exception(this ShouldThrow shouldThrow)
		=> shouldThrow.WithExpectation(new ThrowException<Exception>());

	/// <summary>
	///     Expect the actual value to be <see langword="false" />.
	/// </summary>
	public static Expectation<bool> False(this ShouldBe shouldBe)
		=> shouldBe.WithExpectation(new BeFalse());

	/// <summary>
	///     Expect the actual value to be greater than <paramref name="expected" />.
	/// </summary>
	public static Expectation<int> GreaterThan(this ShouldBe shouldBe, int expected)
		=> shouldBe.WithExpectation(new BeGreaterThan(expected));

	/// <summary>
	///     Expect the actual value to be <see langword="null" />.
	/// </summary>
	public static NullableExpectation<object?> Null(this ShouldBe shouldBe)
		=> shouldBe.WithExpectation(new BeNull<object?>());

	/// <summary>
	///     Expect the actual value to be of type <typeparamref name="TType" />.
	/// </summary>
	public static ExpectationWhichShould<object?, TType> OfType<TType>(this ShouldBe shouldBe)
		=> shouldBe.WithExpectation(new BeOfType<TType>());

	/// <summary>
	///     Expect the actual value to be <see langword="true" />.
	/// </summary>
	public static Expectation<bool> True(this ShouldBe shouldBe)
		=> shouldBe.WithExpectation(new BeTrue());

	/// <summary>
	///     Expect the <see cref="Action" /> to throw an exception of type <typeparamref name="TException" />.
	/// </summary>
	public static ExpectationWhichShould<Action, TException> TypeOf<TException>(
		this ShouldThrow shouldThrow)
		where TException : Exception
		=> shouldThrow.WithExpectation(new ThrowException<TException>());

	/// <summary>
	///     Expect the <typeparamref name="TException" /> to have a message that meets the <paramref name="expectation" />.
	/// </summary>
	public static Expectation<TStart, TException> WhichMessage<TStart, TException>(
		this ExpectationWhichShould<TStart, TException> whichShould,
		NullableExpectation<string?> expectation)
		where TException : Exception
		=> whichShould.Which(m => m.Message, expectation);

	/// <summary>
	///     Expect the actual value to start with the <paramref name="expected" /> string.
	/// </summary>
	public static Expectation<string?> With(this ShouldStart shouldStart, string expected)
		=> shouldStart.WithExpectation(new StartWith(expected));

	/// <summary>
	///     Expect the actual value to end with the <paramref name="expected" /> string.
	/// </summary>
	public static Expectation<string?> With(this ShouldEnd shouldEnd, string expected)
		=> shouldEnd.WithExpectation(new EndWith(expected));
}
