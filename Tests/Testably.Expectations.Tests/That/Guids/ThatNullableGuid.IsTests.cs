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
				=> await Expect.That(subject).Is(null);

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			Guid? subject = null;

			async Task Act()
				=> await Expect.That(subject).Is(FixedGuid());

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   is {FixedGuid()},
				                   but found <null>
				                   at Expect.That(subject).Is(FixedGuid())
				                   """);
		}

		[Fact]
		public async Task WhenValuesAreDifferent_ShouldFail()
		{
			Guid? subject = FixedGuid();
			Guid? expected = OtherGuid();

			async Task Act()
				=> await Expect.That(subject).Is(expected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   is {expected?.ToString() ?? "<null>"},
				                   but found {subject?.ToString() ?? "<null>"}
				                   at Expect.That(subject).Is(expected)
				                   """);
		}

		[Fact]
		public async Task WhenValuesAreTheSame_ShouldSucceed()
		{
			Guid? subject = FixedGuid();
			Guid? expected = subject;

			async Task Act()
				=> await Expect.That(subject).Is(expected);

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
