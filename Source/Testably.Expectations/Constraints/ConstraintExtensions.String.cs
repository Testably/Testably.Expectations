using Testably.Expectations.Common;
using Testably.Expectations.Constraints.String;

namespace Testably.Expectations;

public static partial class ConstraintExtensions
{
	public static IConstraint<string?> StartsWith(this IConstraint<string?> builder, string expected) => new StartsWithConstraint(expected);
	public static IConstraint<string?> EndsWith(this IConstraint<string?> builder, string expected) => new EndsWithConstraint(expected);
}

