using System;

using Testably.Expectations.Common;
using Testably.Expectations.Constraints;

namespace Testably.Expectations;

public static partial class ConstraintExtensions
{
	public static INullableConstraint<TActual> IsNull<TActual>(this IConstraint<TActual> builder) => new NullConstraint<TActual>();
	public static IConstraint<TActual> IsNotNull<TActual>(this IConstraint<TActual> builder) => new NotNullConstraint<TActual>();
	public static IConstraint<TActual> And<TActual>(this IConstraint<TActual> builder) => new AndConstraint<TActual>(builder);
	public static IConstraint<TActual> And<TActual>(this Func<IConstraint<TActual>, IConstraint<TActual>> builder) => new AndConstraint<TActual>(builder.Invoke(new Constraint<TActual>()));
}

