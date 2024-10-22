using System.IO;

namespace Testably.Expectations.Tests.That.Streams;

public sealed partial class ThatStream
{
	public sealed class IsNotReadOnlyTests
	{
		[Theory]
		[InlineData(false, false)]
		[InlineData(false, true)]
		[InlineData(true, true)]
		public async Task WhenSubjectIsNotReadOnly_ShouldSucceed(bool canRead, bool canWrite)
		{
			Stream subject = new MyStream(canRead: canRead, canWrite: canWrite);

			async Task Act()
				=> await Expect.That(subject).Should().IsNotReadOnly();

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			Stream? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().IsNotReadOnly();

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  is not read-only,
				                  but found <null>
				                  at Expect.That(subject).Should().IsNotReadOnly()
				                  """);
		}

		[Fact]
		public async Task WhenSubjectIsReadOnly_ShouldFail()
		{
			Stream subject = new MyStream(canRead: true, canWrite: false);

			async Task Act()
				=> await Expect.That(subject).Should().IsNotReadOnly();

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  is not read-only,
				                  but it was
				                  at Expect.That(subject).Should().IsNotReadOnly()
				                  """);
		}
	}
}
