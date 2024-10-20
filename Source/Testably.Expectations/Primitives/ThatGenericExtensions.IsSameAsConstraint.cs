using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatGenericExtensions
{
	private readonly struct IsSameAsConstraint<T>(object? expected, string expectedExpression)
		: IExpectation<T?>
	{
		public ConstraintResult IsMetBy(T? actual)
		{
			if (ReferenceEquals(actual, expected))
			{
				return new ConstraintResult.Success<T?>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(),
				$"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> $"refers to {expectedExpression} {Formatter.Format(expected)}";
	}
}
