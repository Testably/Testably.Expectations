using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
	///     Expect the actual value to contain…
	/// </summary>
	public ShouldContain Contain => new(_expectationBuilder);

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
			PropertyAccessor<TCurrent, TProperty>.FromExpression(propertySelector),
			expectation));

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
			PropertyAccessor<TCurrent, TProperty>.FromExpression(propertySelector),
			nullableExpectation));

	/// <summary>
	///     Accesses a property from <typeparamref name="TCurrent" /> and add a <paramref name="nullableExpectation" /> on it.
	/// </summary>
	/// <remarks>
	///     The <paramref name="propertySelector" /> specifies which property to use.
	///     Nested properties are supported.
	/// </remarks>
	public AsyncExpectation<TStart, TCurrent> Which<TProperty>(
		Expression<Func<TCurrent, Task<TProperty>>> propertySelector,
		NullableExpectation<TProperty?> nullableExpectation)
		=> new(_expectationBuilder.Which<TCurrent, TProperty>(
			AsyncPropertyAccessor<TCurrent, TProperty>.FromExpression(propertySelector),
			nullableExpectation));

	/// <summary>
	///     Accesses a property from <typeparamref name="TCurrent" /> and add a <paramref name="nullableExpectation" /> on it.
	/// </summary>
	/// <remarks>
	///     The <paramref name="propertySelector" /> specifies which property to use.
	///     Nested properties are supported.
	/// </remarks>
	public AsyncExpectation<TStart, TCurrent> Which<TProperty>(
		Expression<Func<TCurrent, Task<TProperty>>> propertySelector,
		Expectation<TProperty?> nullableExpectation)
		=> new(_expectationBuilder.Which<TCurrent, TProperty>(
			AsyncPropertyAccessor<TCurrent, TProperty>.FromExpression(propertySelector),
			nullableExpectation));
}
