using System;
using System.Linq.Expressions;
using Testably.Expectations.Core.ExpectationBuilders;

namespace Testably.Expectations.Core;

public class ExpectationWhich<TStart, TCurrent> : Expectation<TStart, TCurrent>,
	IShould<TStart, TCurrent>
{
	private readonly IExpectationBuilder _expectationBuilder;

	internal ExpectationWhich(IExpectationBuilder expectationBuilder) : base(expectationBuilder)
	{
		_expectationBuilder = expectationBuilder;
	}

	public Expectation<TStart, TCurrent> Which<TProperty>(
		Expression<Func<TCurrent, TProperty>> propertySelector,
		Expectation<TProperty> expectation)
		=> new(new WhichExpectationBuilder<TCurrent, TProperty>(_expectationBuilder, propertySelector, expectation));

	#region IShould<TStart,TCurrent> Members

	public ShouldBe Be => new(_expectationBuilder);

	public ShouldContain Contain => new(_expectationBuilder);

	public ShouldEnd End => new(_expectationBuilder);

	public ShouldHave Have => new(_expectationBuilder);

	public ShouldStart Start => new(_expectationBuilder);

	public ShouldThrow Throw => new(_expectationBuilder);

	#endregion
}
