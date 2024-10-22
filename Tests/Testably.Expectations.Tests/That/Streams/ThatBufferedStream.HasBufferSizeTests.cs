#if NET6_0_OR_GREATER
using System.IO;

namespace Testably.Expectations.Tests.That.Streams;

public sealed partial class ThatBufferedStream
{
	public sealed class HasBufferSizeTests
	{
		[Theory]
		[AutoData]
		public async Task WhenSubjectHasDifferentBufferSize_ShouldFail(int buffersize)
		{
			int actualBufferSize = buffersize > 10000 ? buffersize - 1 : buffersize + 1;
			using BufferedStream subject = GetBufferedStream(actualBufferSize);

			async Task Act()
				=> await Expect.That(subject).HasBufferSize(buffersize);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   has buffer size {buffersize},
				                   but it had buffer size {actualBufferSize}
				                   at Expect.That(subject).HasBufferSize(buffersize)
				                   """);
		}

		[Theory]
		[AutoData]
		public async Task WhenSubjectHasSameBufferSize_ShouldSucceed(int buffersize)
		{
			using BufferedStream subject = GetBufferedStream(buffersize);

			async Task Act()
				=> await Expect.That(subject).HasBufferSize(buffersize);

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			using BufferedStream? subject = null;

			async Task Act()
				=> await Expect.That(subject).HasBufferSize(0);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  has buffer size 0,
				                  but found <null>
				                  at Expect.That(subject).HasBufferSize(0)
				                  """);
		}
	}
}
#endif
