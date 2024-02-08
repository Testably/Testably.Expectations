using Testably.Expectations.Internal.ConstraintBuilders;

namespace Testably.Expectations.Core;

public class ShouldHave : ShouldVerb
{
	internal ShouldHave(IConstraintBuilder constraintBuilder)
		: base(constraintBuilder) { }
}
