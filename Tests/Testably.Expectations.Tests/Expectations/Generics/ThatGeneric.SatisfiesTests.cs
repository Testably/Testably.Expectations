using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests.Expectations.Generics;

public sealed partial class ThatGeneric
{
	public sealed class SatisfiesTests
	{
		[Fact]
		public async Task Fails_For_True_Value()
		{
			var value = new Other
			{
				Value = 1
			};

			//async Task Act()
			//	=> await Expect.That(value).Satisfies(o => o.Value, v => v.Is(1));

			//await Expect.That(Act).Throws<XunitException>()
			//	.Which.HasMessage("""
			//	                  Expected that value
			//	                  refers to other {"Value":1},
			//	                  but found {"Value":1}
			//	                  at Expect.That(value).IsSameAs(other)
			//	                  """);
		}

		[Fact]
		public async Task Succeeds_For_Same_Object_References()
		{
			var value = new Other
			{
				Value = 1
			};
			var other = value;

			async Task Act()
				=> await Expect.That(value).IsSameAs(other);

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
