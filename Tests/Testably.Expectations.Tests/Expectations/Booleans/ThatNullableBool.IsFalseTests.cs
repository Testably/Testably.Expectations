using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests.Expectations.Booleans;

public sealed partial class ThatNullableBool
{
	public sealed class IsFalseTests
	{
		[Fact]
		public async Task Fails_For_Null_Value()
		{
			bool? value = null;

			async Task Act()
				=> await That(value).IsFalse();

			await That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that value
				                  is False,
				                  but found <null>
				                  at Expect.That(value).IsFalse()
				                  """);
		}

		[Fact]
		public async Task Fails_For_True_Value()
		{
			bool? value = true;

			async Task Act()
				=> await That(value).IsFalse();

			await That(Act).Throws<XunitException>()
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
			bool? value = false;

			async Task Act()
				=> await That(value).IsFalse();

			await That(Act).DoesNotThrow();
		}
	}
}
