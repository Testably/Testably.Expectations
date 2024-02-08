using System;
using System.Linq.Expressions;
using Testably.Expectations.Constraints;
using Testably.Expectations.Core;

namespace Testably.Expectations;

public static class Extensions
{
	public static AndConstraint<T> EqualTo<T>(this ShouldBe shouldBe, T expected)
		=> shouldBe.WithConstraint(new EqualToConstraint<T>(expected));

	public static AndWhichConstraint<Action, Exception?> Exception(this ShouldThrow shouldThrow)
		=> shouldThrow.WithConstraintMapping(new ThrowsConstraint<Exception>());

	public static AndConstraint<bool> False(this ShouldBe shouldBe)
		=> shouldBe.WithConstraint(new FalseConstraint());
	//public static AndConstraint<TStart, TCurrent> Which<TStart, TCurrent, TProperty>(
	//	this IShould<TStart, TCurrent> _,
	//	Expression<Func<TCurrent, TProperty>> propertySelector,
	//	AndConstraint constraint)
	//	=> new AndConstraint<TStart, TCurrent>(new WhichConstraintBuilder<TCurrent, TProperty>(propertySelector, constraint));


	public static NullableAndConstraint Null(this ShouldBe shouldBe)
		=> shouldBe.WithConstraint(new NullConstraint());

	public static AndWhichConstraint<TType, TType?> OfType<TType>(this ShouldBe shouldBe)
		=> shouldBe.WithConstraintMapping(new OfTypeConstraint<TType>());

	public static AndConstraint<bool> True(this ShouldBe shouldBe)
		=> shouldBe.WithConstraint(new TrueConstraint());

	public static AndWhichConstraint<Action, TException?> TypeOf<TException>(
		this ShouldThrow shouldThrow)
		where TException : Exception
		=> shouldThrow.WithConstraintMapping(new ThrowsConstraint<TException>());

	public static AndConstraint<TStart, TCurrent> Which<TStart, TCurrent, TProperty>(
		this IShould<TStart, TCurrent> _,
		Expression<Func<TCurrent, TProperty>> propertySelector,
		AndConstraint<TProperty> constraint)
		=> new(new WhichConstraintBuilder<TCurrent, TProperty>(propertySelector, constraint));

	public static AndConstraint<string?> With(this ShouldStart shouldStart, string expected)
		=> shouldStart.WithConstraint(new StartsWithConstraint(expected));

	public static AndConstraint<string?> With(this ShouldEnd shouldEnd, string expected)
		=> shouldEnd.WithConstraint(new EndsWithConstraint(expected));
}
