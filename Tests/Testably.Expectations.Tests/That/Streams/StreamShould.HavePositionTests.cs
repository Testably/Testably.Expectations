using System.IO;

namespace Testably.Expectations.Tests.That.Streams;

public sealed partial class StreamShould
{
	public sealed class HavePositionTests
	{
		[Theory]
		[AutoData]
		public async Task WhenSubjectHasDifferentPosition_ShouldFail(long position)
		{
			long actualPosition = position > 10000 ? position - 1 : position + 1;
			Stream subject = new MyStream(position: actualPosition);

			async Task Act()
				=> await Expect.That(subject).Should().HavePosition(position);

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HaveMessage($"""
				                   Expected subject to
				                   have position {position},
				                   but it had position {actualPosition}
				                   at Expect.That(subject).Should().HavePosition(position)
				                   """);
		}

		[Theory]
		[AutoData]
		public async Task WhenSubjectHasSamePosition_ShouldSucceed(long position)
		{
			Stream subject = new MyStream(position: position);

			async Task Act()
				=> await Expect.That(subject).Should().HavePosition(position);

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			Stream? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().HavePosition(0);

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HaveMessage("""
				                  Expected subject to
				                  have position 0,
				                  but found <null>
				                  at Expect.That(subject).Should().HavePosition(0)
				                  """);
		}
	}

	public sealed class NotHavePositionTests
	{
		[Theory]
		[AutoData]
		public async Task WhenSubjectHasDifferentPosition_ShouldSucceed(long position)
		{
			long actualPosition = position > 10000 ? position - 1 : position + 1;
			Stream subject = new MyStream(position: actualPosition);

			async Task Act()
				=> await Expect.That(subject).Should().NotHavePosition(position);

			await Expect.That(Act).Should().NotThrow();
		}

		[Theory]
		[AutoData]
		public async Task WhenSubjectHasSamePosition_ShouldFail(long position)
		{
			Stream subject = new MyStream(position: position);

			async Task Act()
				=> await Expect.That(subject).Should().NotHavePosition(position);

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HaveMessage($"""
				                   Expected subject to
				                   not have position {position},
				                   but it had
				                   at Expect.That(subject).Should().NotHavePosition(position)
				                   """);
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			Stream? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().NotHavePosition(0);

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HaveMessage("""
				                  Expected subject to
				                  not have position 0,
				                  but found <null>
				                  at Expect.That(subject).Should().NotHavePosition(0)
				                  """);
		}
	}
}
