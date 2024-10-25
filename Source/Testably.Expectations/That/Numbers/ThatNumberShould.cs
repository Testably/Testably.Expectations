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
	public static IThat<int> Should(this IExpectThat<int> subject)
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<int>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<int?> Should(this IExpectThat<int?> subject)
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<int?>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="uint" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<uint> Should(this IExpectThat<uint> subject)
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<uint>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="uint" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<uint?> Should(this IExpectThat<uint?> subject)
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<uint?>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see langword="nint" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<nint> Should(this IExpectThat<nint> subject)
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<nint>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see langword="nint" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<nint?> Should(this IExpectThat<nint?> subject)
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<nint?>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see langword="nuint" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<nuint> Should(this IExpectThat<nuint> subject)
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<nuint>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see langword="nuint" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<nuint?> Should(this IExpectThat<nuint?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<nuint?>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<byte> Should(this IExpectThat<byte> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<byte>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<byte?> Should(this IExpectThat<byte?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<byte?>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<sbyte> Should(this IExpectThat<sbyte> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<sbyte>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<sbyte?> Should(this IExpectThat<sbyte?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<sbyte?>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<short> Should(this IExpectThat<short> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<short>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<short?> Should(this IExpectThat<short?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<short?>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<ushort> Should(this IExpectThat<ushort> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<ushort>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<ushort?> Should(this IExpectThat<ushort?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<ushort?>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<long> Should(this IExpectThat<long> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<long>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<long?> Should(this IExpectThat<long?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<long?>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<ulong> Should(this IExpectThat<ulong> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<ulong>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<ulong?> Should(this IExpectThat<ulong?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<ulong?>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<float> Should(this IExpectThat<float> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<float>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<float?> Should(this IExpectThat<float?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<float?>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<double> Should(this IExpectThat<double> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<double>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<double?> Should(this IExpectThat<double?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<double?>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<decimal> Should(this IExpectThat<decimal> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<decimal>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<decimal?> Should(this IExpectThat<decimal?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<decimal?>(subject.ExpectationBuilder);
	}
}
