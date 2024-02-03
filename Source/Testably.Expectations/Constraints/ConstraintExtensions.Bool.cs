using Testably.Expectations.Common;
using Testably.Expectations.Constraints.Bool;

namespace Testably.Expectations;

public static partial class ConstraintExtensions
{
	public static IConstraint<bool> IsTrue(this IConstraint<bool> builder) => new TrueConstraint();
	public static IConstraint<bool> IsFalse(this IConstraint<bool> builder) => new FalseConstraint();

}

