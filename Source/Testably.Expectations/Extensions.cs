using System;
using System.Linq.Expressions;
using Testably.Expectations.Constraints;
using Testably.Expectations.Core;
using Testably.Expectations.Internal.ConstraintBuilders;

namespace Testably.Expectations;

public static class Extensions
{
	public static Expectation<T> EqualTo<T>(this ShouldBe shouldBe, T expected)
		=> shouldBe.WithConstraint(new EqualToConstraint<T>(expected));

	public static ExpectationWhich<Action, Exception?> Exception(this ShouldThrow shouldThrow)
		=> shouldThrow.WithConstraintMapping(new ThrowsConstraint<Exception>());

	public static Expectation<bool> False(this ShouldBe shouldBe)
		=> shouldBe.WithConstraint(new FalseConstraint());
	//public static AndConstraint<TStart, TCurrent> Which<TStart, TCurrent, TProperty>(
	//	this IShould<TStart, TCurrent> _,
	//	Expression<Func<TCurrent, TProperty>> propertySelector,
	//	AndConstraint constraint)
	//	=> new AndConstraint<TStart, TCurrent>(new WhichConstraintBuilder<TCurrent, TProperty>(propertySelector, constraint));


	public static NullableExpectation<object?> Null(this ShouldBe shouldBe)
		=> shouldBe.WithConstraint(new NullConstraint());

	public static ExpectationWhich<TType, TType?> OfType<TType>(this ShouldBe shouldBe)
		=> shouldBe.WithConstraintMapping(new OfTypeConstraint<TType>());

	public static Expectation<bool> True(this ShouldBe shouldBe)
		=> shouldBe.WithConstraint(new TrueConstraint());

	public static ExpectationWhich<Action, TException?> TypeOf<TException>(
		this ShouldThrow shouldThrow)
		where TException : Exception
		=> shouldThrow.WithConstraintMapping(new ThrowsConstraint<TException>());
}
