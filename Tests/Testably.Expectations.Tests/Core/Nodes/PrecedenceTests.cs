﻿namespace Testably.Expectations.Tests.Core.Nodes;

public sealed class PrecedenceTests
{
	public sealed class OrOverAnd
	{
		[Fact]
		public async Task F_and_T_or_F_ShouldFail()
		{
			async Task Act()
				=> await Expect.That(true).Should().BeFalse().And.BeTrue().Or.BeFalse();

			await Expect.That(Act).Should().ThrowException()
				.WithMessage("""
				                  Expected true to
				                  be False and be True or be False,
				                  but found True
				                  at Expect.That(true).Should().BeFalse().And.BeTrue().Or.BeFalse()
				                  """);
		}

		[Fact]
		public async Task F_and_T_or_T_ShouldSucceed()
		{
			async Task Act()
				=> await Expect.That(true).Should().BeFalse().And.BeTrue().Or.BeTrue();

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task F_or_T_and_F_ShouldFail()
		{
			async Task Act()
				=> await Expect.That(true).Should().BeFalse().Or.BeTrue().And.BeFalse();

			await Expect.That(Act).Should().ThrowException()
				.WithMessage("""
				                  Expected true to
				                  be False or be True and be False,
				                  but found True
				                  at Expect.That(true).Should().BeFalse().Or.BeTrue().And.BeFalse()
				                  """);
		}

		[Fact]
		public async Task T_and_F_or_F_ShouldFail()
		{
			async Task Act()
				=> await Expect.That(true).Should().BeTrue().And.BeFalse().Or.BeFalse();

			await Expect.That(Act).Should().ThrowException()
				.WithMessage("""
				                  Expected true to
				                  be True and be False or be False,
				                  but found True
				                  at Expect.That(true).Should().BeTrue().And.BeFalse().Or.BeFalse()
				                  """);
		}

		[Fact]
		public async Task T_and_F_or_T_ShouldSucceed()
		{
			async Task Act()
				=> await Expect.That(true).Should().BeTrue().And.BeFalse().Or.BeTrue();

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task T_or_T_and_F_ShouldSucceed()
		{
			async Task Act()
				=> await Expect.That(true).Should().BeTrue().Or.BeTrue().And.BeFalse();

			await Expect.That(Act).Should().NotThrow();
		}
	}
}
