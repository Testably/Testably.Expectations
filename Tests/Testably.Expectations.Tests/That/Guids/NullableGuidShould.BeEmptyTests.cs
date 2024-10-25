﻿namespace Testably.Expectations.Tests.That.Guids;

public sealed partial class NullableGuidShould
{
	public sealed class BeEmptyTests
	{
		[Fact]
		public async Task WhenSubjectIsEmpty_ShouldSucceed()
		{
			Guid subject = Guid.Empty;

			async Task Act()
				=> await Expect.That(subject).Should().BeEmpty();

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsNotEmpty_ShouldFail()
		{
			Guid? subject = OtherGuid();

			async Task Act()
				=> await Expect.That(subject).Should().BeEmpty();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage($"""
				                   Expected subject to
				                   be empty,
				                   but found {subject}
				                   at Expect.That(subject).Should().BeEmpty()
				                   """);
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			Guid? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().BeEmpty();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  be empty,
				                  but found <null>
				                  at Expect.That(subject).Should().BeEmpty()
				                  """);
		}
	}

	public sealed class NotBeEmptyTests
	{
		[Fact]
		public async Task WhenSubjectIsEmpty_ShouldFail()
		{
			Guid subject = Guid.Empty;

			async Task Act()
				=> await Expect.That(subject).Should().NotBeEmpty();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage($"""
				                   Expected subject to
				                   not be empty,
				                   but found {subject}
				                   at Expect.That(subject).Should().NotBeEmpty()
				                   """);
		}

		[Fact]
		public async Task WhenSubjectIsNotEmpty_ShouldSucceed()
		{
			Guid? subject = OtherGuid();

			async Task Act()
				=> await Expect.That(subject).Should().NotBeEmpty();

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			Guid? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().NotBeEmpty();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  not be empty,
				                  but found <null>
				                  at Expect.That(subject).Should().NotBeEmpty()
				                  """);
		}
	}
}
