using System.IO;

namespace Testably.Expectations.Tests.That.Streams;

public sealed partial class ThatStreamShould
{
	public sealed class BeReadableTests
	{
		[Fact]
		public async Task WhenSubjectIsNotReadable_ShouldFail()
		{
			Stream subject = new MyStream(canRead: false);

			async Task Act()
				=> await Expect.That(subject).Should().BeReadable();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  be readable,
				                  but it was not
				                  at Expect.That(subject).Should().BeReadable()
				                  """);
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			Stream? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().BeReadable();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  be readable,
				                  but found <null>
				                  at Expect.That(subject).Should().BeReadable()
				                  """);
		}

		[Fact]
		public async Task WhenSubjectIsReadable_ShouldSucceed()
		{
			Stream subject = new MyStream(canRead: true);

			async Task Act()
				=> await Expect.That(subject).Should().BeReadable();

			await Expect.That(Act).Should().NotThrow();
		}
	}

	public sealed class NotBeReadableTests
	{
		[Fact]
		public async Task WhenSubjectIsNotReadable_ShouldSucceed()
		{
			Stream subject = new MyStream(canRead: false);

			async Task Act()
				=> await Expect.That(subject).Should().NotBeReadable();

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			Stream? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().NotBeReadable();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  not be readable,
				                  but found <null>
				                  at Expect.That(subject).Should().NotBeReadable()
				                  """);
		}

		[Fact]
		public async Task WhenSubjectIsReadable_ShouldFail()
		{
			Stream subject = new MyStream(canRead: true);

			async Task Act()
				=> await Expect.That(subject).Should().NotBeReadable();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  not be readable,
				                  but it was
				                  at Expect.That(subject).Should().NotBeReadable()
				                  """);
		}
	}
}
