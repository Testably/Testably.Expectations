using Testably.Expectations.Internal.ConstraintBuilders;

namespace Testably.Expectations.Core;

public class ShouldContain : ShouldVerb
{
	internal ShouldContain(IConstraintBuilder constraintBuilder)
		: base(constraintBuilder) { }
}
