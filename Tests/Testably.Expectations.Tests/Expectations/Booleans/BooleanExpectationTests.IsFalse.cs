using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests.Expectations.Booleans;

public sealed partial class BooleanExpectationTests
{
	public sealed class IsFalse
	{
		[Fact]
		public async Task Fails_For_True_Value()
		{
			bool value = true;

			async Task Act()
				=> await Expect.That(value).IsFalse();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that value
				                  is False,
				                  but found True
				                  at Expect.That(value).IsFalse()
				                  """);
		}

		[Fact]
		public async Task Succeeds_For_False_Value()
		{
			bool value = false;

			async Task Act()
				=> await Expect.That(value).IsFalse();

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
