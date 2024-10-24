﻿using System.IO;

namespace Testably.Expectations.Tests.That.Streams;

public sealed partial class ThatStream
{
	public sealed class IsWriteOnlyTests
	{
		[Theory]
		[InlineData(false, false)]
		[InlineData(true, false)]
		[InlineData(true, true)]
		public async Task WhenSubjectIsNotWriteOnly_ShouldFail(bool canRead, bool canWrite)
		{
			Stream subject = new MyStream(canRead: canRead, canWrite: canWrite);

			async Task Act()
				=> await Expect.That(subject).IsWriteOnly();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  is write-only,
				                  but it was not
				                  at Expect.That(subject).IsWriteOnly()
				                  """);
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			Stream? subject = null;

			async Task Act()
				=> await Expect.That(subject).IsWriteOnly();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  is write-only,
				                  but found <null>
				                  at Expect.That(subject).IsWriteOnly()
				                  """);
		}

		[Fact]
		public async Task WhenSubjectIsWriteOnly_ShouldSucceed()
		{
			Stream subject = new MyStream(canRead: false, canWrite: true);

			async Task Act()
				=> await Expect.That(subject).IsWriteOnly();

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
