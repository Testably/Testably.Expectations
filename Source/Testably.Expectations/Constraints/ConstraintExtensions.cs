using System;

using Testably.Expectations.Common;
using Testably.Expectations.Constraints;

namespace Testably.Expectations;

public static partial class ConstraintExtensions
{
	public static INullableConstraint<TActual> IsNull<TActual>(this IConstraintBuilder<TActual> builder)
		=> builder.Append(new NullConstraint<TActual>());

	public static IConstraint<TActual> IsNotNull<TActual>(this IConstraintBuilder<TActual> builder)
		=> builder.Append(new NotNullConstraint<TActual>());

	public static IConstraintBuilder<TActual> And<TActual>(this IConstraint<TActual> _)
		=> ExpectationContext.Current.GetEmptyConstraintBuilder<TActual>();

	public static IConstraintBuilder<TActual> And<TActual>(this Func<IConstraintBuilder<TActual>, IConstraint<TActual>> builder)
		=> ExpectationContext.Current.GetEmptyConstraintBuilder<TActual>();
}

