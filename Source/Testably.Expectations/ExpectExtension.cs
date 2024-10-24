using System;
using System.IO;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;

namespace Testably.Expectations;

/// <summary>
///     The starting point for checking expectations.
/// </summary>
public static partial class ExpectExtension
{
#if !NETSTANDARD2_0
	/// <summary>
	///     Start expectations for current <see cref="DateOnly" /> <paramref name="subject" />.
	/// </summary>
	public static That<DateOnly> Should(this IExpectThat<DateOnly> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<DateOnly>(subject.ExpectationBuilder);
	}
#endif

#if !NETSTANDARD2_0
	/// <summary>
	///     Start expectations for the current <see cref="DateOnly" />? <paramref name="subject" />.
	/// </summary>
	public static That<DateOnly?> Should(this IExpectThat<DateOnly?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<DateOnly?>(subject.ExpectationBuilder);
	}
#endif

	/// <summary>
	///     Start expectations for current <see cref="DateTime" /> <paramref name="subject" />.
	/// </summary>
	public static That<DateTime> Should(this IExpectThat<DateTime> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<DateTime>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="DateTime" />? <paramref name="subject" />.
	/// </summary>
	public static That<DateTime?> Should(this IExpectThat<DateTime?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<DateTime?>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for current <see cref="DateTimeOffset" /> <paramref name="subject" />.
	/// </summary>
	public static That<DateTimeOffset> Should(this IExpectThat<DateTimeOffset> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<DateTimeOffset>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="DateTimeOffset" />? <paramref name="subject" />.
	/// </summary>
	public static That<DateTimeOffset?> Should(this IExpectThat<DateTimeOffset?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<DateTimeOffset?>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <typeparamref name="TEnum" /> <paramref name="subject" />.
	/// </summary>
	public static That<TEnum> Should<TEnum>(this IExpectThat<TEnum> subject)
		where TEnum : struct, Enum
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<TEnum>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <typeparamref name="TEnum" />? <paramref name="subject" />.
	/// </summary>
	public static That<TEnum?> Should<TEnum>(this IExpectThat<TEnum?> subject)
		where TEnum : struct, Enum
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<TEnum?>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="Exception" /> <paramref name="subject" />.
	/// </summary>
	public static That<Exception?> Should(this IExpectThat<Exception?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<Exception?>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for current <see cref="Guid" /> <paramref name="subject" />.
	/// </summary>
	public static That<Guid> Should(this IExpectThat<Guid> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<Guid>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="Guid" />? <paramref name="subject" />.
	/// </summary>
	public static That<Guid?> Should(this IExpectThat<Guid?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<Guid?>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="object" />? <paramref name="subject" />.
	/// </summary>
	public static That<object?> Should(this IExpectThat<object?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<object?>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="Stream" /> <paramref name="subject" />.
	/// </summary>
	public static That<TStream?> Should<TStream>(this IExpectThat<TStream?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	where TStream : Stream
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<TStream?>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="string" />? <paramref name="subject" />.
	/// </summary>
	public static That<string?> Should(this IExpectThat<string?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<string?>(subject.ExpectationBuilder);
	}

#if !NETSTANDARD2_0
	/// <summary>
	///     Start expectations for current <see cref="TimeOnly" /> <paramref name="subject" />.
	/// </summary>
	public static That<TimeOnly> Should(this IExpectThat<TimeOnly> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<TimeOnly>(subject.ExpectationBuilder);
	}
#endif

#if !NETSTANDARD2_0
	/// <summary>
	///     Start expectations for the current <see cref="TimeOnly" />? <paramref name="subject" />.
	/// </summary>
	public static That<TimeOnly?> Should(this IExpectThat<TimeOnly?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<TimeOnly?>(subject.ExpectationBuilder);
	}
#endif

	/// <summary>
	///     Start expectations for current <see cref="TimeSpan" /> <paramref name="subject" />.
	/// </summary>
	public static That<TimeSpan> Should(this IExpectThat<TimeSpan> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<TimeSpan>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="TimeSpan" />? <paramref name="subject" />.
	/// </summary>
	public static That<TimeSpan?> Should(this IExpectThat<TimeSpan?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<TimeSpan?>(subject.ExpectationBuilder);
	}
}
