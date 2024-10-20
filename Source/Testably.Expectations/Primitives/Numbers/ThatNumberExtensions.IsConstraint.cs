using System;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Formatting;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatNumberExtensions
{
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
			=> $"is {Formatter.Format(expected)}";
	}
}
