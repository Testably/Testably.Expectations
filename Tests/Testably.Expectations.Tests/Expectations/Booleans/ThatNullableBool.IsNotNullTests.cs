using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests.Expectations.Booleans;

public sealed partial class ThatNullableBool
{
	public sealed class IsNotNullTests
	{
		[Fact]
		public async Task Fails_For_Null_Value()
		{
			bool? value = null;

			async Task Act()
				=> await That(value).IsNotNull();

			await That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that value
				                  is not <null>,
				                  but found <null>
				                  at Expect.That(value).IsNotNull()
				                  """);
		}

		[Theory]
		[InlineData(true)]
		[InlineData(false)]
		public async Task Succeeds_For_True_Or_False_Value(bool? value)
		{
			async Task Act()
				=> await That(value).IsNotNull();

			await That(Act).DoesNotThrow();
		}
	}
}
