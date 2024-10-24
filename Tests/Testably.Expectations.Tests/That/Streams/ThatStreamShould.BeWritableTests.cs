using System.IO;

namespace Testably.Expectations.Tests.That.Streams;

public sealed partial class ThatStreamShould
{
	public sealed class BeWritableTests
	{
		[Fact]
		public async Task WhenSubjectIsNotWritable_ShouldFail()
		{
			Stream subject = new MyStream(canWrite: false);

			async Task Act()
				=> await Expect.That(subject).Should().BeWritable();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  be writable,
				                  but it was not
				                  at Expect.That(subject).Should().BeWritable()
				                  """);
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			Stream? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().BeWritable();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  be writable,
				                  but found <null>
				                  at Expect.That(subject).Should().BeWritable()
				                  """);
		}

		[Fact]
		public async Task WhenSubjectIsWritable_ShouldSucceed()
		{
			Stream subject = new MyStream(canWrite: true);

			async Task Act()
				=> await Expect.That(subject).Should().BeWritable();

			await Expect.That(Act).Should().NotThrow();
		}
	}

	public sealed class NotBeWritableTests
	{
		[Fact]
		public async Task WhenSubjectIsNotWritable_ShouldSucceed()
		{
			Stream subject = new MyStream(canWrite: false);

			async Task Act()
				=> await Expect.That(subject).Should().NotBeWritable();

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			Stream? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().NotBeWritable();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  not be writable,
				                  but found <null>
				                  at Expect.That(subject).Should().NotBeWritable()
				                  """);
		}

		[Fact]
		public async Task WhenSubjectIsWritable_ShouldFail()
		{
			Stream subject = new MyStream(canWrite: true);

			async Task Act()
				=> await Expect.That(subject).Should().NotBeWritable();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  not be writable,
				                  but it was
				                  at Expect.That(subject).Should().NotBeWritable()
				                  """);
		}
	}
}
