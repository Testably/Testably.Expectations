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
	///     Start asserting the current <see cref="Action" /> <paramref name="subject" />.
	/// </summary>
	public static DelegateExpectations.WithoutValue That(Action subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<object>(new DelegateSource(subject), doNotPopulateThisValue));

	/// <summary>
	///     Start asserting the current <see cref="Func{TActual}" /> <paramref name="subject" />.
	/// </summary>
	public static DelegateExpectations.WithValue<TActual> That<TActual>(Func<TActual> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		return new DelegateExpectations.WithValue<TActual>(
			new ExpectationBuilder<TActual>(new DelegateValueSource<TActual>(subject),
				doNotPopulateThisValue));
	}

	public static DelegateExpectations.WithValue<TActual> That<TActual>(Func<Task<TActual>> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		return new DelegateExpectations.WithValue<TActual>(
			new ExpectationBuilder<TActual>(new DelegateAsyncValueSource<TActual>(subject),
				doNotPopulateThisValue));
	}

	public static DelegateExpectations.WithoutValue That(Func<Task> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		return new DelegateExpectations.WithoutValue(
			new ExpectationBuilder<object>(new DelegateAsyncSource(subject),
				doNotPopulateThisValue));
	}

	//public static DelegateExpectations.WithoutValue That(Func<Task> subject, [CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	//{
	//	return new DelegateExpectations.WithoutValue(
	//		AssertionBuilder.FromSubject(doNotPopulateThisValue),
	//		subject);
	//}

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
}
