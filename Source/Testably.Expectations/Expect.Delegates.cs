using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Sources;
using Testably.Expectations.Expectations;

namespace Testably.Expectations;

public static partial class Expect
{
	/// <summary>
	///     Start delegate assertions on the current <see cref="Action" /> <paramref name="delegate" />.
	/// </summary>
	public static DelegateExpectations.WithoutValue That(Action @delegate,
		[CallerArgumentExpression("delegate")] string doNotPopulateThisValue = "")
		=> new(
			new ExpectationBuilder<object>(new DelegateSource(@delegate), doNotPopulateThisValue));

	/// <summary>
	///     Start asserting the current <see cref="Func{Task}" /> <paramref name="delegate" />.
	/// </summary>
	public static DelegateExpectations.WithoutValue That(Func<Task> @delegate,
		[CallerArgumentExpression("delegate")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<object>(new DelegateAsyncSource(@delegate),
			doNotPopulateThisValue));

	/// <summary>
	///     Start asserting the current <see cref="Task" /> <paramref name="delegate" />.
	/// </summary>
	public static DelegateExpectations.WithoutValue That(Task @delegate,
		[CallerArgumentExpression("delegate")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<object>(new DelegateAsyncSource(() => @delegate),
			doNotPopulateThisValue));

	/// <summary>
	///     Start delegate assertions on the current <see cref="Func{TValue}" /> <paramref name="delegate" />.
	/// </summary>
	public static DelegateExpectations.WithValue<TValue> That<TValue>(Func<TValue> @delegate,
		[CallerArgumentExpression("delegate")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<TValue>(new DelegateValueSource<TValue>(@delegate),
			doNotPopulateThisValue));

	/// <summary>
	///     Start asserting the current <see cref="Func{T}" /> of <see cref="Task{TValue}" /> <paramref name="delegate" />.
	/// </summary>
	public static DelegateExpectations.WithValue<TValue> That<TValue>(Func<Task<TValue>> @delegate,
		[CallerArgumentExpression("delegate")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<TValue>(new DelegateAsyncValueSource<TValue>(@delegate),
			doNotPopulateThisValue));

	/// <summary>
	///     Start asserting the current <see cref="Task{TValue}" /> <paramref name="delegate" />.
	/// </summary>
	public static DelegateExpectations.WithValue<TValue> That<TValue>(Task<TValue> @delegate,
		[CallerArgumentExpression("delegate")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<TValue>(new DelegateAsyncValueSource<TValue>(() => @delegate),
			doNotPopulateThisValue));

#if NET6_0_OR_GREATER
	/// <summary>
	///     Start asserting the current <see cref="ValueTask" /> <paramref name="delegate" />.
	/// </summary>
	public static DelegateExpectations.WithoutValue That(ValueTask @delegate,
		[CallerArgumentExpression("delegate")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<object>(new DelegateAsyncSource(async () => await @delegate),
			doNotPopulateThisValue));

	/// <summary>
	///     Start asserting the current <see cref="ValueTask{TValue}" /> <paramref name="delegate" />.
	/// </summary>
	public static DelegateExpectations.WithValue<TValue> That<TValue>(ValueTask<TValue> @delegate,
		[CallerArgumentExpression("delegate")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<TValue>(
			new DelegateAsyncValueSource<TValue>(async () => await @delegate),
			doNotPopulateThisValue));
#endif
}
