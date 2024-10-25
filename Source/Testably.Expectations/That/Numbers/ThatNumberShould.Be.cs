using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatNumberShould
{
	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrExpectationResult<TNumber, That<TNumber>> Be<TNumber>(
		this That<TNumber> source,
		TNumber? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		where TNumber : struct, IComparable<TNumber>
		=> new(source.ExpectationBuilder.Add(new IsConstraint<TNumber>(expected),
				b => b.AppendMethod(nameof(Be), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrExpectationResult<TNumber?, That<TNumber?>> Be<TNumber>(
		this That<TNumber?> source,
		TNumber? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		where TNumber : struct, IComparable<TNumber>
		=> new(source.ExpectationBuilder.Add(new IsConstraint<TNumber>(expected),
				b => b.AppendMethod(nameof(Be), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the subject is not equal to the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrExpectationResult<TNumber, That<TNumber>> NotBe<TNumber>(
		this That<TNumber> source,
		TNumber expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		where TNumber : struct, IComparable<TNumber>
		=> new(source.ExpectationBuilder.Add(new IsNotConstraint<TNumber>(expected),
				b => b.AppendMethod(nameof(NotBe), doNotPopulateThisValue)),
			source);

	private readonly struct IsConstraint<TNumber>(TNumber? expected) : IConstraint<TNumber>
		where TNumber : struct, IComparable<TNumber>
	{
		public ConstraintResult IsMetBy(TNumber actual)
		{
			if (expected?.CompareTo(actual) == 0)
			{
				return new ConstraintResult.Success<TNumber>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> $"be {Formatter.Format(expected)}";
	}

	private readonly struct IsNotConstraint<TNumber>(TNumber expected) : IConstraint<TNumber>
		where TNumber : struct, IComparable<TNumber>
	{
		public ConstraintResult IsMetBy(TNumber actual)
		{
			if (expected.CompareTo(actual) != 0)
			{
				return new ConstraintResult.Success<TNumber>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> $"not be {Formatter.Format(expected)}";
	}
}
