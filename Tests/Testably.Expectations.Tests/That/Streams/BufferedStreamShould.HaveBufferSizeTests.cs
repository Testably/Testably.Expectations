#if NET6_0_OR_GREATER
using System.IO;

namespace Testably.Expectations.Tests.That.Streams;

public sealed partial class BufferedStreamShould
{
	public sealed class HaveBufferSizeTests
	{
		[Theory]
		[AutoData]
		public async Task WhenSubjectHasDifferentBufferSize_ShouldFail(int buffersize)
		{
			int actualBufferSize = buffersize > 10000 ? buffersize - 1 : buffersize + 1;
			using BufferedStream subject = GetBufferedStream(actualBufferSize);

			async Task Act()
				=> await Expect.That(subject).Should().HaveBufferSize(buffersize);

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage($"""
				                   Expected subject to
				                   have buffer size {buffersize},
				                   but it had buffer size {actualBufferSize}
				                   at Expect.That(subject).Should().HaveBufferSize(buffersize)
				                   """);
		}

		[Theory]
		[AutoData]
		public async Task WhenSubjectHasSameBufferSize_ShouldSucceed(int buffersize)
		{
			using BufferedStream subject = GetBufferedStream(buffersize);

			async Task Act()
				=> await Expect.That(subject).Should().HaveBufferSize(buffersize);

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			using BufferedStream? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().HaveBufferSize(0);

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  have buffer size 0,
				                  but found <null>
				                  at Expect.That(subject).Should().HaveBufferSize(0)
				                  """);
		}
	}

	public sealed class NotHaveBufferSizeTests
	{
		[Theory]
		[AutoData]
		public async Task WhenSubjectHasDifferentBufferSize_ShouldSucceed(int buffersize)
		{
			int actualBufferSize = buffersize > 10000 ? buffersize - 1 : buffersize + 1;
			using BufferedStream subject = GetBufferedStream(actualBufferSize);

			async Task Act()
				=> await Expect.That(subject).Should().NotHaveBufferSize(buffersize);

			await Expect.That(Act).Should().NotThrow();
		}

		[Theory]
		[AutoData]
		public async Task WhenSubjectHasSameBufferSize_ShouldFail(int buffersize)
		{
			using BufferedStream subject = GetBufferedStream(buffersize);

			async Task Act()
				=> await Expect.That(subject).Should().NotHaveBufferSize(buffersize);

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage($"""
				                   Expected subject to
				                   not have buffer size {buffersize},
				                   but it had
				                   at Expect.That(subject).Should().NotHaveBufferSize(buffersize)
				                   """);
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			using BufferedStream? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().NotHaveBufferSize(0);

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  not have buffer size 0,
				                  but found <null>
				                  at Expect.That(subject).Should().NotHaveBufferSize(0)
				                  """);
		}
	}
}
#endif
