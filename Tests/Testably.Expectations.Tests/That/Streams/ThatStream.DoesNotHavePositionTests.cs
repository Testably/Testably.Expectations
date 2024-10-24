using System.IO;

namespace Testably.Expectations.Tests.That.Streams;

public sealed partial class ThatStream
{
	public sealed class DoesNotHavePositionTests
	{
		[Theory]
		[AutoData]
		public async Task WhenSubjectHasSamePosition_ShouldFail(long position)
		{
			Stream subject = new MyStream(position: position);

			async Task Act()
				=> await Expect.That(subject).Should().DoesNotHavePosition(position);

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage($"""
				                   Expected subject to
				                   does not have position {position},
				                   but it had
				                   at Expect.That(subject).Should().DoesNotHavePosition(position)
				                   """);
		}

		[Theory]
		[AutoData]
		public async Task WhenSubjectHasDifferentPosition_ShouldSucceed(long position)
		{
			long actualPosition = position > 10000 ? position - 1 : position + 1;
			Stream subject = new MyStream(position: actualPosition);

			async Task Act()
				=> await Expect.That(subject).Should().DoesNotHavePosition(position);

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			Stream? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().DoesNotHavePosition(0);

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  does not have position 0,
				                  but found <null>
				                  at Expect.That(subject).Should().DoesNotHavePosition(0)
				                  """);
		}
	}
}
