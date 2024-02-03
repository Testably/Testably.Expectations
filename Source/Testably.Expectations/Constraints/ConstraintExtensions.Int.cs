using Testably.Expectations.Common;
using Testably.Expectations.Constraints.Int;

namespace Testably.Expectations;

public static partial class ConstraintExtensions
{
	public static IConstraint<int> IsGreaterThan(this IConstraint<int> builder, int expected) => new GreaterThanConstraint(expected);

}

