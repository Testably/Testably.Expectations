namespace Testably.Expectations.Tests.That.Guids;

public sealed partial class NullableGuidShould
{
	public sealed class BeNullTests
	{
		[Fact]
		public async Task WhenSubjectIsNotNull_ShouldFail()
		{
			Guid? subject = OtherGuid();

			async Task Act()
				=> await Expect.That(subject).Should().BeNull();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage($"""
				                   Expected subject to
				                   be null,
				                   but found {subject}
				                   at Expect.That(subject).Should().BeNull()
				                   """);
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldSucceed()
		{
			Guid? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().BeNull();

			await Expect.That(Act).Should().NotThrow();
		}
	}

	public sealed class NotBeNullTests
	{
		[Fact]
		public async Task WhenSubjectIsNotNull_ShouldSucceed()
		{
			Guid? subject = OtherGuid();

			async Task Act()
				=> await Expect.That(subject).Should().NotBeNull();

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			Guid? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().NotBeNull();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  not be null,
				                  but found <null>
				                  at Expect.That(subject).Should().NotBeNull()
				                  """);
		}
	}
}
