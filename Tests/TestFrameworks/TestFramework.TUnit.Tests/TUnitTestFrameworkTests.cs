using System.Threading.Tasks;
using Testably.Expectations;
using TUnit.Assertions.Exceptions;
using TUnit.Core.Exceptions;

namespace TestFramework.TUnit.Tests;

public sealed class TUnitTestFrameworkTests
{
	[Test]
	public async Task OnFail_WhenUsingXunit2AsTestFramework_ShouldThrowXunitException()
	{
		void Act()
			=> Testably.Expectations.Fail.Test("my message");

		await Expect.That(Act).Should().Throws<AssertionException>();
	}

	[Test]
	public async Task OnSkip_WhenUsingXunit2AsTestFramework_ShouldThrowSkipException()
	{
		void Act()
			=> Testably.Expectations.Skip.Test("my message");

		await Expect.That(Act).Should().Throws<SkipTestException>();
	}
}
