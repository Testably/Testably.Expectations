using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Testably.Expectations.Tests.Constraints.String;
public sealed class StringTests
{
	public sealed class EndsWith
	{
		[Fact]
		public void MatchingEnd_ShouldNotThrow()
		{
			string sut = "foo";

			Expect.That(sut, Should.End.With("oo"));
		}

		[Fact]
		public void NotMatchingEnd_ShouldThrow()
		{
			string sut = "foo";

			void Act()
				=> Expect.That(sut, Should.End.With("oo1"));

			Expect.That(Act,
				Should.Throw.Exception().Which(_ => _.Message, Should.Be.EqualTo("Expected Act property 'Message' to end with oo1, but found foo.")));

		}
	}
}
