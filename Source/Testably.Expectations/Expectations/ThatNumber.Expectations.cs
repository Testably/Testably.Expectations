using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;

namespace Testably.Expectations.Expectations;

public sealed partial class ThatNumber<TNumber>
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
