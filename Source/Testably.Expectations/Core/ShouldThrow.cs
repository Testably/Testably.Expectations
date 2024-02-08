using Testably.Expectations.Internal.ConstraintBuilders;

namespace Testably.Expectations.Core;

public class ShouldThrow : ShouldVerb
{
	internal ShouldThrow(IConstraintBuilder constraintBuilder)
		: base(constraintBuilder) { }
}
