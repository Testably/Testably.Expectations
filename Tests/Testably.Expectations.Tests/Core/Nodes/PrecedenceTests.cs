namespace Testably.Expectations.Tests.Core.Nodes;

public sealed class PrecedenceTests
{
	public sealed class OrOverAnd
	{
		[Fact]
		public async Task F_and_T_or_F_ShouldFail()
		{
			async Task Act()
				=> await Expect.That(true).Should().IsFalse().And.IsTrue().Or.IsFalse();

			await Expect.That(Act).Should().ThrowsException()
				.Which.HasMessage("""
				                  Expected that true
				                  is False and is True or is False,
				                  but found True
				                  at Expect.That(true).Should().IsFalse().And.IsTrue().Or.IsFalse()
				                  """);
		}

		[Fact]
		public async Task F_and_T_or_T_ShouldSucceed()
		{
			async Task Act()
				=> await Expect.That(true).Should().IsFalse().And.IsTrue().Or.IsTrue();

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Fact]
		public async Task F_or_T_and_F_ShouldFail()
		{
			async Task Act()
				=> await Expect.That(true).Should().IsFalse().Or.IsTrue().And.IsFalse();

			await Expect.That(Act).Should().ThrowsException()
				.Which.HasMessage("""
				                  Expected that true
				                  is False or is True and is False,
				                  but found True
				                  at Expect.That(true).Should().IsFalse().Or.IsTrue().And.IsFalse()
				                  """);
		}

		[Fact]
		public async Task T_and_F_or_F_ShouldFail()
		{
			async Task Act()
				=> await Expect.That(true).Should().IsTrue().And.IsFalse().Or.IsFalse();

			await Expect.That(Act).Should().ThrowsException()
				.Which.HasMessage("""
				                  Expected that true
				                  is True and is False or is False,
				                  but found True
				                  at Expect.That(true).IsTrue().And.IsFalse().Should().Or.IsFalse()
				                  """);
		}

		[Fact]
		public async Task T_and_F_or_T_ShouldSucceed()
		{
			async Task Act()
				=> await Expect.That(true).Should().IsTrue().And.IsFalse().Or.IsTrue();

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Fact]
		public async Task T_or_T_and_F_ShouldSucceed()
		{
			async Task Act()
				=> await Expect.That(true).Should().IsTrue().Or.IsTrue().And.IsFalse();

			await Expect.That(Act).Should().DoesNotThrow();
		}
	}
}
