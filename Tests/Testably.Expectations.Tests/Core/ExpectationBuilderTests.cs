using Testably.Expectations.Tests.TestHelpers;
using Xunit;

namespace Testably.Expectations.Tests.Core;

public sealed class ExpectationBuilderTests
{
	public sealed class TreeValidation
	{
		private const int AnyValue = 1;

		[Theory]
		[InlineData(true, true)]
		[InlineData(false, false)]
		public void A(bool a, bool shouldSucceed)
		{
			void Act()
				=> Expect.That(AnyValue, Should.Be
					.AVariable(a));

			Expect.That(Act, Should.Throw.ExceptionIf(!shouldSucceed).WhichMessage(
				Should.Contain.Substring("a, but it did.")));
		}

		[Theory]
		[InlineData(true, false)]
		[InlineData(false, true)]
		public void Not_A(bool a, bool shouldSucceed)
		{
			void Act()
				=> Expect.That(AnyValue, Should
					.Not.Be
					.AVariable(a));

			Expect.That(Act, Should.Throw.ExceptionIf(!shouldSucceed).WhichMessage(
				Should.Contain.Substring("a, but it did.")));
		}

		[Theory]
		[InlineData(false, false, false)]
		[InlineData(false, true, false)]
		[InlineData(true, false, false)]
		[InlineData(true, true, true)]
		public void A_And_B(bool a, bool b, bool shouldSucceed)
		{
			void Act()
				=> Expect.That(AnyValue, Should.Be
					.AVariable(a)
					.And().Be
					.AVariable(b));

			Expect.That(Act, Should.Throw.ExceptionIf(!shouldSucceed).WhichMessage(
				Should.Contain.Substring("a and b, but it did.")));
		}

		[Theory]
		[InlineData(false, false, false)]
		[InlineData(false, true, true)]
		[InlineData(true, false, true)]
		[InlineData(true, true, true)]
		public void A_Or_B(bool a, bool b, bool shouldSucceed)
		{
			void Act()
				=> Expect.That(AnyValue, Should.Be
					.AVariable(a)
					.Or().Be
					.AVariable(b));

			Expect.That(Act, Should.Throw.ExceptionIf(!shouldSucceed).WhichMessage(
				Should.Contain.Substring("a or b, but it did.")));
		}

		[Theory]
		[InlineData(false, true, false, false)]
		[InlineData(true, true, false, true)]
		[InlineData(false, false, true, true)]
		public void A_And_B_Or_C(bool a, bool b, bool c, bool shouldSucceed)
		{
			void Act()
				=> Expect.That(AnyValue, Should.Be
					.AVariable(a)
					.And().Be
					.AVariable(b)
					.Or().Be
					.AVariable(c));

			Expect.That(Act, Should.Throw.ExceptionIf(!shouldSucceed).WhichMessage(
				Should.Contain.Substring("a and b or c, but it did.")));
		}

		[Theory]
		[InlineData(false, true, true, false)]
		[InlineData(true, true, true, true)]
		public void A_And_B_Or_Not_C(bool a, bool b, bool c, bool shouldSucceed)
		{
			void Act()
				=> Expect.That(AnyValue, Should.Be
					.AVariable(a)
					.And().Be
					.AVariable(b)
					.Or()
					.Not.Be
					.AVariable(c));

			Expect.That(Act, Should.Throw.ExceptionIf(!shouldSucceed).WhichMessage(
				Should.Contain.Substring("a and b or not c, but it did.")));
		}

		[Theory]
		[InlineData(false, true, true, true)]
		[InlineData(true, true, true, true)]
		[InlineData(true, false, false, true)]
		public void A_Or_B_And_C(bool a, bool b, bool c, bool shouldSucceed)
		{
			void Act()
				=> Expect.That(AnyValue, Should.Be
					.AVariable(a)
					.Or().Be
					.AVariable(b)
					.And().Be
					.AVariable(c));

			Expect.That(Act, Should.Throw.ExceptionIf(!shouldSucceed).WhichMessage(
				Should.Contain.Substring("a or b and c, but it did.")));
		}
	}
}
