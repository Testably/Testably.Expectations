using Testably.Expectations.Common;
using Testably.Expectations.Constraints.Bool;

namespace Testably.Expectations;

public static partial class ConstraintExtensions
{
	public static IConstraint<bool> IsTrue(this IConstraintBuilder<bool> builder)
		=> builder.Append(new TrueConstraint());
	public static IConstraint<bool> IsFalse(this IConstraintBuilder<bool> builder)
		=> builder.Append(new FalseConstraint());

}

