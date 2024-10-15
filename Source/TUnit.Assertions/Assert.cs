using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TUnit.Assertions.Assertions.Delegates;
using TUnit.Assertions.Assertions.Strings;
using TUnit.Assertions.Core.Internal;

namespace TUnit.Assertions;

/// <summary>
///     The starting point for checking expectations.
/// </summary>
[StackTraceHidden]
public static class Assert
{
	public static DelegateAssertions.WithoutValue That(Action subject, [CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		return new DelegateAssertions.WithoutValue(
			AssertionBuilder.FromSubject(doNotPopulateThisValue),
			() => Task.Run(subject));
	}

	public static DelegateAssertions.WithValue<TActual> That<TActual>(Func<TActual> subject, [CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		return new DelegateAssertions.WithValue<TActual>(
			AssertionBuilder.FromSubject(doNotPopulateThisValue),
			() => Task.Run(subject));
	}

	public static DelegateAssertions.WithoutValue That(Task subject, [CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		return new DelegateAssertions.WithoutValue(
			AssertionBuilder.FromSubject(doNotPopulateThisValue),
			() => subject);
	}

	public static DelegateAssertions.WithValue<TActual> That<TActual>(Task<TActual> subject, [CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		return new DelegateAssertions.WithValue<TActual>(
			AssertionBuilder.FromSubject(doNotPopulateThisValue),
			() => subject);
	}

	public static DelegateAssertions.WithoutValue That(Func<Task> subject, [CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		return new DelegateAssertions.WithoutValue(
			AssertionBuilder.FromSubject(doNotPopulateThisValue),
			subject);
	}

	public static DelegateAssertions.WithValue<TActual> That<TActual>(Func<Task<TActual>> subject, [CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		return new DelegateAssertions.WithValue<TActual>(
			AssertionBuilder.FromSubject(doNotPopulateThisValue),
			subject);
	}

	//public static AsyncDelegateAssertionBuilder That(ValueTask value, [CallerArgumentExpression("value")] string doNotPopulateThisValue = "")
	//{
	//	return new AsyncDelegateAssertionBuilder(async () => await value, doNotPopulateThisValue);
	//}

	//public static AsyncValueDelegateAssertionBuilder<TActual> That<TActual>(ValueTask<TActual> value, [CallerArgumentExpression("value")] string doNotPopulateThisValue = "")
	//{
	//	return new AsyncValueDelegateAssertionBuilder<TActual>(async () => await value, doNotPopulateThisValue);
	//}

	public static StringAssertions That(string? subject, [CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		return new StringAssertions(
			AssertionBuilder.FromSubject(doNotPopulateThisValue),
			subject);
	}
}
