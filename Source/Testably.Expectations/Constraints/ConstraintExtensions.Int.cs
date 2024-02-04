using Testably.Expectations.Common;
using Testably.Expectations.Constraints.Int;

namespace Testably.Expectations;

public static partial class ConstraintExtensions
{
	public static IConstraint<int> IsGreaterThan(this IConstraintBuilder<int> builder, int expected)
		=> builder.Append(new GreaterThanConstraint(expected));

}

