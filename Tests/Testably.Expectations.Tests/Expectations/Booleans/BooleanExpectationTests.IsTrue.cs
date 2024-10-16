using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests.Expectations.Booleans;

public sealed partial class BooleanExpectationTests
{
	public sealed class IsTrue
	{
		[Fact]
		public async Task Fails_For_False_Value()
		{
			bool value = false;

			async Task Act()
				=> await Expect.That(value).IsTrue();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that value
				                  is True,
				                  but found False
				                  at Expect.That(value).IsTrue()
				                  """);
		}

		[Fact]
		public async Task Succeeds_For_True_Value()
		{
			bool value = true;

			async Task Act()
				=> await Expect.That(value).IsTrue();

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
