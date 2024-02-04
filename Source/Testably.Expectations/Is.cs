using System;
using Testably.Expectations.Common;

namespace Testably.Expectations;

public static class Is
{
	public static Func<IConstraintBuilder<bool>, IConstraint<bool>> True => _ => _.IsTrue();
	public static Func<IConstraintBuilder<bool>, IConstraint<bool>> False => _ => _.IsFalse();
	public static Func<IConstraintBuilder<TActual>, INullableConstraint<TActual>> Null<TActual>() => _ => _.IsNull();
	public static Func<IConstraintBuilder<object?>, INullableConstraint<object?>> Null() => _ => _.IsNull();
	public static Func<IConstraintBuilder<TActual>, IConstraint<TActual>> NotNull<TActual>() => _ => _.IsNotNull();
	public static Func<IConstraintBuilder<object?>, IConstraint<object?>> NotNull() => _ => _.IsNotNull();
	public static Func<IConstraintBuilder<int>, IConstraint<int>> GreaterThan(int expected) => _ => _.IsGreaterThan(expected);
}

