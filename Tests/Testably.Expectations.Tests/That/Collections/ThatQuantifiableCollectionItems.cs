﻿using System.Collections.Generic;

namespace Testably.Expectations.Tests.That.Collections;

public partial class ThatQuantifiableCollectionItems
{
	public class MyClass
	{
		public InnerClass? Inner { get; set; }
		public string? Value { get; set; }
	}

	public class InnerClass
	{
		public IEnumerable<string>? Collection { get; set; }

		public InnerClass? Inner { get; set; }
		public string? Value { get; set; }
	}
}
