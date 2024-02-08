using Testably.Expectations.Internal.ConstraintBuilders;

namespace Testably.Expectations.Core;

public class ShouldEnd : ShouldVerb
{
	internal ShouldEnd(IConstraintBuilder constraintBuilder)
		: base(constraintBuilder) { }
}
