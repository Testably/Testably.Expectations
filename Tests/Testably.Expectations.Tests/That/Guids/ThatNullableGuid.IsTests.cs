namespace Testably.Expectations.Tests.That.Guids;

public sealed partial class ThatNullableGuid
{
	public sealed class IsTests
	{
		[Fact]
		public async Task WhenSubjectAndExpectedAreNull_ShouldSucceed()
		{
			Guid? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().Is(null);

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			Guid? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().Is(FixedGuid());

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   is {FixedGuid()},
				                   but found <null>
				                   at Expect.That(subject).Should().Is(FixedGuid())
				                   """);
		}

		[Fact]
		public async Task WhenSubjectIsDifferent_ShouldFail()
		{
			Guid? subject = FixedGuid();
			Guid? expected = OtherGuid();

			async Task Act()
				=> await Expect.That(subject).Should().Is(expected);

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   is {expected?.ToString() ?? "<null>"},
				                   but found {subject?.ToString() ?? "<null>"}
				                   at Expect.That(subject).Should().Is(expected)
				                   """);
		}

		[Fact]
		public async Task WhenSubjectIsTheSame_ShouldSucceed()
		{
			Guid? subject = FixedGuid();
			Guid? expected = subject;

			async Task Act()
				=> await Expect.That(subject).Should().Is(expected);

			await Expect.That(Act).Should().DoesNotThrow();
		}
	}
}
