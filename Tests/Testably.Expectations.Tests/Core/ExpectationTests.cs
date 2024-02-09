using Testably.Expectations.Tests.TestHelpers;
using Xunit;

namespace Testably.Expectations.Tests.Core;

public sealed class ExpectationTests
{
	[Fact]
	public void And_ShouldFailWhenAnyArgumentFails()
	{
		void Act1()
			=> Expect.That(true, Should.Be.AnExpectation(false).And().Be.AnExpectation(true));

		void Act2()
			=> Expect.That(true, Should.Be.AnExpectation(true).And().Be.AnExpectation(false));

		Expect.That(Act1, Should.Throw.Exception());
		Expect.That(Act2, Should.Throw.Exception());
	}

	[Fact]
	public void And_ShouldRequireBothArgumentsToSucceed()
	{
		Expect.That(true, Should.Be.AnExpectation(true).And().Be.AnExpectation(true));
	}

	[Fact]
	public void Or_ShouldFailWhenBothArgumentsFail()
	{
		void Act()
			=> Expect.That(true, Should.Be.AnExpectation(false).Or().Be.AnExpectation(false));

		Expect.That(Act, Should.Throw.Exception());
	}

	[Fact]
	public void Or_ShouldRequireAnyArgumentToSucceed()
	{
		Expect.That(true, Should.Be.AnExpectation(false).Or().Be.AnExpectation(true));
		Expect.That(true, Should.Be.AnExpectation(true).Or().Be.AnExpectation(false));
	}
}
