using System;
using Testably.Expectations.Common;
using Testably.Expectations.Constraints.Action;

namespace Testably.Expectations;

public static partial class ConstraintExtensions
{
	public static IConstraint<TException?> Throws<TException>(this IConstraintBuilder<Action> builder)
		where TException : Exception
		=> builder.Append(new ThrowsConstraint<TException>());
	public static IConstraint<Action> ExecuteWithin(this IConstraintBuilder<Action> builder, TimeSpan interval)
		=> throw new NotImplementedException();
}

