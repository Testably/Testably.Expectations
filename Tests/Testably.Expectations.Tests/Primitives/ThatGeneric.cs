﻿namespace Testably.Expectations.Tests.Primitives.Generics;

public sealed partial class ThatGeneric
{
	private class OtherBase
	{
		public int Value { get; set; }
	}

	private class Other : OtherBase
	{
	}
}
