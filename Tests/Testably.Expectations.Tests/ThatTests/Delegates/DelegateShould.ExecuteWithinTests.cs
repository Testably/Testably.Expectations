using System.Threading;
using Testably.Expectations.Extensions;

namespace Testably.Expectations.Tests.ThatTests.Delegates;

public sealed partial class DelegateShould
{
	public sealed class ExecuteWithinTests
	{
		[Fact]
		public async Task WhenActionExecutedWithinTheTimeout_ShouldSucceed()
		{
			Action action = () => Thread.Sleep(10);

			async Task Act()
				=> await That(action).Should().ExecuteWithin(500.Milliseconds());

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenActionTookLongerThanTheTimeout_ShouldFail()
		{
			Action action = () => Thread.Sleep(300);

			async Task Act()
				=> await That(action).Should().ExecuteWithin(100.Milliseconds());

			await That(Act).Should().ThrowException()
				.WithMessage("""
				             Expected action to
				             execute within 0:00.100,
				             but it took 0:00.3??
				             at Expect.That(action).Should().ExecuteWithin(100.Milliseconds())
				             """).AsWildcard();
		}
	}

	public sealed class NotExecuteWithinTests
	{
		[Fact]
		public async Task WhenActionExecutedWithinThanTheTimeout_ShouldFail()
		{
			Action action = () => Thread.Sleep(10);

			async Task Act()
				=> await That(action).Should().NotExecuteWithin(500.Milliseconds());

			await That(Act).Should().ThrowException()
				.WithMessage("""
				             Expected action to
				             not execute within 0:00.500,
				             but it took only 0:00.???
				             at Expect.That(action).Should().NotExecuteWithin(500.Milliseconds())
				             """).AsWildcard();
		}

		[Fact]
		public async Task WhenActionTookLongerTheTimeout_ShouldSucceed()
		{
			Action action = () => Thread.Sleep(300);

			async Task Act()
				=> await That(action).Should().NotExecuteWithin(100.Milliseconds());

			await That(Act).Should().NotThrow();
		}
	}
}
