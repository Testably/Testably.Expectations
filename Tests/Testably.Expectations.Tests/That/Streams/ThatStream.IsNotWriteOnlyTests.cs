using System.IO;

namespace Testably.Expectations.Tests.That.Streams;

public sealed partial class ThatStream
{
	public sealed class IsNotWriteOnlyTests
	{
		[Theory]
		[InlineData(false, false)]
		[InlineData(true, false)]
		[InlineData(true, true)]
		public async Task WhenSubjectIsNotWriteOnly_ShouldSucceed(bool canRead, bool canWrite)
		{
			Stream subject = new MyStream(canRead: canRead, canWrite: canWrite);

			async Task Act()
				=> await Expect.That(subject).Should().IsNotWriteOnly();

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			Stream? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().IsNotWriteOnly();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  is not write-only,
				                  but found <null>
				                  at Expect.That(subject).Should().IsNotWriteOnly()
				                  """);
		}

		[Fact]
		public async Task WhenSubjectIsWriteOnly_ShouldFail()
		{
			Stream subject = new MyStream(canRead: false, canWrite: true);

			async Task Act()
				=> await Expect.That(subject).Should().IsNotWriteOnly();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  is not write-only,
				                  but it was
				                  at Expect.That(subject).Should().IsNotWriteOnly()
				                  """);
		}
	}
}
