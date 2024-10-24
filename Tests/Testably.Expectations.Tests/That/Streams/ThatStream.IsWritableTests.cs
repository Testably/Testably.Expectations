﻿using System.IO;

namespace Testably.Expectations.Tests.That.Streams;

public sealed partial class ThatStream
{
	public sealed class IsWritableTests
	{
		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			Stream? subject = null;

			async Task Act()
				=> await Expect.That(subject).IsWritable();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  is writable,
				                  but found <null>
				                  at Expect.That(subject).IsWritable()
				                  """);
		}

		[Fact]
		public async Task WhenSubjectIsWritable_ShouldSucceed()
		{
			Stream subject = new MyStream(canWrite: true);

			async Task Act()
				=> await Expect.That(subject).IsWritable();

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsNotWritable_ShouldFail()
		{
			Stream subject = new MyStream(canWrite: false);

			async Task Act()
				=> await Expect.That(subject).IsWritable();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  is writable,
				                  but it was not
				                  at Expect.That(subject).IsWritable()
				                  """);
		}
	}
}
