﻿namespace Testably.Expectations.Tests.Primitives.Guids;

public sealed partial class ThatNullableGuid
{
	public sealed class IsEmptyTests
	{
		[Fact]
		public async Task WhenValueIsEmpty_ShouldSucceed()
		{
			Guid subject = Guid.Empty;

			async Task Act()
				=> await Expect.That(subject).IsEmpty();

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task WhenValueIsNotEmpty_ShouldFail()
		{
			Guid? subject = OtherGuid();

			async Task Act()
				=> await Expect.That(subject).IsEmpty();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   is empty,
				                   but found {subject}
				                   at Expect.That(subject).IsEmpty()
				                   """);
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			Guid? subject = null;

			async Task Act()
				=> await Expect.That(subject).IsEmpty();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  is empty,
				                  but found <null>
				                  at Expect.That(subject).IsEmpty()
				                  """);
		}
	}
}