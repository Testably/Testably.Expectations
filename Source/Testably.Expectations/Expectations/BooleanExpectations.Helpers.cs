using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;

namespace Testably.Expectations.Expectations;

public sealed partial class BooleanExpectations
{
	internal readonly struct ImpliesExpectation(bool consequent) : IExpectation<bool>
	{
		public ExpectationResult IsMetBy(bool actual)
		{
			if (!actual || consequent)
			{
				return new ExpectationResult.Success<bool>(actual, ToString());
			}

			return new ExpectationResult.Failure(ToString(), "it did not");
		}

		public override string ToString()
			=> $"implies {Formatter.Format(consequent)}";
	}

	internal readonly struct IsNotExpectation(bool unexpected) : IExpectation<bool>
	{
		public ExpectationResult IsMetBy(bool actual)
		{
			if (!unexpected.Equals(actual))
			{
				return new ExpectationResult.Success<bool>(actual, ToString());
			}

			return new ExpectationResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> $"is not {Formatter.Format(unexpected)}";
	}

	internal readonly struct NullableIsNotExpectation(bool? unexpected) : IExpectation<bool?>
	{
		public ExpectationResult IsMetBy(bool? actual)
		{
			if (!unexpected.Equals(actual))
			{
				return new ExpectationResult.Success<bool?>(actual, ToString());
			}

			return new ExpectationResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> $"is not {Formatter.Format(unexpected)}";
	}

	internal readonly struct NullableIsExpectation(bool? expected) : IExpectation<bool?>
	{
		public ExpectationResult IsMetBy(bool? actual)
		{
			if (expected.Equals(actual))
			{
				return new ExpectationResult.Success<bool?>(actual, ToString());
			}

			return new ExpectationResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> $"is {Formatter.Format(expected)}";
	}

	internal readonly struct IsExpectation(bool expected) : IExpectation<bool>
	{
		public ExpectationResult IsMetBy(bool actual)
		{
			if (expected.Equals(actual))
			{
				return new ExpectationResult.Success<bool>(actual, ToString());
			}

			return new ExpectationResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> $"is {Formatter.Format(expected)}";
	}
}
