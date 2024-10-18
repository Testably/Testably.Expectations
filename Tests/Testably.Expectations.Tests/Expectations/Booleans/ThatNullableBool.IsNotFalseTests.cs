using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests.Expectations.Booleans;

public sealed partial class ThatNullableBool
{
	public sealed class IsNotFalseTests
	{
		[Fact]
		public async Task Fails_For_False_Value()
		{
			bool? value = false;

			async Task Act()
				=> await Expect.That(value).IsNotFalse();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that value
				                  is not False,
				                  but found False
				                  at Expect.That(value).IsNotFalse()
				                  """);
		}

		[Theory]
		[InlineData(true)]
		[InlineData(null)]
		public async Task Succeeds_For_True_Or_Null_Value(bool? value)
		{
			async Task Act()
				=> await Expect.That(value).IsNotFalse();

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
