using System.IO;

namespace Testably.Expectations.Tests.That.Streams;

public sealed partial class StreamShould
{
	public sealed class BeSeekableTests
	{
		[Fact]
		public async Task WhenSubjectIsNotSeekable_ShouldFail()
		{
			Stream subject = new MyStream(canSeek: false);

			async Task Act()
				=> await Expect.That(subject).Should().BeSeekable();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  be seekable,
				                  but it was not
				                  at Expect.That(subject).Should().BeSeekable()
				                  """);
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			Stream? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().BeSeekable();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  be seekable,
				                  but found <null>
				                  at Expect.That(subject).Should().BeSeekable()
				                  """);
		}

		[Fact]
		public async Task WhenSubjectIsSeekable_ShouldSucceed()
		{
			Stream subject = new MyStream(canSeek: true);

			async Task Act()
				=> await Expect.That(subject).Should().BeSeekable();

			await Expect.That(Act).Should().NotThrow();
		}
	}

	public sealed class NotBeSeekableTests
	{
		[Fact]
		public async Task WhenSubjectIsNotSeekable_ShouldSucceed()
		{
			Stream subject = new MyStream(canSeek: false);

			async Task Act()
				=> await Expect.That(subject).Should().NotBeSeekable();

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			Stream? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().NotBeSeekable();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  not be seekable,
				                  but found <null>
				                  at Expect.That(subject).Should().NotBeSeekable()
				                  """);
		}

		[Fact]
		public async Task WhenSubjectIsSeekable_ShouldFail()
		{
			Stream subject = new MyStream(canSeek: true);

			async Task Act()
				=> await Expect.That(subject).Should().NotBeSeekable();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  not be seekable,
				                  but it was
				                  at Expect.That(subject).Should().NotBeSeekable()
				                  """);
		}
	}
}
