using System.Runtime.CompilerServices;

namespace Testably.Expectations.Tests.ThatTests.Delegates;

public sealed partial class DelegateShould
{
	public sealed class Tests
	{
		[Fact]
		public async Task ShouldSupportDelegate_Action()
		{
			Action @delegate = () => { };

			async Task Act()
				=> await That(@delegate).Should().ThrowException();

			await That(Act).Should().ThrowException()
				.WithMessage("""
				             Expected @delegate to
				             throw an Exception,
				             but it did not
				             at Expect.That(@delegate).Should().ThrowException()
				             """);
		}

		[Fact]
		public async Task ShouldSupportDelegate_FuncTask()
		{
			Func<Task> @delegate = () => Task.CompletedTask;

			async Task Act()
				=> await That(@delegate).Should().ThrowException();

			await That(Act).Should().ThrowException()
				.WithMessage("""
				             Expected @delegate to
				             throw an Exception,
				             but it did not
				             at Expect.That(@delegate).Should().ThrowException()
				             """);
		}

		[Fact]
		public async Task ShouldSupportDelegate_FuncTaskValue()
		{
			Func<Task<int>> @delegate = () => Task.FromResult(1);

			async Task Act()
				=> await That(@delegate).Should().ThrowException();

			await That(Act).Should().ThrowException()
				.WithMessage("""
				             Expected @delegate to
				             throw an Exception,
				             but it did not
				             at Expect.That(@delegate).Should().ThrowException()
				             """);
		}

		[Fact]
		public async Task ShouldSupportDelegate_FuncValue()
		{
			Func<int> @delegate = () => 1;

			async Task Act()
				=> await That(@delegate).Should().ThrowException();

			await That(Act).Should().ThrowException()
				.WithMessage("""
				             Expected @delegate to
				             throw an Exception,
				             but it did not
				             at Expect.That(@delegate).Should().ThrowException()
				             """);
		}

		[Fact]
		public async Task ShouldSupportDelegate_Task()
		{
			Task @delegate = Task.CompletedTask;

			async Task Act()
				=> await That(@delegate).Should().ThrowException();

			await That(Act).Should().ThrowException()
				.WithMessage("""
				             Expected @delegate to
				             throw an Exception,
				             but it did not
				             at Expect.That(@delegate).Should().ThrowException()
				             """);
		}

		[Fact]
		public async Task ShouldSupportDelegate_TaskValue()
		{
			Task<int> @delegate = Task.FromResult(1);

			async Task Act()
				=> await That(@delegate).Should().ThrowException();

			await That(Act).Should().ThrowException()
				.WithMessage("""
				             Expected @delegate to
				             throw an Exception,
				             but it did not
				             at Expect.That(@delegate).Should().ThrowException()
				             """);
		}

#if NET6_0_OR_GREATER
		[Fact]
		public async Task ShouldSupportDelegate_ValueTask()
		{
			ValueTask @delegate = ValueTask.CompletedTask;

			async Task Act()
				=> await That(@delegate).Should().ThrowException();

			await That(Act).Should().ThrowException()
				.WithMessage("""
				             Expected @delegate to
				             throw an Exception,
				             but it did not
				             at Expect.That(@delegate).Should().ThrowException()
				             """);
		}
#endif

#if NET6_0_OR_GREATER
		[Fact]
		public async Task ShouldSupportDelegate_ValueTaskValue()
		{
			ValueTask<int> @delegate = ValueTask.FromResult(1);

			async Task Act()
				=> await That(@delegate).Should().ThrowException();

			await That(Act).Should().ThrowException()
				.WithMessage("""
				             Expected @delegate to
				             throw an Exception,
				             but it did not
				             at Expect.That(@delegate).Should().ThrowException()
				             """);
		}
#endif
	}

	public class CustomException(
		[CallerMemberName] string message = "",
		Exception? innerException = null)
		: Exception(message, innerException)
	{
		public string? Value { get; set; }
	}

	public class SubCustomException(
		[CallerMemberName] string message = "",
		Exception? innerException = null)
		: CustomException(message, innerException);

	public class OtherException(
		[CallerMemberName] string message = "",
		Exception? innerException = null)
		: Exception(message, innerException);
}
