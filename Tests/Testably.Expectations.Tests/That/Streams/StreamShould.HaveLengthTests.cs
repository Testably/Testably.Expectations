using System.IO;

namespace Testably.Expectations.Tests.That.Streams;

public sealed partial class StreamShould
{
	public sealed class HaveLengthTests
	{
		[Theory]
		[AutoData]
		public async Task WhenSubjectHasDifferentLength_ShouldFail(long length)
		{
			long actualLength = length > 10000 ? length - 1 : length + 1;
			Stream subject = new MyStream(length: actualLength);

			async Task Act()
				=> await Expect.That(subject).Should().HaveLength(length);

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HaveMessage($"""
				                   Expected subject to
				                   have length {length},
				                   but it had length {actualLength}
				                   at Expect.That(subject).Should().HaveLength(length)
				                   """);
		}

		[Theory]
		[AutoData]
		public async Task WhenSubjectHasSameLength_ShouldSucceed(long length)
		{
			Stream subject = new MyStream(length: length);

			async Task Act()
				=> await Expect.That(subject).Should().HaveLength(length);

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			Stream? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().HaveLength(0);

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HaveMessage("""
				                  Expected subject to
				                  have length 0,
				                  but found <null>
				                  at Expect.That(subject).Should().HaveLength(0)
				                  """);
		}
	}

	public sealed class NotHaveLengthTests
	{
		[Theory]
		[AutoData]
		public async Task WhenSubjectHasDifferentLength_ShouldSucceed(long length)
		{
			long actualLength = length > 10000 ? length - 1 : length + 1;
			Stream subject = new MyStream(length: actualLength);

			async Task Act()
				=> await Expect.That(subject).Should().NotHaveLength(length);

			await Expect.That(Act).Should().NotThrow();
		}

		[Theory]
		[AutoData]
		public async Task WhenSubjectHasSameLength_ShouldFail(long length)
		{
			Stream subject = new MyStream(length: length);

			async Task Act()
				=> await Expect.That(subject).Should().NotHaveLength(length);

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HaveMessage($"""
				                   Expected subject to
				                   not have length {length},
				                   but it had
				                   at Expect.That(subject).Should().NotHaveLength(length)
				                   """);
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			Stream? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().NotHaveLength(0);

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HaveMessage("""
				                  Expected subject to
				                  not have length 0,
				                  but found <null>
				                  at Expect.That(subject).Should().NotHaveLength(0)
				                  """);
		}
	}
}
