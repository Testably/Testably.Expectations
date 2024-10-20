using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Core.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on numeric values.
/// </summary>
public static partial class ThatNumberExtensions
{
	/// <summary>
	///     Verifies that the actual value is equal to the specified <paramref name="expected" /> value.
	/// </summary>
	public static AssertionResult<TNumber, That<TNumber>> Is<TNumber>(this That<TNumber> source,
		TNumber? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		where TNumber : struct, IComparable<TNumber>
		=> new(source.ExpectationBuilder.Add(new IsExpectation<TNumber>(expected),
				b => b.AppendMethod(nameof(Is), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the actual value is equal to the specified <paramref name="expected" /> value.
	/// </summary>
	public static AssertionResult<TNumber?, That<TNumber?>> Is<TNumber>(this That<TNumber?> source,
		TNumber? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		where TNumber : struct, IComparable<TNumber>
		=> new(source.ExpectationBuilder.Add(new IsExpectation<TNumber>(expected),
				b => b.AppendMethod(nameof(Is), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the actual value is not equal to the specified <paramref name="expected" /> value.
	/// </summary>
	public static AssertionResult<TNumber, That<TNumber>> IsNot<TNumber>(this That<TNumber> source,
		TNumber expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		where TNumber : struct, IComparable<TNumber>
		=> new(source.ExpectationBuilder.Add(new IsNotExpectation<TNumber>(expected),
				b => b.AppendMethod(nameof(IsNot), doNotPopulateThisValue)),
			source);
	private readonly struct IsExpectation<TNumber>(TNumber? expected) : IExpectation<TNumber>
		where TNumber : struct, IComparable<TNumber>
	{
		public ExpectationResult IsMetBy(TNumber actual)
		{
			if (expected?.CompareTo(actual) == 0)
			{
				return new ExpectationResult.Success<TNumber>(actual, ToString());
			}

			return new ExpectationResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> $"is {Formatter.Format(expected)}";
	}
	private readonly struct IsNotExpectation<TNumber>(TNumber expected) : IExpectation<TNumber>
		where TNumber : struct, IComparable<TNumber>
	{
		public ExpectationResult IsMetBy(TNumber actual)
		{
			if (expected.CompareTo(actual) != 0)
			{
				return new ExpectationResult.Success<TNumber>(actual, ToString());
			}

			return new ExpectationResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> $"is not {Formatter.Format(expected)}";
	}
}
