using System.IO;

namespace Testably.Expectations.Tests.That.Streams;

public sealed partial class ThatStream
{
	public sealed class IsNotSeekableTests
	{
		[Fact]
		public async Task WhenSubjectIsNotSeekable_ShouldSucceed()
		{
			Stream subject = new MyStream(canSeek: false);

			async Task Act()
				=> await Expect.That(subject).Should().IsNotSeekable();

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			Stream? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().IsNotSeekable();

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  is not seekable,
				                  but found <null>
				                  at Expect.That(subject).Should().IsNotSeekable()
				                  """);
		}

		[Fact]
		public async Task WhenSubjectIsSeekable_ShouldFail()
		{
			Stream subject = new MyStream(canSeek: true);

			async Task Act()
				=> await Expect.That(subject).Should().IsNotSeekable();

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  is not seekable,
				                  but it was
				                  at Expect.That(subject).Should().IsNotSeekable()
				                  """);
		}
	}
}
