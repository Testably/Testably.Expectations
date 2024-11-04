using Testably.Expectations.Extensions;
using Testably.Expectations.Internal.Tests.TestHelpers;

namespace Testably.Expectations.Internal.Tests.ThatTests;

public sealed class DelegateShould
{
	public sealed class ExecuteWithinTests
	{
		[Fact]
		public async Task WhenActionExecutedWithinTheTimeout_ShouldSucceed()
		{
			MockTimeSystem timeSystem = new();
			Action action = () => timeSystem.Thread.Sleep(10);

			async Task Act()
				=> await That(action).Should().ExecuteWithin(500.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenActionTookLongerThanTheTimeout_ShouldFail()
		{
			MockTimeSystem timeSystem = new();
			Action action = () => timeSystem.Thread.Sleep(300);

			async Task Act()
				=> await That(action).Should().ExecuteWithin(100.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().ThrowException()
				.WithMessage("""
				             Expected action to
				             execute within 0:00.100,
				             but it took 0:00.300
				             at Expect.That(action).Should().ExecuteWithin(100.Milliseconds())
				             """);
		}

		[Fact]
		public async Task WhenFuncTaskExecutedWithinTheTimeout_ShouldSucceed()
		{
			MockTimeSystem timeSystem = new();
			Func<Task> action = () => timeSystem.Task.Delay(10);

			async Task Act()
				=> await That(action).Should().ExecuteWithin(500.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenFuncTaskTookLongerThanTheTimeout_ShouldFail()
		{
			MockTimeSystem timeSystem = new();
			Func<Task> action = () => timeSystem.Task.Delay(300);

			async Task Act()
				=> await That(action).Should().ExecuteWithin(100.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().ThrowException()
				.WithMessage("""
				             Expected action to
				             execute within 0:00.100,
				             but it took 0:00.300
				             at Expect.That(action).Should().ExecuteWithin(100.Milliseconds())
				             """);
		}

		[Fact]
		public async Task WhenFuncTaskValueExecutedWithinTheTimeout_ShouldSucceed()
		{
			MockTimeSystem timeSystem = new();
			Func<Task<int>> action = async () =>
			{
				await timeSystem.Task.Delay(10);
				return 1;
			};

			async Task Act()
				=> await That(action).Should().ExecuteWithin(500.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenFuncTaskValueTookLongerThanTheTimeout_ShouldFail()
		{
			MockTimeSystem timeSystem = new();
			Func<Task<int>> action = async () =>
			{
				await timeSystem.Task.Delay(300);
				return 1;
			};

			async Task Act()
				=> await That(action).Should().ExecuteWithin(100.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().ThrowException()
				.WithMessage("""
				             Expected action to
				             execute within 0:00.100,
				             but it took 0:00.300
				             at Expect.That(action).Should().ExecuteWithin(100.Milliseconds())
				             """);
		}

		[Fact]
		public async Task WhenFuncValueExecutedWithinTheTimeout_ShouldSucceed()
		{
			MockTimeSystem timeSystem = new();
			Func<int> action = () =>
			{
				timeSystem.Thread.Sleep(10);
				return 1;
			};

			async Task Act()
				=> await That(action).Should().ExecuteWithin(500.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenFuncValueTookLongerThanTheTimeout_ShouldFail()
		{
			MockTimeSystem timeSystem = new();
			Func<int> action = () =>
			{
				timeSystem.Thread.Sleep(300);
				return 1;
			};

			async Task Act()
				=> await That(action).Should().ExecuteWithin(100.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().ThrowException()
				.WithMessage("""
				             Expected action to
				             execute within 0:00.100,
				             but it took 0:00.300
				             at Expect.That(action).Should().ExecuteWithin(100.Milliseconds())
				             """);
		}

		[Fact]
		public async Task WhenTaskExecutedWithinTheTimeout_ShouldSucceed()
		{
			MockTimeSystem timeSystem = new();
			Task action = timeSystem.Task.Delay(10);

			async Task Act()
				=> await That(action).Should().ExecuteWithin(500.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenTaskTookLongerThanTheTimeout_ShouldFail()
		{
			MockTimeSystem timeSystem = new();
			Task action = Task.Run(async () =>
			{
				await timeSystem.Task.Delay(300);
			});

			async Task Act()
				=> await That(action).Should().ExecuteWithin(100.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().ThrowException()
				.WithMessage("""
				             Expected action to
				             execute within 0:00.100,
				             but it took 0:00.300
				             at Expect.That(action).Should().ExecuteWithin(100.Milliseconds())
				             """);
		}

		[Fact]
		public async Task WhenTaskValueExecutedWithinTheTimeout_ShouldSucceed()
		{
			MockTimeSystem timeSystem = new();
			Task<int> action = Task.Run(async () =>
			{
				await timeSystem.Task.Delay(10);
				return 1;
			});

			async Task Act()
				=> await That(action).Should().ExecuteWithin(500.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenTaskValueTookLongerThanTheTimeout_ShouldFail()
		{
			MockTimeSystem timeSystem = new();
			Task<int> action = Task.Run(async () =>
			{
				await timeSystem.Task.Delay(300);
				return 1;
			});

			async Task Act()
				=> await That(action).Should().ExecuteWithin(100.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().ThrowException()
				.WithMessage("""
				             Expected action to
				             execute within 0:00.100,
				             but it took 0:00.300
				             at Expect.That(action).Should().ExecuteWithin(100.Milliseconds())
				             """);
		}
#if NET6_0_OR_GREATER
		[Fact]
		public async Task WhenValueTaskExecutedWithinTheTimeout_ShouldSucceed()
		{
			MockTimeSystem timeSystem = new();
			ValueTask action = new(timeSystem.Task.Delay(10));

			async Task Act()
				=> await That(action).Should().ExecuteWithin(500.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().NotThrow();
		}
#endif

#if NET6_0_OR_GREATER
		[Fact]
		public async Task WhenValueTaskTookLongerThanTheTimeout_ShouldFail()
		{
			MockTimeSystem timeSystem = new();
			ValueTask action = new(timeSystem.Task.Delay(300));

			async Task Act()
				=> await That(action).Should().ExecuteWithin(100.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().ThrowException()
				.WithMessage("""
				             Expected action to
				             execute within 0:00.100,
				             but it took 0:00.300
				             at Expect.That(action).Should().ExecuteWithin(100.Milliseconds())
				             """);
		}
#endif

#if NET6_0_OR_GREATER
		[Fact]
		public async Task WhenValueTaskValueExecutedWithinTheTimeout_ShouldSucceed()
		{
			MockTimeSystem timeSystem = new();
			ValueTask<int> action = new(Task.Run(async () =>
			{
				await timeSystem.Task.Delay(10);
				return 1;
			}));

			async Task Act()
				=> await That(action).Should().ExecuteWithin(500.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().NotThrow();
		}
#endif

#if NET6_0_OR_GREATER
		[Fact]
		public async Task WhenValueTaskValueTookLongerThanTheTimeout_ShouldFail()
		{
			MockTimeSystem timeSystem = new();
			ValueTask<int> action = new(Task.Run(async () =>
			{
				await timeSystem.Task.Delay(300);
				return 1;
			}));

			async Task Act()
				=> await That(action).Should().ExecuteWithin(100.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().ThrowException()
				.WithMessage("""
				             Expected action to
				             execute within 0:00.100,
				             but it took 0:00.300
				             at Expect.That(action).Should().ExecuteWithin(100.Milliseconds())
				             """);
		}
#endif
	}

	public sealed class NotExecuteWithinTests
	{
		[Fact]
		public async Task WhenActionExecutedWithinThanTheTimeout_ShouldFail()
		{
			MockTimeSystem timeSystem = new();
			Action action = () => timeSystem.Thread.Sleep(10);

			async Task Act()
				=> await That(action).Should().NotExecuteWithin(500.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().ThrowException()
				.WithMessage("""
				             Expected action to
				             not execute within 0:00.500,
				             but it took only 0:00.010
				             at Expect.That(action).Should().NotExecuteWithin(500.Milliseconds())
				             """);
		}

		[Fact]
		public async Task WhenActionTookLongerTheTimeout_ShouldSucceed()
		{
			MockTimeSystem timeSystem = new();
			Action action = () => timeSystem.Thread.Sleep(300);

			async Task Act()
				=> await That(action).Should().NotExecuteWithin(100.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().NotThrow();
		}
	}
}
