using Testably.Expectations.Formatting;

namespace Testably.Expectations.Tests.ThatTests.Objects;

public sealed partial class ObjectShould
{
	public sealed class BeNullTests
	{
		[Fact]
		public async Task WhenSubjectIsNull_ShouldSucceed()
		{
			object? subject = null;

			async Task Act()
				=> await That(subject).Should().BeNull();

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsObject_ShouldFail()
		{
			object subject = new Other();

			async Task Act()
				=> await That(subject).Should().BeNull();

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be null,
				              but found {Formatter.Format(subject)}
				              at Expect.That(subject).Should().BeNull()
				              """);
		}
	}

	public sealed class NotBeNullTests
	{
		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			object? subject = null;

			async Task Act()
				=> await That(subject).Should().NotBeNull();

			await That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             not be null,
				             but it was
				             at Expect.That(subject).Should().NotBeNull()
				             """);
		}

		[Fact]
		public async Task WhenSubjectIsObject_ShouldSucceed()
		{
			object subject = new Other();

			async Task Act()
				=> await That(subject).Should().NotBeNull();

			await That(Act).Should().NotThrow();
		}
	}
}
