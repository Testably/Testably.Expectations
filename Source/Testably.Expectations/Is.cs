using System;

using Testably.Expectations.Common;
using Testably.Expectations.Constraints;

namespace Testably.Expectations;

public static class Is
{
	public static Func<IConstraint<bool>, IConstraint<bool>> True => _ => _.IsTrue();
	public static Func<IConstraint<bool>, IConstraint<bool>> False => _ => _.IsFalse();
	public static Func<IConstraint<TActual>, INullableConstraint<TActual>> Null<TActual>() => _ => _.IsNull();
	public static Func<IConstraint<object?>, INullableConstraint<object?>> Null() => _ => _.IsNull();
	public static Func<IConstraint<TActual>, IConstraint<TActual>> NotNull<TActual>() => _ => _.IsNotNull();
	public static Func<IConstraint<object?>, IConstraint<object?>> NotNull() => _ => _.IsNotNull();
	public static Func<IConstraint<int>, IConstraint<int>> GreaterThan(int expected) => _ => _.IsGreaterThan(expected);
}

