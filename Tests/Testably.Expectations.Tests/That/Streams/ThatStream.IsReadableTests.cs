using System.IO;

namespace Testably.Expectations.Tests.That.Streams;

public sealed partial class ThatStream
{
	public sealed class IsReadableTests
	{
		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			Stream? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().IsReadable();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  is readable,
				                  but found <null>
				                  at Expect.That(subject).Should().IsReadable()
				                  """);
		}

		[Fact]
		public async Task WhenSubjectIsReadable_ShouldSucceed()
		{
			Stream subject = new MyStream(canRead: true);

			async Task Act()
				=> await Expect.That(subject).Should().IsReadable();

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsNotReadable_ShouldFail()
		{
			Stream subject = new MyStream(canRead: false);

			async Task Act()
				=> await Expect.That(subject).Should().IsReadable();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  is readable,
				                  but it was not
				                  at Expect.That(subject).Should().IsReadable()
				                  """);
		}
	}
}
