using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Formatting;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatNullableBoolExtensions
{
	private readonly struct IsConstraint(bool? expected) : IConstraint<bool?>
	{
		public ConstraintResult IsMetBy(bool? actual)
		{
			if (expected.Equals(actual))
			{
				return new ConstraintResult.Success<bool?>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> $"is {Formatter.Format(expected)}";
	}
}
