﻿namespace Testably.Expectations.Tests.That.Guids;

public sealed partial class ThatNullableGuid
{
	public sealed class IsEmptyTests
	{
		[Fact]
		public async Task WhenSubjectIsEmpty_ShouldSucceed()
		{
			Guid subject = Guid.Empty;

			async Task Act()
				=> await Expect.That(subject).Should().IsEmpty();

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsNotEmpty_ShouldFail()
		{
			Guid? subject = OtherGuid();

			async Task Act()
				=> await Expect.That(subject).Should().IsEmpty();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage($"""
				                   Expected subject to
				                   is empty,
				                   but found {subject}
				                   at Expect.That(subject).Should().IsEmpty()
				                   """);
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			Guid? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().IsEmpty();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  is empty,
				                  but found <null>
				                  at Expect.That(subject).Should().IsEmpty()
				                  """);
		}
	}
}
