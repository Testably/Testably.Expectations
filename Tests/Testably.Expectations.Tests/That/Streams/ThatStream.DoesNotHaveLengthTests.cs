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
				=> await Expect.That(subject).DoesNotHaveLength(length);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   does not have length {length},
				                   but it had
				                   at Expect.That(subject).DoesNotHaveLength(length)
				                   """);
		}

		[Theory]
		[AutoData]
		public async Task WhenSubjectHasDifferentLength_ShouldSucceed(long length)
		{
			long actualLength = length > 10000 ? length - 1 : length + 1;
			Stream subject = new MyStream(length: actualLength);

			async Task Act()
				=> await Expect.That(subject).DoesNotHaveLength(length);

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			Stream? subject = null;

			async Task Act()
				=> await Expect.That(subject).DoesNotHaveLength(0);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  does not have length 0,
				                  but found <null>
				                  at Expect.That(subject).DoesNotHaveLength(0)
				                  """);
		}
	}
}
