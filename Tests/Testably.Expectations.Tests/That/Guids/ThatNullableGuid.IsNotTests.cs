namespace Testably.Expectations.Tests.That.Guids;

public sealed partial class ThatNullableGuid
{
	public sealed class IsNotTests
	{
		[Fact]
		public async Task WhenSubjectAndExpectedAreNull_ShouldFail()
		{
			Guid? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().IsNot(null);

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  is not <null>,
				                  but found <null>
				                  at Expect.That(subject).Should().IsNot(null)
				                  """);
		}

		[Fact]
		public async Task WhenSubjectIsDifferent_ShouldSucceed()
		{
			Guid? subject = FixedGuid();
			Guid? unexpected = OtherGuid();

			async Task Act()
				=> await Expect.That(subject).Should().IsNot(unexpected);

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsTheSame_ShouldFail()
		{
			Guid? subject = FixedGuid();
			Guid? unexpected = subject;

			async Task Act()
				=> await Expect.That(subject).Should().IsNot(unexpected);

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected subject to
				                   is not {unexpected?.ToString() ?? "<null>"},
				                   but found {subject?.ToString() ?? "<null>"}
				                   at Expect.That(subject).Should().IsNot(unexpected)
				                   """);
		}
	}
}
