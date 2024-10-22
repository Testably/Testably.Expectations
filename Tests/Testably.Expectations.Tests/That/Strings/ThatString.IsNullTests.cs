namespace Testably.Expectations.Tests.That.Strings;

public sealed partial class ThatString
{
	public class IsNullTests
	{
		[Fact]
		public async Task WhenActualIsEmpty_ShouldFail()
		{
			string subject = "";

			async Task Act()
				=> await Expect.That(subject).IsNull();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  is null,
				                  but found ""
				                  at Expect.That(subject).IsNull()
				                  """);
		}

		[Theory]
		[AutoData]
		public async Task WhenActualIsNotNull_ShouldFail(string? subject)
		{
			async Task Act()
				=> await Expect.That(subject).IsNull();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   is null,
				                   but found "{subject}"
				                   at Expect.That(subject).IsNull()
				                   """);
		}

		[Fact]
		public async Task WhenActualIsNull_ShouldSucceed()
		{
			string? subject = null;

			async Task Act()
				=> await Expect.That(subject).IsNull();

			await Act();
		}
	}
}
