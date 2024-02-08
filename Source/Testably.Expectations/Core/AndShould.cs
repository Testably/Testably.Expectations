namespace Testably.Expectations.Core;

internal class AndShould<TExpectation, TProperty> : IShould<TExpectation, TProperty>
{
	private readonly IConstraintBuilder _constraintBuilder;

	public AndShould(IConstraintBuilder constraintBuilder)
	{
		_constraintBuilder = new AndConstraintBuilder(constraintBuilder);
	}

	#region IShould<TExpectation,TProperty> Members

	public ShouldBe Be => new(_constraintBuilder);

	public ShouldContain Contain => new(_constraintBuilder);

	public ShouldEnd End => new(_constraintBuilder);

	public ShouldHave Have => new(_constraintBuilder);

	public ShouldStart Start => new(_constraintBuilder);

	public ShouldThrow Throw => new(_constraintBuilder);

	#endregion
}
