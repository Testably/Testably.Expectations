using System.IO;

namespace Testably.Expectations.Tests.ThatTests.Streams;

public sealed partial class StreamShould
{
	public sealed class BeReadOnlyTests
	{
		[Theory]
		[InlineData(false, false)]
		[InlineData(false, true)]
		[InlineData(true, true)]
		public async Task WhenSubjectIsNotReadOnly_ShouldFail(bool canRead, bool canWrite)
		{
			Stream subject = new MyStream(canRead: canRead, canWrite: canWrite);

			async Task Act()
				=> await That(subject).Should().BeReadOnly();

			await That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             be read-only,
				             but it was not
				             at Expect.That(subject).Should().BeReadOnly()
				             """);
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			Stream? subject = null;

			async Task Act()
				=> await That(subject).Should().BeReadOnly();

			await That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             be read-only,
				             but found <null>
				             at Expect.That(subject).Should().BeReadOnly()
				             """);
		}

		[Fact]
		public async Task WhenSubjectIsReadOnly_ShouldSucceed()
		{
			Stream subject = new MyStream(canRead: true, canWrite: false);

			async Task Act()
				=> await That(subject).Should().BeReadOnly();

			await That(Act).Should().NotThrow();
		}
	}

	public sealed class NotBeReadOnlyTests
	{
		[Theory]
		[InlineData(false, false)]
		[InlineData(false, true)]
		[InlineData(true, true)]
		public async Task WhenSubjectIsNotReadOnly_ShouldSucceed(bool canRead, bool canWrite)
		{
			Stream subject = new MyStream(canRead: canRead, canWrite: canWrite);

			async Task Act()
				=> await That(subject).Should().NotBeReadOnly();

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			Stream? subject = null;

			async Task Act()
				=> await That(subject).Should().NotBeReadOnly();

			await That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             not be read-only,
				             but found <null>
				             at Expect.That(subject).Should().NotBeReadOnly()
				             """);
		}

		[Fact]
		public async Task WhenSubjectIsReadOnly_ShouldFail()
		{
			Stream subject = new MyStream(canRead: true, canWrite: false);

			async Task Act()
				=> await That(subject).Should().NotBeReadOnly();

			await That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             not be read-only,
				             but it was
				             at Expect.That(subject).Should().NotBeReadOnly()
				             """);
		}
	}
}
