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
	public static IThat<int> Should(this IExpectSubject<int> subject)
		=> new That<int>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<int?> Should(this IExpectSubject<int?> subject)
		=> new That<int?>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="uint" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<uint> Should(this IExpectSubject<uint> subject)
		=> new That<uint>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="uint" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<uint?> Should(this IExpectSubject<uint?> subject)
		=> new That<uint?>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see langword="nint" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<nint> Should(this IExpectSubject<nint> subject)
		=> new That<nint>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see langword="nint" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<nint?> Should(this IExpectSubject<nint?> subject)
		=> new That<nint?>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see langword="nuint" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<nuint> Should(this IExpectSubject<nuint> subject)
		=> new That<nuint>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see langword="nuint" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<nuint?> Should(this IExpectSubject<nuint?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new That<nuint?>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<byte> Should(this IExpectSubject<byte> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new That<byte>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<byte?> Should(this IExpectSubject<byte?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new That<byte?>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<sbyte> Should(this IExpectSubject<sbyte> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new That<sbyte>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<sbyte?> Should(this IExpectSubject<sbyte?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new That<sbyte?>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<short> Should(this IExpectSubject<short> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new That<short>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<short?> Should(this IExpectSubject<short?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new That<short?>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<ushort> Should(this IExpectSubject<ushort> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new That<ushort>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<ushort?> Should(this IExpectSubject<ushort?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new That<ushort?>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<long> Should(this IExpectSubject<long> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new That<long>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<long?> Should(this IExpectSubject<long?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new That<long?>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<ulong> Should(this IExpectSubject<ulong> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new That<ulong>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<ulong?> Should(this IExpectSubject<ulong?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new That<ulong?>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<float> Should(this IExpectSubject<float> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new That<float>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<float?> Should(this IExpectSubject<float?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new That<float?>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<double> Should(this IExpectSubject<double> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new That<double>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<double?> Should(this IExpectSubject<double?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new That<double?>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<decimal> Should(this IExpectSubject<decimal> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new That<decimal>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<decimal?> Should(this IExpectSubject<decimal?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new That<decimal?>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));
}
