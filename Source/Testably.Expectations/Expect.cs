﻿using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;

namespace Testably.Expectations;

/// <summary>
///     The starting point for checking expectations.
/// </summary>
public static partial class Expect
{
	/// <summary>
	///     Start expectations for current <see cref="bool" /> <paramref name="subject" />.
	/// </summary>
	public static That<bool> That(bool subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<bool>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start expectations for the current <see cref="bool" />? <paramref name="subject" />.
	/// </summary>
	public static That<bool?> That(bool? subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<bool?>(subject, doNotPopulateThisValue));

#if !NETSTANDARD2_0
	/// <summary>
	///     Start expectations for current <see cref="DateOnly" /> <paramref name="subject" />.
	/// </summary>
	public static That<DateOnly> That(DateOnly subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<DateOnly>(subject, doNotPopulateThisValue));
#endif

#if !NETSTANDARD2_0
	/// <summary>
	///     Start expectations for the current <see cref="DateOnly" />? <paramref name="subject" />.
	/// </summary>
	public static That<DateOnly?> That(DateOnly? subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<DateOnly?>(subject, doNotPopulateThisValue));
#endif

	/// <summary>
	///     Start expectations for current <see cref="DateTime" /> <paramref name="subject" />.
	/// </summary>
	public static That<DateTime> That(DateTime subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<DateTime>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start expectations for the current <see cref="DateTime" />? <paramref name="subject" />.
	/// </summary>
	public static That<DateTime?> That(DateTime? subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<DateTime?>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start expectations for current <see cref="DateTimeOffset" /> <paramref name="subject" />.
	/// </summary>
	public static That<DateTimeOffset> That(DateTimeOffset subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<DateTimeOffset>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start expectations for the current <see cref="DateTimeOffset" />? <paramref name="subject" />.
	/// </summary>
	public static That<DateTimeOffset?> That(DateTimeOffset? subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<DateTimeOffset?>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start expectations for the current <typeparamref name="TException" /> <paramref name="subject" />.
	/// </summary>
	public static That<TException?> That<TException>(TException subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		where TException : Exception
		=> new(new ExpectationBuilder<TException>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start expectations for the current <see cref="object" />? <paramref name="subject" />.
	/// </summary>
	public static That<object?> That(object? subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<object?>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start expectations for the current <see cref="string" />? <paramref name="subject" />.
	/// </summary>
	public static That<string?> That(string? subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<string?>(subject, doNotPopulateThisValue));

#if !NETSTANDARD2_0
	/// <summary>
	///     Start expectations for current <see cref="TimeOnly" /> <paramref name="subject" />.
	/// </summary>
	public static That<TimeOnly> That(TimeOnly subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<TimeOnly>(subject, doNotPopulateThisValue));
#endif

#if !NETSTANDARD2_0
	/// <summary>
	///     Start expectations for the current <see cref="TimeOnly" />? <paramref name="subject" />.
	/// </summary>
	public static That<TimeOnly?> That(TimeOnly? subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<TimeOnly?>(subject, doNotPopulateThisValue));
#endif

	/// <summary>
	///     Start expectations for current <see cref="TimeSpan" /> <paramref name="subject" />.
	/// </summary>
	public static That<TimeSpan> That(TimeSpan subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<TimeSpan>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start expectations for the current <see cref="TimeSpan" />? <paramref name="subject" />.
	/// </summary>
	public static That<TimeSpan?> That(TimeSpan? subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<TimeSpan?>(subject, doNotPopulateThisValue));
}
