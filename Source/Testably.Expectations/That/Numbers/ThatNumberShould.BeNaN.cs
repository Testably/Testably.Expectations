﻿using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatNumberShould
{
	/// <summary>
	///     Verifies that the subject is seen as not a number (<see cref="float.NaN" />).
	/// </summary>
	public static AndOrExpectationResult<float, IThat<float>> BeNaN(this IThat<float> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new IsNaNValueConstraint<float>(float.IsNaN))
				.AppendMethodStatement(nameof(BeNaN)),
			source);

	/// <summary>
	///     Verifies that the subject is seen as not a number (<see cref="double.NaN" />).
	/// </summary>
	public static AndOrExpectationResult<double, IThat<double>> BeNaN(this IThat<double> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new IsNaNValueConstraint<double>(double.IsNaN))
				.AppendMethodStatement(nameof(BeNaN)),
			source);

	private readonly struct IsNaNValueConstraint<TNumber>(Func<TNumber, bool> isNaN)
		: IValueConstraint<TNumber>
		where TNumber : struct, IComparable<TNumber>
	{
		public ConstraintResult IsMetBy(TNumber actual)
		{
			if (isNaN(actual))
			{
				return new ConstraintResult.Success<TNumber>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> "be NaN";
	}
}
