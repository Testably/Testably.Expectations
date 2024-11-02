﻿using System.Collections.Generic;

namespace Testably.Expectations.Tests.ThatTests.Objects;

public sealed partial class ObjectShould
{
	public sealed partial class Be
	{
		// ReSharper disable UnusedAutoPropertyAccessor.Local
		private class InnerClass
		{
			public IEnumerable<string>? Collection { get; set; }

			public InnerClass? Inner { get; set; }
			public string? Value { get; set; }
		}

		private class OuterClass
		{
			public InnerClass? Inner { get; set; }
			public string? Value { get; set; }
		}
		// ReSharper restore UnusedAutoPropertyAccessor.Local
	}
}