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
				=> await Expect.That(subject).IsReadable();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  is readable,
				                  but found <null>
				                  at Expect.That(subject).IsReadable()
				                  """);
		}

		[Fact]
		public async Task WhenSubjectIsReadable_ShouldSucceed()
		{
			Stream subject = new MyStream(canRead: true);

			async Task Act()
				=> await Expect.That(subject).IsReadable();

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsNotReadable_ShouldFail()
		{
			Stream subject = new MyStream(canRead: false);

			async Task Act()
				=> await Expect.That(subject).IsReadable();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  is readable,
				                  but it was not
				                  at Expect.That(subject).IsReadable()
				                  """);
		}
	}
}
