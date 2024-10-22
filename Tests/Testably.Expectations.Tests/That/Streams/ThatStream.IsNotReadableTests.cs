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
				=> await Expect.That(subject).IsNotReadable();

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			Stream? subject = null;

			async Task Act()
				=> await Expect.That(subject).IsNotReadable();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  is not readable,
				                  but found <null>
				                  at Expect.That(subject).IsNotReadable()
				                  """);
		}

		[Fact]
		public async Task WhenSubjectIsReadable_ShouldFail()
		{
			Stream subject = new MyStream(canRead: true);

			async Task Act()
				=> await Expect.That(subject).IsNotReadable();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  is not readable,
				                  but it was
				                  at Expect.That(subject).IsNotReadable()
				                  """);
		}
	}
}
