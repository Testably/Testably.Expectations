using System.IO;

namespace Testably.Expectations.Tests.That.Streams;

public sealed partial class ThatStream
{
	public sealed class IsWriteOnlyTests
	{
		[Theory]
		[InlineData(false, false)]
		[InlineData(true, false)]
		[InlineData(true, true)]
		public async Task WhenSubjectIsNotWriteOnly_ShouldFail(bool canRead, bool canWrite)
		{
			Stream subject = new MyStream(canRead: canRead, canWrite: canWrite);

			async Task Act()
				=> await Expect.That(subject).Should().IsWriteOnly();

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  is write-only,
				                  but it was not
				                  at Expect.That(subject).Should().IsWriteOnly()
				                  """);
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			Stream? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().IsWriteOnly();

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  is write-only,
				                  but found <null>
				                  at Expect.That(subject).Should().IsWriteOnly()
				                  """);
		}

		[Fact]
		public async Task WhenSubjectIsWriteOnly_ShouldSucceed()
		{
			Stream subject = new MyStream(canRead: false, canWrite: true);

			async Task Act()
				=> await Expect.That(subject).Should().IsWriteOnly();

			await Expect.That(Act).Should().DoesNotThrow();
		}
	}
}
