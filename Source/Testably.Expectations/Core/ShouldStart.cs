using Testably.Expectations.Internal.ConstraintBuilders;

namespace Testably.Expectations.Core;

public class ShouldStart : ShouldVerb
{
	internal ShouldStart(IConstraintBuilder constraintBuilder)
		: base(constraintBuilder) { }
}
