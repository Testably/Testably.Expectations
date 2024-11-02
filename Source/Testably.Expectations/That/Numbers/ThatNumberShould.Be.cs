﻿using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Formatting;
using Testably.Expectations.Options;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatNumberShould
{
	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static NumberToleranceResult<TNumber, IThat<TNumber>> Be<TNumber>(
		this IThat<TNumber> source,
		TNumber? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		where TNumber : struct, IComparable<TNumber>
	{
		NumberTolerance<TNumber> options = new ();
		return new NumberToleranceResult<TNumber, IThat<TNumber>>(source.ExpectationBuilder
				.AddConstraint(new IsValueConstraint<TNumber>(expected, options))
				.AppendMethodStatement(nameof(Be), doNotPopulateThisValue),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<TNumber?, IThat<TNumber?>> Be<TNumber>(
		this IThat<TNumber?> source,
		TNumber? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		where TNumber : struct, IComparable<TNumber>
	{
		NumberTolerance<TNumber> options = new ();
		return new AndOrResult<TNumber?, IThat<TNumber?>>(source.ExpectationBuilder
				.AddConstraint(new IsValueConstraint<TNumber>(expected, options))
				.AppendMethodStatement(nameof(Be), doNotPopulateThisValue),
			source);
	}

	/// <summary>
	///     Verifies that the subject is not equal to the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<TNumber, IThat<TNumber>> NotBe<TNumber>(
		this IThat<TNumber> source,
		TNumber? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		where TNumber : struct, IComparable<TNumber>
		=> new(source.ExpectationBuilder
				.AddConstraint(new IsNotValueConstraint<TNumber>(expected))
				.AppendMethodStatement(nameof(NotBe), doNotPopulateThisValue),
			source);

	private readonly struct IsValueConstraint<TNumber>(TNumber? expected,
		NumberTolerance<TNumber> options)
		: IValueConstraint<TNumber>
		where TNumber : struct, IComparable<TNumber>
	{
		public ConstraintResult IsMetBy(TNumber actual)
		{
			if (options.IsWithinTolerance(actual, expected))
			{
				return new ConstraintResult.Success<TNumber>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> $"be {Formatter.Format(expected)}{options}";
	}

	private readonly struct IsNotValueConstraint<TNumber>(TNumber? expected)
		: IValueConstraint<TNumber>
		where TNumber : struct, IComparable<TNumber>
	{
		public ConstraintResult IsMetBy(TNumber actual)
		{
			if (expected?.CompareTo(actual) != 0)
			{
				return new ConstraintResult.Success<TNumber>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> $"not be {Formatter.Format(expected)}";
	}
}
