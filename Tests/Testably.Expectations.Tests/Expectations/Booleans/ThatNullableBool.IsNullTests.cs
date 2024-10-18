using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests.Expectations.Booleans;

public sealed partial class ThatNullableBool
{
	public sealed class IsNullTests
	{
		[Fact]
		public async Task Fails_For_False_Value()
		{
			bool? value = false;

			async Task Act()
				=> await Expect.That(value).IsNull();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that value
				                  is <null>,
				                  but found False
				                  at Expect.That(value).IsNull()
				                  """);
		}

		[Fact]
		public async Task Fails_For_True_Value()
		{
			bool? value = true;

			async Task Act()
				=> await Expect.That(value).IsNull();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that value
				                  is <null>,
				                  but found True
				                  at Expect.That(value).IsNull()
				                  """);
		}

		[Fact]
		public async Task Succeeds_For_Null_Value()
		{
			bool? value = null;

			async Task Act()
				=> await Expect.That(value).IsNull();

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
