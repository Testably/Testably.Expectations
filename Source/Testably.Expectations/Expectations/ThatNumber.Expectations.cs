using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;

namespace Testably.Expectations.Expectations;

public abstract partial class ThatNumber<TNumber, TSelf>
{
	private readonly struct IsExpectation(TNumber? expected) : IExpectation<TNumber>
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
	protected internal readonly struct IsNaNExpectation<T>(Func<T, bool> isNaN) : IExpectation<T>
	{
		public ExpectationResult IsMetBy(T actual)
		{
			if (isNaN(actual))
			{
				return new ExpectationResult.Success<T>(actual, ToString());
			}

			return new ExpectationResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> "is NaN";
	}
	private readonly struct IsNotExpectation(TNumber expected) : IExpectation<TNumber>
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
