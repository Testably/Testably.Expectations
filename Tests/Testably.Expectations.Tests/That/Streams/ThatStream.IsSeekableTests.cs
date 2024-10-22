﻿using System.IO;

namespace Testably.Expectations.Tests.That.Streams;

public sealed partial class ThatStream
{
	public sealed class IsSeekableTests
	{
		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			Stream? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().IsSeekable();

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  is seekable,
				                  but found <null>
				                  at Expect.That(subject).Should().IsSeekable()
				                  """);
		}

		[Fact]
		public async Task WhenSubjectIsSeekable_ShouldSucceed()
		{
			Stream subject = new MyStream(canSeek: true);

			async Task Act()
				=> await Expect.That(subject).Should().IsSeekable();

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsNotSeekable_ShouldFail()
		{
			Stream subject = new MyStream(canSeek: false);

			async Task Act()
				=> await Expect.That(subject).Should().IsSeekable();

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  is seekable,
				                  but it was not
				                  at Expect.That(subject).Should().IsSeekable()
				                  """);
		}
	}
}
