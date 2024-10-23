using System.IO;

namespace Testably.Expectations.Tests.That.Streams;

public sealed partial class ThatStream
{
	public sealed class DoesNotHaveLengthTests
	{
		[Theory]
		[AutoData]
		public async Task WhenSubjectHasSameLength_ShouldFail(long length)
		{
			Stream subject = new MyStream(length: length);

			async Task Act()
				=> await Expect.That(subject).Should().DoesNotHaveLength(length);

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected subject to
				                   does not have length {length},
				                   but it had
				                   at Expect.That(subject).Should().DoesNotHaveLength(length)
				                   """);
		}

		[Theory]
		[AutoData]
		public async Task WhenSubjectHasDifferentLength_ShouldSucceed(long length)
		{
			long actualLength = length > 10000 ? length - 1 : length + 1;
			Stream subject = new MyStream(length: actualLength);

			async Task Act()
				=> await Expect.That(subject).Should().DoesNotHaveLength(length);

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			Stream? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().DoesNotHaveLength(0);

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  does not have length 0,
				                  but found <null>
				                  at Expect.That(subject).Should().DoesNotHaveLength(0)
				                  """);
		}
	}
}
