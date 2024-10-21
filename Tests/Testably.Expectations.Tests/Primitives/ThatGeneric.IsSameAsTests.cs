namespace Testably.Expectations.Tests.Primitives.Generics;

public sealed partial class ThatGeneric
{
	public sealed class IsSameAsTests
	{
		[Fact]
		public async Task Fails_For_True_Value()
		{
			Other value = new Other
			{
				Value = 1
			};
			Other other = new Other
			{
				Value = 1
			};

			async Task Act()
				=> await Expect.That(value).IsSameAs(other);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that value
				                  refers to other Other{
				                    Value = 1
				                  },
				                  but found Other{
				                    Value = 1
				                  }
				                  at Expect.That(value).IsSameAs(other)
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
