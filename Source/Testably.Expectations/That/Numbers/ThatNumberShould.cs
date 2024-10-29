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
		=> new That<int>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<int?> Should(this IExpectThat<int?> subject)
		=> new That<int?>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="uint" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<uint> Should(this IExpectThat<uint> subject)
		=> new That<uint>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="uint" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<uint?> Should(this IExpectThat<uint?> subject)
		=> new That<uint?>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see langword="nint" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<nint> Should(this IExpectThat<nint> subject)
		=> new That<nint>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see langword="nint" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<nint?> Should(this IExpectThat<nint?> subject)
		=> new That<nint?>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see langword="nuint" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<nuint> Should(this IExpectThat<nuint> subject)
		=> new That<nuint>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see langword="nuint" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<nuint?> Should(this IExpectThat<nuint?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new That<nuint?>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<byte> Should(this IExpectThat<byte> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new That<byte>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<byte?> Should(this IExpectThat<byte?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new That<byte?>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<sbyte> Should(this IExpectThat<sbyte> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new That<sbyte>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<sbyte?> Should(this IExpectThat<sbyte?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new That<sbyte?>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<short> Should(this IExpectThat<short> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new That<short>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<short?> Should(this IExpectThat<short?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new That<short?>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<ushort> Should(this IExpectThat<ushort> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new That<ushort>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<ushort?> Should(this IExpectThat<ushort?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new That<ushort?>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<long> Should(this IExpectThat<long> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new That<long>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<long?> Should(this IExpectThat<long?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new That<long?>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<ulong> Should(this IExpectThat<ulong> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new That<ulong>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<ulong?> Should(this IExpectThat<ulong?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new That<ulong?>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<float> Should(this IExpectThat<float> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new That<float>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<float?> Should(this IExpectThat<float?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new That<float?>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<double> Should(this IExpectThat<double> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new That<double>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<double?> Should(this IExpectThat<double?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new That<double?>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<decimal> Should(this IExpectThat<decimal> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new That<decimal>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<decimal?> Should(this IExpectThat<decimal?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new That<decimal?>(subject.ExpectationBuilder
			.AppendMethodStatement(nameof(Should)));
}
