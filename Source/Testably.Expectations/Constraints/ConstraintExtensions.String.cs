using Testably.Expectations.Common;
using Testably.Expectations.Constraints.String;

namespace Testably.Expectations;

public static partial class ConstraintExtensions
{
	public static IConstraint<string?> StartsWith(this IConstraintBuilder<string?> builder, string expected)
		=> builder.Append(new StartsWithConstraint(expected));

	public static IConstraint<string?> EndsWith(this IConstraintBuilder<string?> builder, string expected)
		=> builder.Append(new EndsWithConstraint(expected));
}

