﻿using Testably.Expectations.Core.ExpectationBuilders;

namespace Testably.Expectations.Core;

public class ShouldEnd : ShouldVerb
{
	internal ShouldEnd(IExpectationBuilder expectationBuilder)
		: base(expectationBuilder) { }
}
