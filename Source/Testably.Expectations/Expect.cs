using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;

namespace Testably.Expectations;

/// <summary>
///     The starting point for checking expectations.
/// </summary>
[StackTraceHidden]
public static partial class Expect
{
	/// <summary>
	///     Start asserting the current <see cref="bool" /> <paramref name="subject" />.
	/// </summary>
	public static That<bool> That(bool subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<bool>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start asserting the current <see cref="bool" />? <paramref name="subject" />.
	/// </summary>
	public static That<bool?> That(bool? subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<bool?>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start asserting the current <typeparamref name="TException" /> <paramref name="subject" />.
	/// </summary>
	public static That<TException?> That<TException>(TException subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		where TException : Exception
		=> new(new ExpectationBuilder<TException>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start asserting the current <see cref="object" />? <paramref name="subject" />.
	/// </summary>
	public static That<object?> That(object? subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<object?>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start asserting the current <see cref="string" />? <paramref name="subject" />.
	/// </summary>
	public static That<string?> That(string? subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<string?>(subject, doNotPopulateThisValue));
}
