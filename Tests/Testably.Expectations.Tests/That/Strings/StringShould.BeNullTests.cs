namespace Testably.Expectations.Tests.That.Strings;

public sealed partial class StringShould
{
	public class BeNullTests
	{
		[Fact]
		public async Task WhenActualIsEmpty_ShouldFail()
		{
			string subject = "";

			async Task Act()
				=> await Expect.That(subject).Should().BeNull();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HaveMessage("""
				                  Expected subject to
				                  be null,
				                  but found ""
				                  at Expect.That(subject).Should().BeNull()
				                  """);
		}

		[Theory]
		[AutoData]
		public async Task WhenActualIsNotNull_ShouldFail(string? subject)
		{
			async Task Act()
				=> await Expect.That(subject).Should().BeNull();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HaveMessage($"""
				                   Expected subject to
				                   be null,
				                   but found "{subject}"
				                   at Expect.That(subject).Should().BeNull()
				                   """);
		}

		[Fact]
		public async Task WhenActualIsNull_ShouldSucceed()
		{
			string? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().BeNull();

			await Act();
		}
	}

	public sealed class NotBeNullTests
	{
		[Fact]
		public async Task WhenActualIsEmpty_ShouldSucceed()
		{
			string subject = "";

			async Task Act()
				=> await Expect.That(subject).Should().NotBeNull();

			await Expect.That(Act).Should().NotThrow();
		}

		[Theory]
		[AutoData]
		public async Task WhenActualIsNotNull_ShouldSucceed(string? subject)
		{
			async Task Act()
				=> await Expect.That(subject).Should().NotBeNull();

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenActualIsNull_ShouldFail()
		{
			string? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().NotBeNull();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HaveMessage("""
				                  Expected subject to
				                  not be null,
				                  but it was
				                  at Expect.That(subject).Should().NotBeNull()
				                  """);
		}
	}
}
