using System;
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
	///     Verifies that the subject is seen as not a number (<see cref="float.NaN" />).
	/// </summary>
	public static AndOrExpectationResult<float, That<float>> BeNaN(this That<float> source)
		=> new(source.ExpectationBuilder.Add(new IsNaNConstraint<float>(float.IsNaN),
				b => b.AppendMethod(nameof(BeNaN))),
			source);

	/// <summary>
	///     Verifies that the subject is seen as not a number (<see cref="double.NaN" />).
	/// </summary>
	public static AndOrExpectationResult<double, That<double>> BeNaN(this That<double> source)
		=> new(source.ExpectationBuilder.Add(new IsNaNConstraint<double>(double.IsNaN),
				b => b.AppendMethod(nameof(BeNaN))),
			source);

	private readonly struct IsNaNConstraint<TNumber>(Func<TNumber, bool> isNaN)
		: IConstraint<TNumber>
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
