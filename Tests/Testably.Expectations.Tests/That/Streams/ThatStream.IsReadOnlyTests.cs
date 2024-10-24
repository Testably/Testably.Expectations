﻿using System.IO;

namespace Testably.Expectations.Tests.That.Streams;

public sealed partial class ThatStream
{
	public sealed class IsReadOnlyTests
	{
		[Theory]
		[InlineData(false, false)]
		[InlineData(false, true)]
		[InlineData(true, true)]
		public async Task WhenSubjectIsNotReadOnly_ShouldFail(bool canRead, bool canWrite)
		{
			Stream subject = new MyStream(canRead: canRead, canWrite: canWrite);

			async Task Act()
				=> await Expect.That(subject).IsReadOnly();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  is read-only,
				                  but it was not
				                  at Expect.That(subject).IsReadOnly()
				                  """);
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			Stream? subject = null;

			async Task Act()
				=> await Expect.That(subject).IsReadOnly();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  is read-only,
				                  but found <null>
				                  at Expect.That(subject).IsReadOnly()
				                  """);
		}

		[Fact]
		public async Task WhenSubjectIsReadOnly_ShouldSucceed()
		{
			Stream subject = new MyStream(canRead: true, canWrite: false);

			async Task Act()
				=> await Expect.That(subject).IsReadOnly();

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
