using Testably.Expectations.Core.TimeSystem;
using Testably.Expectations.Extensions;
using Testably.Expectations.Internal.Tests.TestHelpers;

namespace Testably.Expectations.Internal.Tests.ThatTests.Delegates;

public sealed class DelegateShould
{
	public sealed class ExecuteWithinTests
	{
		[Fact]
		public async Task WhenActionExecutedWithinTheTimeout_ShouldSucceed()
		{
			MockTimeSystem timeSystem = new();
			IStopwatch stopwatch = timeSystem.Stopwatch.New();
			Action @delegate = () => timeSystem.Thread.Sleep(10);

			async Task Act()
				=> await That(@delegate).Should().ExecuteWithin(500.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().NotThrow();
			await That(stopwatch.IsRunning).Should().BeFalse();
		}

		[Fact]
		public async Task WhenActionTookLongerThanTheTimeout_ShouldFail()
		{
			MockTimeSystem timeSystem = new();
			IStopwatch stopwatch = timeSystem.Stopwatch.New();
			Action @delegate = () => timeSystem.Thread.Sleep(300);

			async Task Act()
				=> await That(@delegate).Should().ExecuteWithin(100.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().ThrowException()
				.WithMessage("""
				             Expected @delegate to
				             execute within 0:00.100,
				             but it took 0:00.300
				             at Expect.That(@delegate).Should().ExecuteWithin(100.Milliseconds())
				             """);
			await That(stopwatch.IsRunning).Should().BeFalse();
		}

		[Fact]
		public async Task WhenFuncTaskExecutedWithinTheTimeout_ShouldSucceed()
		{
			MockTimeSystem timeSystem = new();
			IStopwatch stopwatch = timeSystem.Stopwatch.New();
			Func<Task> @delegate = () => timeSystem.Task.Delay(10);

			async Task Act()
				=> await That(@delegate).Should().ExecuteWithin(500.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().NotThrow();
			await That(stopwatch.IsRunning).Should().BeFalse();
		}

		[Fact]
		public async Task WhenFuncTaskTookLongerThanTheTimeout_ShouldFail()
		{
			MockTimeSystem timeSystem = new();
			IStopwatch stopwatch = timeSystem.Stopwatch.New();
			Func<Task> @delegate = () => timeSystem.Task.Delay(300);

			async Task Act()
				=> await That(@delegate).Should().ExecuteWithin(100.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().ThrowException()
				.WithMessage("""
				             Expected @delegate to
				             execute within 0:00.100,
				             but it took 0:00.300
				             at Expect.That(@delegate).Should().ExecuteWithin(100.Milliseconds())
				             """);
			await That(stopwatch.IsRunning).Should().BeFalse();
		}

		[Fact]
		public async Task WhenFuncTaskValueExecutedWithinTheTimeout_ShouldSucceed()
		{
			MockTimeSystem timeSystem = new();
			IStopwatch stopwatch = timeSystem.Stopwatch.New();
			Func<Task<int>> @delegate = async () =>
			{
				await timeSystem.Task.Delay(10);
				return 1;
			};

			async Task Act()
				=> await That(@delegate).Should().ExecuteWithin(500.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().NotThrow();
			await That(stopwatch.IsRunning).Should().BeFalse();
		}

		[Fact]
		public async Task WhenFuncTaskValueTookLongerThanTheTimeout_ShouldFail()
		{
			MockTimeSystem timeSystem = new();
			IStopwatch stopwatch = timeSystem.Stopwatch.New();
			Func<Task<int>> @delegate = async () =>
			{
				await timeSystem.Task.Delay(300);
				return 1;
			};

			async Task Act()
				=> await That(@delegate).Should().ExecuteWithin(100.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().ThrowException()
				.WithMessage("""
				             Expected @delegate to
				             execute within 0:00.100,
				             but it took 0:00.300
				             at Expect.That(@delegate).Should().ExecuteWithin(100.Milliseconds())
				             """);
			await That(stopwatch.IsRunning).Should().BeFalse();
		}

		[Fact]
		public async Task WhenFuncValueExecutedWithinTheTimeout_ShouldSucceed()
		{
			MockTimeSystem timeSystem = new();
			IStopwatch stopwatch = timeSystem.Stopwatch.New();
			Func<int> @delegate = () =>
			{
				timeSystem.Thread.Sleep(10);
				return 1;
			};

			async Task Act()
				=> await That(@delegate).Should().ExecuteWithin(500.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().NotThrow();
			await That(stopwatch.IsRunning).Should().BeFalse();
		}

		[Fact]
		public async Task WhenFuncValueTookLongerThanTheTimeout_ShouldFail()
		{
			MockTimeSystem timeSystem = new();
			IStopwatch stopwatch = timeSystem.Stopwatch.New();
			Func<int> @delegate = () =>
			{
				timeSystem.Thread.Sleep(300);
				return 1;
			};

			async Task Act()
				=> await That(@delegate).Should().ExecuteWithin(100.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().ThrowException()
				.WithMessage("""
				             Expected @delegate to
				             execute within 0:00.100,
				             but it took 0:00.300
				             at Expect.That(@delegate).Should().ExecuteWithin(100.Milliseconds())
				             """);
			await That(stopwatch.IsRunning).Should().BeFalse();
		}

		[Fact]
		public async Task WhenTaskExecutedWithinTheTimeout_ShouldSucceed()
		{
			MockTimeSystem timeSystem = new();
			// The Task already runs before it is invoked
			IStopwatch stopwatch = timeSystem.Stopwatch.New();
			stopwatch.Start();
			Task @delegate = timeSystem.Task.Delay(10);

			async Task Act()
				=> await That(@delegate).Should().ExecuteWithin(500.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().NotThrow();
			await That(stopwatch.IsRunning).Should().BeFalse();
		}

		[Fact]
		public async Task WhenTaskTookLongerThanTheTimeout_ShouldFail()
		{
			MockTimeSystem timeSystem = new();
			// The Task already runs before it is invoked
			IStopwatch stopwatch = timeSystem.Stopwatch.New();
			stopwatch.Start();
			Task @delegate = Task.Run(async () =>
			{
				await timeSystem.Task.Delay(300);
			});

			async Task Act()
				=> await That(@delegate).Should().ExecuteWithin(100.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().ThrowException()
				.WithMessage("""
				             Expected @delegate to
				             execute within 0:00.100,
				             but it took 0:00.300
				             at Expect.That(@delegate).Should().ExecuteWithin(100.Milliseconds())
				             """);
			await That(stopwatch.IsRunning).Should().BeFalse();
		}

		[Fact]
		public async Task WhenTaskValueExecutedWithinTheTimeout_ShouldSucceed()
		{
			MockTimeSystem timeSystem = new();
			// The Task already runs before it is invoked
			IStopwatch stopwatch = timeSystem.Stopwatch.New();
			stopwatch.Start();
			Task<int> @delegate = Task.Run(async () =>
			{
				await timeSystem.Task.Delay(10);
				return 1;
			});

			async Task Act()
				=> await That(@delegate).Should().ExecuteWithin(500.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().NotThrow();
			await That(stopwatch.IsRunning).Should().BeFalse();
		}

		[Fact]
		public async Task WhenTaskValueTookLongerThanTheTimeout_ShouldFail()
		{
			MockTimeSystem timeSystem = new();
			// The Task already runs before it is invoked
			IStopwatch stopwatch = timeSystem.Stopwatch.New();
			stopwatch.Start();
			Task<int> @delegate = Task.Run(async () =>
			{
				await timeSystem.Task.Delay(300);
				return 1;
			});

			async Task Act()
				=> await That(@delegate).Should().ExecuteWithin(100.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().ThrowException()
				.WithMessage("""
				             Expected @delegate to
				             execute within 0:00.100,
				             but it took 0:00.300
				             at Expect.That(@delegate).Should().ExecuteWithin(100.Milliseconds())
				             """);
			await That(stopwatch.IsRunning).Should().BeFalse();
		}
#if NET6_0_OR_GREATER
		[Fact]
		public async Task WhenValueTaskExecutedWithinTheTimeout_ShouldSucceed()
		{
			MockTimeSystem timeSystem = new();
			// The ValueTask already runs before it is invoked
			IStopwatch stopwatch = timeSystem.Stopwatch.New();
			stopwatch.Start();
			ValueTask @delegate = new(timeSystem.Task.Delay(10));

			async Task Act()
				=> await That(@delegate).Should().ExecuteWithin(500.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().NotThrow();
			await That(stopwatch.IsRunning).Should().BeFalse();
		}
#endif

#if NET6_0_OR_GREATER
		[Fact]
		public async Task WhenValueTaskTookLongerThanTheTimeout_ShouldFail()
		{
			MockTimeSystem timeSystem = new();
			// The ValueTask already runs before it is invoked
			IStopwatch stopwatch = timeSystem.Stopwatch.New();
			stopwatch.Start();
			ValueTask @delegate = new(timeSystem.Task.Delay(300));

			async Task Act()
				=> await That(@delegate).Should().ExecuteWithin(100.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().ThrowException()
				.WithMessage("""
				             Expected @delegate to
				             execute within 0:00.100,
				             but it took 0:00.300
				             at Expect.That(@delegate).Should().ExecuteWithin(100.Milliseconds())
				             """);
			await That(stopwatch.IsRunning).Should().BeFalse();
		}
#endif

#if NET6_0_OR_GREATER
		[Fact]
		public async Task WhenValueTaskValueExecutedWithinTheTimeout_ShouldSucceed()
		{
			MockTimeSystem timeSystem = new();
			// The ValueTask already runs before it is invoked
			IStopwatch stopwatch = timeSystem.Stopwatch.New();
			stopwatch.Start();
			ValueTask<int> @delegate = new(Task.Run(async () =>
			{
				await timeSystem.Task.Delay(10);
				return 1;
			}));

			async Task Act()
				=> await That(@delegate).Should().ExecuteWithin(500.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().NotThrow();
			await That(stopwatch.IsRunning).Should().BeFalse();
		}
#endif

#if NET6_0_OR_GREATER
		[Fact]
		public async Task WhenValueTaskValueTookLongerThanTheTimeout_ShouldFail()
		{
			MockTimeSystem timeSystem = new();
			// The ValueTask already runs before it is invoked
			IStopwatch stopwatch = timeSystem.Stopwatch.New();
			stopwatch.Start();
			ValueTask<int> @delegate = new(Task.Run(async () =>
			{
				await timeSystem.Task.Delay(300);
				return 1;
			}));

			async Task Act()
				=> await That(@delegate).Should().ExecuteWithin(100.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().ThrowException()
				.WithMessage("""
				             Expected @delegate to
				             execute within 0:00.100,
				             but it took 0:00.300
				             at Expect.That(@delegate).Should().ExecuteWithin(100.Milliseconds())
				             """);
			await That(stopwatch.IsRunning).Should().BeFalse();
		}
#endif
	}

	public sealed class NotExecuteWithinTests
	{
		[Fact]
		public async Task WhenActionExecutedWithinThanTheTimeout_ShouldFail()
		{
			MockTimeSystem timeSystem = new();
			IStopwatch stopwatch = timeSystem.Stopwatch.New();
			Action @delegate = () => timeSystem.Thread.Sleep(10);

			async Task Act()
				=> await That(@delegate).Should().NotExecuteWithin(500.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().ThrowException()
				.WithMessage("""
				             Expected @delegate to
				             not execute within 0:00.500,
				             but it took only 0:00.010
				             at Expect.That(@delegate).Should().NotExecuteWithin(500.Milliseconds())
				             """);
			await That(stopwatch.IsRunning).Should().BeFalse();
		}

		[Fact]
		public async Task WhenActionTookLongerTheTimeout_ShouldSucceed()
		{
			MockTimeSystem timeSystem = new();
			IStopwatch stopwatch = timeSystem.Stopwatch.New();
			Action @delegate = () => timeSystem.Thread.Sleep(300);

			async Task Act()
				=> await That(@delegate).Should().NotExecuteWithin(100.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().NotThrow();
			await That(stopwatch.IsRunning).Should().BeFalse();
		}

		[Fact]
		public async Task WhenFuncTaskExecutedWithinThanTheTimeout_ShouldFail()
		{
			MockTimeSystem timeSystem = new();
			IStopwatch stopwatch = timeSystem.Stopwatch.New();
			Func<Task> @delegate = () => timeSystem.Task.Delay(10);

			async Task Act()
				=> await That(@delegate).Should().NotExecuteWithin(500.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().ThrowException()
				.WithMessage("""
				             Expected @delegate to
				             not execute within 0:00.500,
				             but it took only 0:00.010
				             at Expect.That(@delegate).Should().NotExecuteWithin(500.Milliseconds())
				             """);
			await That(stopwatch.IsRunning).Should().BeFalse();
		}

		[Fact]
		public async Task WhenFuncTaskTookLongerTheTimeout_ShouldSucceed()
		{
			MockTimeSystem timeSystem = new();
			IStopwatch stopwatch = timeSystem.Stopwatch.New();
			Func<Task> @delegate = () => timeSystem.Task.Delay(300);

			async Task Act()
				=> await That(@delegate).Should().NotExecuteWithin(100.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().NotThrow();
			await That(stopwatch.IsRunning).Should().BeFalse();
		}

		[Fact]
		public async Task WhenFuncTaskValueExecutedWithinThanTheTimeout_ShouldFail()
		{
			MockTimeSystem timeSystem = new();
			IStopwatch stopwatch = timeSystem.Stopwatch.New();
			Func<Task<int>> @delegate = async () =>
			{
				await timeSystem.Task.Delay(10);
				return 1;
			};

			async Task Act()
				=> await That(@delegate).Should().NotExecuteWithin(500.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().ThrowException()
				.WithMessage("""
				             Expected @delegate to
				             not execute within 0:00.500,
				             but it took only 0:00.010
				             at Expect.That(@delegate).Should().NotExecuteWithin(500.Milliseconds())
				             """);
			await That(stopwatch.IsRunning).Should().BeFalse();
		}

		[Fact]
		public async Task WhenFuncTaskValueTookLongerTheTimeout_ShouldSucceed()
		{
			MockTimeSystem timeSystem = new();
			IStopwatch stopwatch = timeSystem.Stopwatch.New();
			Func<Task<int>> @delegate = async () =>
			{
				await timeSystem.Task.Delay(300);
				return 1;
			};

			async Task Act()
				=> await That(@delegate).Should().NotExecuteWithin(100.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().NotThrow();
			await That(stopwatch.IsRunning).Should().BeFalse();
		}

		[Fact]
		public async Task WhenFuncValueExecutedWithinThanTheTimeout_ShouldFail()
		{
			MockTimeSystem timeSystem = new();
			IStopwatch stopwatch = timeSystem.Stopwatch.New();
			Func<int> @delegate = () =>
			{
				timeSystem.Thread.Sleep(10);
				return 1;
			};

			async Task Act()
				=> await That(@delegate).Should().NotExecuteWithin(500.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().ThrowException()
				.WithMessage("""
				             Expected @delegate to
				             not execute within 0:00.500,
				             but it took only 0:00.010
				             at Expect.That(@delegate).Should().NotExecuteWithin(500.Milliseconds())
				             """);
			await That(stopwatch.IsRunning).Should().BeFalse();
		}

		[Fact]
		public async Task WhenFuncValueTookLongerTheTimeout_ShouldSucceed()
		{
			MockTimeSystem timeSystem = new();
			IStopwatch stopwatch = timeSystem.Stopwatch.New();
			Func<int> @delegate = () =>
			{
				timeSystem.Thread.Sleep(300);
				return 1;
			};

			async Task Act()
				=> await That(@delegate).Should().NotExecuteWithin(100.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().NotThrow();
			await That(stopwatch.IsRunning).Should().BeFalse();
		}

		[Fact]
		public async Task WhenTaskExecutedWithinThanTheTimeout_ShouldFail()
		{
			MockTimeSystem timeSystem = new();
			// The Task already runs before it is invoked
			IStopwatch stopwatch = timeSystem.Stopwatch.New();
			stopwatch.Start();
			Task @delegate = timeSystem.Task.Delay(10);

			async Task Act()
				=> await That(@delegate).Should().NotExecuteWithin(500.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().ThrowException()
				.WithMessage("""
				             Expected @delegate to
				             not execute within 0:00.500,
				             but it took only 0:00.010
				             at Expect.That(@delegate).Should().NotExecuteWithin(500.Milliseconds())
				             """);
			await That(stopwatch.IsRunning).Should().BeFalse();
		}

		[Fact]
		public async Task WhenTaskTookLongerTheTimeout_ShouldSucceed()
		{
			MockTimeSystem timeSystem = new();
			// The Task already runs before it is invoked
			IStopwatch stopwatch = timeSystem.Stopwatch.New();
			stopwatch.Start();
			Task @delegate = timeSystem.Task.Delay(300);

			async Task Act()
				=> await That(@delegate).Should().NotExecuteWithin(100.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().NotThrow();
			await That(stopwatch.IsRunning).Should().BeFalse();
		}

		[Fact]
		public async Task WhenTaskValueExecutedWithinThanTheTimeout_ShouldFail()
		{
			MockTimeSystem timeSystem = new();
			// The Task already runs before it is invoked
			IStopwatch stopwatch = timeSystem.Stopwatch.New();
			stopwatch.Start();
			Task<int> @delegate = Task.Run(async () =>
			{
				await timeSystem.Task.Delay(10);
				return 1;
			});

			async Task Act()
				=> await That(@delegate).Should().NotExecuteWithin(500.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().ThrowException()
				.WithMessage("""
				             Expected @delegate to
				             not execute within 0:00.500,
				             but it took only 0:00.010
				             at Expect.That(@delegate).Should().NotExecuteWithin(500.Milliseconds())
				             """);
			await That(stopwatch.IsRunning).Should().BeFalse();
		}

		[Fact]
		public async Task WhenTaskValueTookLongerTheTimeout_ShouldSucceed()
		{
			MockTimeSystem timeSystem = new();
			// The Task already runs before it is invoked
			IStopwatch stopwatch = timeSystem.Stopwatch.New();
			stopwatch.Start();
			Task<int> @delegate = Task.Run(async () =>
			{
				await timeSystem.Task.Delay(300);
				return 1;
			});

			async Task Act()
				=> await That(@delegate).Should().NotExecuteWithin(100.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().NotThrow();
			await That(stopwatch.IsRunning).Should().BeFalse();
		}

#if NET6_0_OR_GREATER
		[Fact]
		public async Task WhenValueTaskExecutedWithinThanTheTimeout_ShouldFail()
		{
			MockTimeSystem timeSystem = new();
			// The ValueTask already runs before it is invoked
			IStopwatch stopwatch = timeSystem.Stopwatch.New();
			stopwatch.Start();
			ValueTask @delegate = new(timeSystem.Task.Delay(10));

			async Task Act()
				=> await That(@delegate).Should().NotExecuteWithin(500.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().ThrowException()
				.WithMessage("""
				             Expected @delegate to
				             not execute within 0:00.500,
				             but it took only 0:00.010
				             at Expect.That(@delegate).Should().NotExecuteWithin(500.Milliseconds())
				             """);
			await That(stopwatch.IsRunning).Should().BeFalse();
		}
#endif

#if NET6_0_OR_GREATER
		[Fact]
		public async Task WhenValueTaskTookLongerTheTimeout_ShouldSucceed()
		{
			MockTimeSystem timeSystem = new();
			// The ValueTask already runs before it is invoked
			IStopwatch stopwatch = timeSystem.Stopwatch.New();
			stopwatch.Start();
			ValueTask @delegate = new(timeSystem.Task.Delay(300));

			async Task Act()
				=> await That(@delegate).Should().NotExecuteWithin(100.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().NotThrow();
			await That(stopwatch.IsRunning).Should().BeFalse();
		}
#endif

#if NET6_0_OR_GREATER
		[Fact]
		public async Task WhenValueTaskValueExecutedWithinThanTheTimeout_ShouldFail()
		{
			MockTimeSystem timeSystem = new();
			// The ValueTask already runs before it is invoked
			IStopwatch stopwatch = timeSystem.Stopwatch.New();
			stopwatch.Start();
			ValueTask<int> @delegate = new(Task.Run(async () =>
			{
				await timeSystem.Task.Delay(10);
				return 1;
			}));

			async Task Act()
				=> await That(@delegate).Should().NotExecuteWithin(500.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().ThrowException()
				.WithMessage("""
				             Expected @delegate to
				             not execute within 0:00.500,
				             but it took only 0:00.010
				             at Expect.That(@delegate).Should().NotExecuteWithin(500.Milliseconds())
				             """);
			await That(stopwatch.IsRunning).Should().BeFalse();
		}
#endif

#if NET6_0_OR_GREATER
		[Fact]
		public async Task WhenValueTaskValueTookLongerTheTimeout_ShouldSucceed()
		{
			MockTimeSystem timeSystem = new();
			// The ValueTask already runs before it is invoked
			IStopwatch stopwatch = timeSystem.Stopwatch.New();
			stopwatch.Start();
			ValueTask<int> @delegate = new(Task.Run(async () =>
			{
				await timeSystem.Task.Delay(300);
				return 1;
			}));

			async Task Act()
				=> await That(@delegate).Should().NotExecuteWithin(100.Milliseconds())
					.UseTimeSystem(timeSystem);

			await That(Act).Should().NotThrow();
			await That(stopwatch.IsRunning).Should().BeFalse();
		}
#endif
	}
}
