namespace Testably.Expectations.Core;

public interface IShould
{
	public ShouldBe Be { get; }
	public ShouldContain Contain { get; }
	public ShouldEnd End { get; }
	public ShouldHave Have { get; }
	public ShouldStart Start { get; }
	public ShouldThrow Throw { get; }
}

public class ShouldBe : ShouldVerb
{
	internal ShouldBe(IConstraintBuilder constraintBuilder) : base(constraintBuilder) { }
}

public class ShouldHave : ShouldVerb
{
	internal ShouldHave(IConstraintBuilder constraintBuilder) : base(constraintBuilder) { }
}

public class ShouldStart : ShouldVerb
{
	internal ShouldStart(IConstraintBuilder constraintBuilder) : base(constraintBuilder) { }
}

public class ShouldEnd : ShouldVerb
{
	internal ShouldEnd(IConstraintBuilder constraintBuilder) : base(constraintBuilder) { }
}

public class ShouldContain : ShouldVerb
{
	internal ShouldContain(IConstraintBuilder constraintBuilder) : base(constraintBuilder) { }
}

public class ShouldThrow : ShouldVerb
{
	internal ShouldThrow(IConstraintBuilder constraintBuilder) : base(constraintBuilder) { }
}

public interface IShould<TStart, TCurrent> : IShould
{
}
