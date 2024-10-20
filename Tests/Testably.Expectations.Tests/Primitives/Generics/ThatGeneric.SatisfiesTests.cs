using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests.Primitives.Generics;

public sealed partial class ThatGeneric
{
	public sealed class SatisfiesTests
	{
		[Fact]
		public async Task Fails_For_True_Value()
		{
			Other value = new Other
			{
				Value = 1
			};

			async Task Act()
				=> await Expect.That(value).Satisfies<Other, int>(o => o.Value, v => v.Is(2));

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that value
				                  satisfies Value is 2,
				                  but found 1
				                  at Expect.That(value).Satisfies<Other, int>(o => o.Value, v => v.Is(2))
				                  """);
		}

		[Fact]
		public async Task Succeeds_For_Same_Object_References()
		{
			Other value = new Other
			{
				Value = 1
			};
			Other other = value;

			async Task Act()
				=> await Expect.That(value).IsSameAs(other);

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
