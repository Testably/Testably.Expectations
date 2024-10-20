using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testably.Expectations.Tests.Collections;
public partial class ThatCollection
{
	public class MyClass
	{
		public string? Value { get; set; }
		public InnerClass? Inner { get; set; }
	}

	public class InnerClass
	{
		public string? Value { get; set; }

		public InnerClass? Inner { get; set; }

		public IEnumerable<string>? Collection { get; set; }
	}
}
