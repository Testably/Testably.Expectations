using System;
using System.IO;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;

namespace Testably.Expectations;

/// <summary>
///     The starting point for checking expectations.
/// </summary>
public static partial class ExpectExtension
{
	/// <summary>
	///     Start expectations for current <see cref="bool" /> <paramref name="subject" />.
	/// </summary>
	public static That<bool> Should(this ExpectThat<bool> subject)
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="bool" />? <paramref name="subject" />.
	/// </summary>
	public static That<bool?> Should(this ExpectThat<bool?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

#if !NETSTANDARD2_0
	/// <summary>
	///     Start expectations for current <see cref="DateOnly" /> <paramref name="subject" />.
	/// </summary>
	public static That<DateOnly> Should(this ExpectThat<DateOnly> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);
#endif

#if !NETSTANDARD2_0
	/// <summary>
	///     Start expectations for the current <see cref="DateOnly" />? <paramref name="subject" />.
	/// </summary>
	public static That<DateOnly?> Should(this ExpectThat<DateOnly?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);
#endif

	/// <summary>
	///     Start expectations for current <see cref="DateTime" /> <paramref name="subject" />.
	/// </summary>
	public static That<DateTime> Should(this ExpectThat<DateTime> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="DateTime" />? <paramref name="subject" />.
	/// </summary>
	public static That<DateTime?> Should(this ExpectThat<DateTime?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for current <see cref="DateTimeOffset" /> <paramref name="subject" />.
	/// </summary>
	public static That<DateTimeOffset> Should(this ExpectThat<DateTimeOffset> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="DateTimeOffset" />? <paramref name="subject" />.
	/// </summary>
	public static That<DateTimeOffset?> Should(this ExpectThat<DateTimeOffset?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <typeparamref name="TEnum" /> <paramref name="subject" />.
	/// </summary>
	public static That<TEnum> That<TEnum>(this ExpectThat<TEnum> subject)
		where TEnum : struct, Enum
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <typeparamref name="TEnum" />? <paramref name="subject" />.
	/// </summary>
	public static That<TEnum?> That<TEnum>(this ExpectThat<TEnum?> subject)
		where TEnum : struct, Enum
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="Exception" /> <paramref name="subject" />.
	/// </summary>
	public static That<Exception?> Should(this ExpectThat<Exception?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for current <see cref="Guid" /> <paramref name="subject" />.
	/// </summary>
	public static That<Guid> Should(this ExpectThat<Guid> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="Guid" />? <paramref name="subject" />.
	/// </summary>
	public static That<Guid?> Should(this ExpectThat<Guid?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="object" />? <paramref name="subject" />.
	/// </summary>
	public static That<object?> Should(this ExpectThat<object?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="Stream" /> <paramref name="subject" />.
	/// </summary>
	public static That<Stream?> Should(this ExpectThat<Stream?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="string" />? <paramref name="subject" />.
	/// </summary>
	public static That<string?> Should(this ExpectThat<string?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

#if !NETSTANDARD2_0
	/// <summary>
	///     Start expectations for current <see cref="TimeOnly" /> <paramref name="subject" />.
	/// </summary>
	public static That<TimeOnly> Should(this ExpectThat<TimeOnly> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);
#endif

#if !NETSTANDARD2_0
	/// <summary>
	///     Start expectations for the current <see cref="TimeOnly" />? <paramref name="subject" />.
	/// </summary>
	public static That<TimeOnly?> Should(this ExpectThat<TimeOnly?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);
#endif

	/// <summary>
	///     Start expectations for current <see cref="TimeSpan" /> <paramref name="subject" />.
	/// </summary>
	public static That<TimeSpan> Should(this ExpectThat<TimeSpan> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="TimeSpan" />? <paramref name="subject" />.
	/// </summary>
	public static That<TimeSpan?> Should(this ExpectThat<TimeSpan?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);
}
