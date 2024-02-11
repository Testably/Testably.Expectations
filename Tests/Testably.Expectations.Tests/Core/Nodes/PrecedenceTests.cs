using Testably.Expectations.Tests.TestHelpers;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests.Core.Nodes;

public sealed class PrecedenceTests
{
	private class Dummy
	{
		public int Value { get; set; }
	}

	public sealed class OrOverAnd
	{
		[Fact]
		public void F_and_T_or_F_ShouldFail()
		{
			Dummy sut = new();

			void Act()
				=> Expect.That(sut,
					Should.Be.AMappedTest<Dummy>()
						.Which(p => p.Value, Should.Be.AFailedTest(resultText: "foo")).And()
						.Which(p => p.Value, Should.Be.ASuccessfulTest()).Or()
						.Which(p => p.Value, Should.Be.AFailedTest(resultText: "bar")));

			Assert.Throws<XunitException>(Act);
			Expect.That(Act, Should.Throw.Exception().WhichMessage(
				Should.Be.EqualTo(
					"Expected sut .Value to fail and .Value to succeed or .Value to fail, but foo and bar.")));
		}

		[Fact]
		public void F_and_T_or_T_ShouldSucceed()
		{
			Dummy sut = new();

			void Act()
				=> Expect.That(sut,
					Should.Be.AMappedTest<Dummy>()
						.Which(p => p.Value, Should.Be.AFailedTest()).And()
						.Which(p => p.Value, Should.Be.ASuccessfulTest()).Or()
						.Which(p => p.Value, Should.Be.ASuccessfulTest()));

			Expect.That(Act, Should.Not.Throw.Exception());
		}

		[Fact]
		public void F_or_T_and_F_ShouldFail()
		{
			Dummy sut = new();

			void Act()
				=> Expect.That(sut,
					Should.Be.AMappedTest<Dummy>()
						.Which("Value", Should.Be.AFailedTest(resultText: "foo")).Or()
						.Which("Value", Should.Be.ASuccessfulTest()).And()
						.Which("Value", Should.Be.AFailedTest(resultText: "bar")));

			Expect.That(Act, Should.Throw.Exception().WhichMessage(
				Should.Be.EqualTo(
					"Expected sut .Value to fail or .Value to succeed and .Value to fail, but foo and bar.")));
		}

		[Fact]
		public void T_and_F_or_F_ShouldFail()
		{
			Dummy sut = new();

			void Act()
				=> Expect.That(sut,
					Should.Be.AMappedTest<Dummy>()
						.Which("Value", Should.Be.ASuccessfulTest()).And()
						.Which("Value", Should.Be.AFailedTest(resultText: "foo")).Or()
						.Which("Value", Should.Be.AFailedTest(resultText: "bar")));

			Expect.That(Act, Should.Throw.Exception().WhichMessage(
				Should.Be.EqualTo(
					"Expected sut .Value to succeed and .Value to fail or .Value to fail, but foo and bar.")));
		}

		[Fact]
		public void T_and_F_or_T_ShouldSucceed()
		{
			Dummy sut = new();

			void Act()
				=> Expect.That(sut,
					Should.Be.AMappedTest<Dummy>()
						.Which("Value", Should.Be.ASuccessfulTest()).And()
						.Which("Value", Should.Be.AFailedTest()).Or()
						.Which("Value", Should.Be.ASuccessfulTest()));

			Expect.That(Act, Should.Not.Throw.Exception());
		}

		[Fact]
		public void T_or_T_and_F_ShouldSucceed()
		{
			Dummy sut = new();

			void Act()
				=> Expect.That(sut,
					Should.Be.AMappedTest<Dummy>()
						.Which("Value", Should.Be.ASuccessfulTest()).Or()
						.Which("Value", Should.Be.ASuccessfulTest()).And()
						.Which("Value", Should.Be.AFailedTest()));

			Expect.That(Act, Should.Not.Throw.Exception());
		}
	}
}
