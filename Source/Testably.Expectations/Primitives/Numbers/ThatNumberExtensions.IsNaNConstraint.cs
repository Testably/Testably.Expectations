using System;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Formatting;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatNumberExtensions
{
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
			=> "is NaN";
	}
}
