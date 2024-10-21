namespace Testably.Expectations.Tests.Primitives.Strings;

public sealed partial class ThatString
{
	public class IsNullTests
	{
		[Fact]
		public async Task WhenActualIsEmpty_ShouldFail()
		{
			string actual = "";

			async Task Act()
				=> await Expect.That(actual).IsNull();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that actual
				                  is null,
				                  but found ""
				                  at Expect.That(actual).IsNull()
				                  """);
		}

		[Theory]
		[AutoData]
		public async Task WhenActualIsNotNull_ShouldFail(string? actual)
		{
			async Task Act()
				=> await Expect.That(actual).IsNull();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that actual
				                   is null,
				                   but found "{actual}"
				                   at Expect.That(actual).IsNull()
				                   """);
		}

		[Fact]
		public async Task WhenActualIsNull_ShouldSucceed()
		{
			string? actual = null;

			async Task Act()
				=> await Expect.That(actual).IsNull();

			await Act();
		}
	}
}
