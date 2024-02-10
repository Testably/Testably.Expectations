using System;
using System.Linq.Expressions;
using Testably.Expectations.Core.ExpectationBuilders;

namespace Testably.Expectations.Core;

/// <summary>
///     A complex expectation that allows access to underlying properties.
/// </summary>
public class ExpectationWhichShould<TStart, TCurrent> : Expectation<TStart, TCurrent>
{
	/// <summary>
	///     Negates the remaining expectation.
	/// </summary>
	public ExpectationShould Not => new(_expectationBuilder is IExpectationBuilderCombination b ? b.ReplaceRight(new NotExpectationBuilder(new SimpleExpectationBuilder())) : new NotExpectationBuilder(_expectationBuilder));

	/// <summary>
	///     Expect the actual value to be...
	/// </summary>
	public ShouldBe Be => new(_expectationBuilder);

	/// <summary>
	///     Expect the actual value to end...
	/// </summary>
	public ShouldEnd End => new(_expectationBuilder);

	/// <summary>
	///     Expect the actual value to start...
	/// </summary>
	public ShouldStart Start => new(_expectationBuilder);

	/// <summary>
	///     Expect the actual value to throw...
	/// </summary>
	public ShouldThrow Throw => new(_expectationBuilder);

	private readonly IExpectationBuilderStart _expectationBuilder;

	internal ExpectationWhichShould(IExpectationBuilderStart expectationBuilder) : base(
		expectationBuilder)
	{
		_expectationBuilder = expectationBuilder;
	}

	/// <summary>
	///     Accesses a property from <typeparamref name="TCurrent" /> and add an <paramref name="expectation" /> on it.
	/// </summary>
	/// <remarks>
	///     The <paramref name="propertySelector" /> specifies which property to use.
	///     Nested properties are supported.
	/// </remarks>
	public Expectation<TStart, TCurrent> Which<TProperty>(
		Expression<Func<TCurrent, TProperty>> propertySelector,
		Expectation<TProperty> expectation)
		=> new(new WhichExpectationBuilder<TCurrent, TProperty>(
			_expectationBuilder is IExpectationBuilderCombination b ? b.Left : _expectationBuilder,
			propertySelector, expectation));

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
		=> new(new WhichExpectationBuilder<TCurrent, TProperty>(
			_expectationBuilder is IExpectationBuilderCombination b ? b.Left : _expectationBuilder,
			propertySelector, nullableExpectation));
}
