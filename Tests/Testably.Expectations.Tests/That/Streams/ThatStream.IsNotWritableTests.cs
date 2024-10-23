using System.IO;

namespace Testably.Expectations.Tests.That.Streams;

public sealed partial class ThatStream
{
	public sealed class IsNotWritableTests
	{
		[Fact]
		public async Task WhenSubjectIsNotWritable_ShouldSucceed()
		{
			Stream subject = new MyStream(canWrite: false);

			async Task Act()
				=> await Expect.That(subject).Should().IsNotWritable();

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			Stream? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().IsNotWritable();

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  is not writable,
				                  but found <null>
				                  at Expect.That(subject).Should().IsNotWritable()
				                  """);
		}

		[Fact]
		public async Task WhenSubjectIsWritable_ShouldFail()
		{
			Stream subject = new MyStream(canWrite: true);

			async Task Act()
				=> await Expect.That(subject).Should().IsNotWritable();

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  is not writable,
				                  but it was
				                  at Expect.That(subject).Should().IsNotWritable()
				                  """);
		}
	}
}
