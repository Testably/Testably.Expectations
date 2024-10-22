#if NET6_0_OR_GREATER
using System.IO;

namespace Testably.Expectations.Tests.That.Streams;

public sealed partial class ThatBufferedStream
{
	public sealed class DoesNotHaveBufferSizeTests
	{
		[Theory]
		[AutoData]
		public async Task WhenSubjectHasDifferentBufferSize_ShouldSucceed(int buffersize)
		{
			int actualBufferSize = buffersize > 10000 ? buffersize - 1 : buffersize + 1;
			using BufferedStream subject = GetBufferedStream(actualBufferSize);

			async Task Act()
				=> await Expect.That(subject).DoesNotHaveBufferSize(buffersize);

			await Expect.That(Act).DoesNotThrow();
		}

		[Theory]
		[AutoData]
		public async Task WhenSubjectHasSameBufferSize_ShouldFail(int buffersize)
		{
			using BufferedStream subject = GetBufferedStream(buffersize);

			async Task Act()
				=> await Expect.That(subject).DoesNotHaveBufferSize(buffersize);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   does not have buffer size {buffersize},
				                   but it had
				                   at Expect.That(subject).DoesNotHaveBufferSize(buffersize)
				                   """);
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			using BufferedStream? subject = null;

			async Task Act()
				=> await Expect.That(subject).DoesNotHaveBufferSize(0);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  does not have buffer size 0,
				                  but found <null>
				                  at Expect.That(subject).DoesNotHaveBufferSize(0)
				                  """);
		}
	}
}
#endif
