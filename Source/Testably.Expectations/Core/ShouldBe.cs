using Testably.Expectations.Internal.ConstraintBuilders;

namespace Testably.Expectations.Core;

public class ShouldBe : ShouldVerb
{
	internal ShouldBe(IConstraintBuilder constraintBuilder)
		: base(constraintBuilder) { }
}
