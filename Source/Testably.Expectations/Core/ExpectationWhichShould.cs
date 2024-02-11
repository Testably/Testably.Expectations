using System;
using System.Linq.Expressions;
using Testably.Expectations.Core.Helpers;

namespace Testably.Expectations.Core;

/// <summary>
///     A complex expectation that allows access to underlying properties.
/// </summary>
public class ExpectationWhichShould<TStart, TCurrent> : Expectation<TStart, TCurrent>
{
	/// <summary>
	///     Expect the actual value to be…
	/// </summary>
	public ShouldBe Be => new(_expectationBuilder);

	/// <summary>
	///     Expect the actual value to end…
	/// </summary>
	public ShouldEnd End => new(_expectationBuilder);

	/// <summary>
	///     Negates the remaining expectation.
	/// </summary>
	public ExpectationShould Not => new(_expectationBuilder.Not());

	/// <summary>
	///     Expect the actual value to start…
	/// </summary>
	public ShouldStart Start => new(_expectationBuilder);

	/// <summary>
	///     Expect the actual value to throw…
	/// </summary>
	public ShouldThrow Throw => new(_expectationBuilder);

	private readonly IExpectationBuilder _expectationBuilder;

	internal ExpectationWhichShould(IExpectationBuilder expectationBuilder)
		: base(expectationBuilder)
	{
		_expectationBuilder = expectationBuilder;
	}

	/// <summary>
	///     Specifies an <paramref name="expectation" /> on a property from <typeparamref name="TCurrent" />.
	/// </summary>
	/// <remarks>
	///     The <paramref name="propertySelector" /> specifies which property to use.
	///     Nested properties are supported.
	/// </remarks>
	public Expectation<TStart, TCurrent> Which<TProperty>(
		Expression<Func<TCurrent, TProperty>> propertySelector,
		Expectation<TProperty> expectation)
		=> new(_expectationBuilder.Which<TCurrent, TProperty>(
			ExpressionHelpers.GetPropertyPath(propertySelector), expectation));

	/// <summary>
	///     Accesses a property from <typeparamref name="TCurrent" /> and add a <paramref name="nullableExpectation" /> on it.
	/// </summary>
	/// <remarks>
	///     The <paramref name="propertySelector" /> specifies which property to use.
	///     Nested properties are supported.
	/// </remarks>
	public Expectation<TStart, TCurrent> Which<TProperty>(
		Expression<Func<TCurrent, TProperty>> propertySelector,
		NullableExpectation<TProperty> nullableExpectation)
		=> new(_expectationBuilder.Which<TCurrent, TProperty>(
			ExpressionHelpers.GetPropertyPath(propertySelector), nullableExpectation));

	/// <summary>
	///     Specifies an <paramref name="expectation" /> on a property from <typeparamref name="TCurrent" />.
	/// </summary>
	/// <remarks>
	///     The <paramref name="propertySelector" /> specifies which property to use.
	///     Nested properties are supported.
	/// </remarks>
	public Expectation<TStart, TCurrent> Which<TProperty>(
		string propertySelector,
		Expectation<TProperty> expectation)
		=> new(_expectationBuilder.Which<TCurrent, TProperty>(propertySelector, expectation));

	/// <summary>
	///     Accesses a property from <typeparamref name="TCurrent" /> and add a <paramref name="nullableExpectation" /> on it.
	/// </summary>
	/// <remarks>
	///     The <paramref name="propertySelector" /> specifies which property to use.
	///     Nested properties are supported.
	/// </remarks>
	public Expectation<TStart, TCurrent> Which<TProperty>(
		string propertySelector,
		NullableExpectation<TProperty> nullableExpectation)
		=> new(
			_expectationBuilder.Which<TCurrent, TProperty>(propertySelector, nullableExpectation));
}
