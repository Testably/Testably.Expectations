using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Core.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatNumberExtensions
{
	/// <summary>
	///     Verifies that the actual value is seen as not a number (<see cref="float.NaN" />).
	/// </summary>
	public static AssertionResult<float, That<float>> IsNaN(this That<float> source)
		=> new(source.ExpectationBuilder.Add(new IsNaNExpectation<float>(float.IsNaN),
				b => b.AppendMethod(nameof(IsNaN))),
			source);

	/// <summary>
	///     Verifies that the actual value is seen as not a number (<see cref="double.NaN" />).
	/// </summary>
	public static AssertionResult<double, That<double>> IsNaN(this That<double> source)
		=> new(source.ExpectationBuilder.Add(new IsNaNExpectation<double>(double.IsNaN),
				b => b.AppendMethod(nameof(IsNaN))),
			source);

	private readonly struct IsNaNExpectation<TNumber>(Func<TNumber, bool> isNaN) : IExpectation<TNumber>
		where TNumber : struct, IComparable<TNumber>
	{
		public ExpectationResult IsMetBy(TNumber actual)
		{
			if (isNaN(actual))
			{
				return new ExpectationResult.Success<TNumber>(actual, ToString());
			}

			return new ExpectationResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> "is NaN";
	}
}
