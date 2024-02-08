namespace Testably.Expectations.Core;

internal class OrShould<TExpectation, TProperty> : IShould<TExpectation, TProperty>
{
	private readonly IConstraintBuilder _constraintBuilder;

	public OrShould(IConstraintBuilder constraintBuilder)
	{
		_constraintBuilder = new OrConstraintBuilder(constraintBuilder);
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
