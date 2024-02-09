using Testably.Expectations.Tests.TestHelpers;
using Xunit;

namespace Testably.Expectations.Tests.Core;

public sealed class NullableExpectationTests
{
	[Fact]
	public void And_ShouldFailWhenAnyArgumentFails()
	{
		void Act1()
			=> Expect.That(true,
				Should.Be.ANullableExpectation(false).And().Be.ANullableExpectation(true));

		void Act2()
			=> Expect.That(true,
				Should.Be.ANullableExpectation(true).And().Be.ANullableExpectation(false));

		Expect.That(Act1, Should.Throw.Exception());
		Expect.That(Act2, Should.Throw.Exception());
	}

	[Fact]
	public void And_ShouldRequireBothArgumentsToSucceed()
	{
		Expect.That(true, Should.Be.ANullableExpectation(true).And().Be.ANullableExpectation(true));
	}

	[Fact]
	public void Or_ShouldFailWhenBothArgumentsFail()
	{
		void Act()
			=> Expect.That(true,
				Should.Be.ANullableExpectation(false).Or().Be.ANullableExpectation(false));

		Expect.That(Act, Should.Throw.Exception());
	}

	[Fact]
	public void Or_ShouldRequireAnyArgumentToSucceed()
	{
		Expect.That(true, Should.Be.ANullableExpectation(false).Or().Be.ANullableExpectation(true));
		Expect.That(true, Should.Be.ANullableExpectation(true).Or().Be.ANullableExpectation(false));
	}
}
