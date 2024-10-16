using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Sources;
using Testably.Expectations.Expectations;

namespace Testably.Expectations;

/// <summary>
///     The starting point for checking expectations.
/// </summary>
[StackTraceHidden]
public static class Expect
{
	public static DelegateExpectations.WithoutValue That(Action subject, [CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		return new(new ExpectationBuilder<object>(new DelegateSource(subject), doNotPopulateThisValue));
	}
	public static DelegateExpectations.WithValue<TActual> That<TActual>(Func<TActual> subject, [CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		return new(new ExpectationBuilder<TActual>(new DelegateValueSource<TActual>(subject), doNotPopulateThisValue));
	}


	//public static DelegateExpectations.WithValue<TActual> That<TActual>(Func<TActual> subject, [CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	//{
	//	return new DelegateExpectations.WithValue<TActual>(
	//		AssertionBuilder.FromSubject(doNotPopulateThisValue),
	//		() => Task.Run(subject));
	//}

	//public static DelegateExpectations.WithoutValue That(Task subject, [CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	//{
	//	return new DelegateExpectations.WithoutValue(
	//		AssertionBuilder.FromSubject(doNotPopulateThisValue),
	//		() => subject);
	//}

	//public static DelegateExpectations.WithValue<TActual> That<TActual>(Task<TActual> subject, [CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	//{
	//	return new DelegateExpectations.WithValue<TActual>(
	//		AssertionBuilder.FromSubject(doNotPopulateThisValue),
	//		() => subject);
	//}

	//public static DelegateExpectations.WithoutValue That(Func<Task> subject, [CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	//{
	//	return new DelegateExpectations.WithoutValue(
	//		AssertionBuilder.FromSubject(doNotPopulateThisValue),
	//		subject);
	//}

	//public static DelegateExpectations.WithValue<TActual> That<TActual>(Func<Task<TActual>> subject, [CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	//{
	//	return new DelegateExpectations.WithValue<TActual>(
	//		AssertionBuilder.FromSubject(doNotPopulateThisValue),
	//		subject);
	//}

	//public static AsyncDelegateAssertionBuilder That(ValueTask value, [CallerArgumentExpression("value")] string doNotPopulateThisValue = "")
	//{
	//	return new AsyncDelegateAssertionBuilder(async () => await value, doNotPopulateThisValue);
	//}

	//public static AsyncValueDelegateAssertionBuilder<TActual> That<TActual>(ValueTask<TActual> value, [CallerArgumentExpression("value")] string doNotPopulateThisValue = "")
	//{
	//	return new AsyncValueDelegateAssertionBuilder<TActual>(async () => await value, doNotPopulateThisValue);
	//}

	public static StringExpectations That(string? subject, [CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		return new(new ExpectationBuilder<string?>(subject, doNotPopulateThisValue));
	}

	public static BoolExpectations That(bool? subject, [CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		return new(new ExpectationBuilder<bool?>(subject, doNotPopulateThisValue));
	}
}
