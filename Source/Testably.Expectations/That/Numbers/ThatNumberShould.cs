using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
// ReSharper disable once CheckNamespace

namespace Testably.Expectations;

/// <summary>
///     Expectations on numeric values.
/// </summary>
public static partial class ThatNumberShould
{
	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<int> Should(this IExpectThat<int> subject)
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new ThatImpl<int>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<int?> Should(this IExpectThat<int?> subject)
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new ThatImpl<int?>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="uint" /> <paramref name="subject" />.
	/// </summary>
	public static That<uint> Should(this IExpectThat<uint> subject)
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new ThatImpl<uint>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="uint" /> <paramref name="subject" />.
	/// </summary>
	public static That<uint?> Should(this IExpectThat<uint?> subject)
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new ThatImpl<uint?>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see langword="nint" /> <paramref name="subject" />.
	/// </summary>
	public static That<nint> Should(this IExpectThat<nint> subject)
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new ThatImpl<nint>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see langword="nint" /> <paramref name="subject" />.
	/// </summary>
	public static That<nint?> Should(this IExpectThat<nint?> subject)
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new ThatImpl<nint?>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see langword="nuint" /> <paramref name="subject" />.
	/// </summary>
	public static That<nuint> Should(this IExpectThat<nuint> subject)
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new ThatImpl<nuint>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see langword="nuint" /> <paramref name="subject" />.
	/// </summary>
	public static That<nuint?> Should(this IExpectThat<nuint?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new ThatImpl<nuint?>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<byte> Should(this IExpectThat<byte> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new ThatImpl<byte>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<byte?> Should(this IExpectThat<byte?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new ThatImpl<byte?>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<sbyte> Should(this IExpectThat<sbyte> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new ThatImpl<sbyte>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<sbyte?> Should(this IExpectThat<sbyte?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new ThatImpl<sbyte?>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<short> Should(this IExpectThat<short> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new ThatImpl<short>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<short?> Should(this IExpectThat<short?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new ThatImpl<short?>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<ushort> Should(this IExpectThat<ushort> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new ThatImpl<ushort>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<ushort?> Should(this IExpectThat<ushort?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new ThatImpl<ushort?>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<long> Should(this IExpectThat<long> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new ThatImpl<long>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<long?> Should(this IExpectThat<long?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new ThatImpl<long?>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<ulong> Should(this IExpectThat<ulong> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new ThatImpl<ulong>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<ulong?> Should(this IExpectThat<ulong?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new ThatImpl<ulong?>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<float> Should(this IExpectThat<float> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new ThatImpl<float>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<float?> Should(this IExpectThat<float?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new ThatImpl<float?>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<double> Should(this IExpectThat<double> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new ThatImpl<double>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<double?> Should(this IExpectThat<double?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new ThatImpl<double?>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<decimal> Should(this IExpectThat<decimal> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new ThatImpl<decimal>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<decimal?> Should(this IExpectThat<decimal?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new ThatImpl<decimal?>(subject.ExpectationBuilder);
	}
}
