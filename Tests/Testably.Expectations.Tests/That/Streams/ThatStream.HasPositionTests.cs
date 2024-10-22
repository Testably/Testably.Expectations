using System.IO;

namespace Testably.Expectations.Tests.That.Streams;

public sealed partial class ThatStream
{
	public sealed class HasPositionTests
	{
		[Theory]
		[AutoData]
		public async Task WhenSubjectHasDifferentPosition_ShouldFail(long position)
		{
			long actualPosition = position > 10000 ? position - 1 : position + 1;
			Stream subject = new MyStream(position: actualPosition);

			async Task Act()
				=> await Expect.That(subject).HasPosition(position);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   has position {position},
				                   but it had position {actualPosition}
				                   at Expect.That(subject).HasPosition(position)
				                   """);
		}

		[Theory]
		[AutoData]
		public async Task WhenSubjectHasSamePosition_ShouldSucceed(long position)
		{
			Stream subject = new MyStream(position: position);

			async Task Act()
				=> await Expect.That(subject).HasPosition(position);

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			Stream? subject = null;

			async Task Act()
				=> await Expect.That(subject).HasPosition(0);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  has position 0,
				                  but found <null>
				                  at Expect.That(subject).HasPosition(0)
				                  """);
		}
	}
}
