using System.IO;

namespace Testably.Expectations.Tests.That.Streams;

public sealed partial class ThatStream
{
	public sealed class IsNotReadableTests
	{
		[Fact]
		public async Task WhenSubjectIsNotReadable_ShouldSucceed()
		{
			Stream subject = new MyStream(canRead: false);

			async Task Act()
				=> await Expect.That(subject).Should().IsNotReadable();

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			Stream? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().IsNotReadable();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  is not readable,
				                  but found <null>
				                  at Expect.That(subject).Should().IsNotReadable()
				                  """);
		}

		[Fact]
		public async Task WhenSubjectIsReadable_ShouldFail()
		{
			Stream subject = new MyStream(canRead: true);

			async Task Act()
				=> await Expect.That(subject).Should().IsNotReadable();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  is not readable,
				                  but it was
				                  at Expect.That(subject).Should().IsNotReadable()
				                  """);
		}
	}
}
