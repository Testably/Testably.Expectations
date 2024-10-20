using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatObjectExtensions
{
	private readonly struct IsEquivalentToConstraint(object? expected) : IExpectation<object?>
	{
		public ConstraintResult IsMetBy(object? actual)
		{
			if (actual == expected)
			{
				return new ConstraintResult.Success<object?>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(),
				$"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> $"is equivalent to {Formatter.Format(expected)}";
	}
}
