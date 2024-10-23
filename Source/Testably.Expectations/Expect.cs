using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Core.Sources;

namespace Testably.Expectations;
public static class Expect
{
	public static IExpectThat<T> That<T>(T? subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		return new ExpectThat<T>(new ExpectationBuilder<T?>(subject, doNotPopulateThisValue));
	}
	public static IExpectThat<TCollection> That<TItem, TCollection>(TCollection subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	where TCollection : IEnumerable<TItem>
	{
		if (typeof(TCollection) == typeof(IEnumerable<TItem>))
		{
			subject = (TCollection)MaterializingEnumerable<TItem>.Wrap(subject);
		}
		return new ExpectThat<TCollection>(new ExpectationBuilder<TCollection>(subject, doNotPopulateThisValue));
	}
	public static IExpectThat<object?> That(object? subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		return new ExpectThat<object?>(new ExpectationBuilder<object?>(subject, doNotPopulateThisValue));
	}

	/// <summary>
	///     Start expectations for the current <see cref="Action" /> <paramref name="delegate" />.
	/// </summary>
	public static IExpectThat<ThatDelegate.WithoutValue> That(Action @delegate,
		[CallerArgumentExpression("delegate")] string doNotPopulateThisValue = "")
	{
		return new ExpectThat<ThatDelegate.WithoutValue>(new ExpectationBuilder<DelegateSource.NoValue>(new DelegateSource(@delegate),
			doNotPopulateThisValue));
	}

	/// <summary>
	///     Start expectations for the current <see cref="Func{Task}" /> <paramref name="delegate" />.
	/// </summary>
	public static IExpectThat<ThatDelegate.WithoutValue> That(Func<Task> @delegate,
		[CallerArgumentExpression("delegate")] string doNotPopulateThisValue = "")
		=> new ExpectThat<ThatDelegate.WithoutValue>(new ExpectationBuilder<DelegateSource.NoValue>(new DelegateAsyncSource(@delegate),
			doNotPopulateThisValue));

	/// <summary>
	///     Start expectations for the current <see cref="Task" /> <paramref name="delegate" />.
	/// </summary>
	public static IExpectThat<ThatDelegate.WithoutValue> That(Task @delegate,
		[CallerArgumentExpression("delegate")] string doNotPopulateThisValue = "")
		=> new ExpectThat<ThatDelegate.WithoutValue>(new ExpectationBuilder<DelegateSource.NoValue>(
			new DelegateAsyncSource(() => @delegate),
			doNotPopulateThisValue));

#if NET6_0_OR_GREATER
	/// <summary>
	///     Start expectations for the current <see cref="ValueTask" /> <paramref name="delegate" />.
	/// </summary>
	public static IExpectThat<ThatDelegate.WithoutValue> That(ValueTask @delegate,
		[CallerArgumentExpression("delegate")] string doNotPopulateThisValue = "")
		=> new ExpectThat<ThatDelegate.WithoutValue>(new ExpectationBuilder<DelegateSource.NoValue>(new DelegateAsyncSource(async () => await @delegate),
			doNotPopulateThisValue));
#endif

	/// <summary>
	///     Start expectations for the current <see cref="Func{TValue}" /> <paramref name="delegate" />.
	/// </summary>
	public static IExpectThat<ThatDelegate.WithValue<TValue>> That<TValue>(Func<TValue> @delegate,
		[CallerArgumentExpression("delegate")] string doNotPopulateThisValue = "")
		=> new ExpectThat<ThatDelegate.WithValue<TValue>>(new ExpectationBuilder<TValue>(new DelegateValueSource<TValue>(@delegate),
			doNotPopulateThisValue));

	/// <summary>
	///     Start expectations for the current <see cref="Func{T}" /> of <see cref="Task{TValue}" /> <paramref name="delegate" />.
	/// </summary>
	public static IExpectThat<ThatDelegate.WithValue<TValue>> That<TValue>(Func<Task<TValue>> @delegate,
		[CallerArgumentExpression("delegate")] string doNotPopulateThisValue = "")
		=> new ExpectThat<ThatDelegate.WithValue<TValue>>(new ExpectationBuilder<TValue>(new DelegateAsyncValueSource<TValue>(@delegate),
			doNotPopulateThisValue));

	/// <summary>
	///     Start expectations for the current <see cref="Task{TValue}" /> <paramref name="delegate" />.
	/// </summary>
	public static IExpectThat<ThatDelegate.WithValue<TValue>> That<TValue>(Task<TValue> @delegate,
		[CallerArgumentExpression("delegate")] string doNotPopulateThisValue = "")
		=> new ExpectThat<ThatDelegate.WithValue<TValue>>(new ExpectationBuilder<TValue>(new DelegateAsyncValueSource<TValue>(() => @delegate),
			doNotPopulateThisValue));

#if NET6_0_OR_GREATER
	/// <summary>
	///     Start expectations for the current <see cref="ValueTask{TValue}" /> <paramref name="delegate" />.
	/// </summary>
	public static IExpectThat<ThatDelegate.WithValue<TValue>> That<TValue>(ValueTask<TValue> @delegate,
		[CallerArgumentExpression("delegate")] string doNotPopulateThisValue = "")
		=> new ExpectThat<ThatDelegate.WithValue<TValue>>(new ExpectationBuilder<TValue>(
			new DelegateAsyncValueSource<TValue>(async () => await @delegate),
			doNotPopulateThisValue));
#endif
}

public interface IExpectThat<out T>
{
	public IExpectationBuilder ExpectationBuilder { get; }
}

public class ExpectThat<T> : IExpectThat<T>
{
	public IExpectationBuilder ExpectationBuilder { get; }

	public ExpectThat(IExpectationBuilder expectationBuilder)
	{
		ExpectationBuilder = expectationBuilder;
	}
}
