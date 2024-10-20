using System.Runtime.CompilerServices;
using Testably.Expectations.Core;

namespace Testably.Expectations;

public static partial class Expect
{
	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<int> That(int subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<int>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<int?> That(int? subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<int?>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start expectations for the current <see cref="uint" /> <paramref name="subject" />.
	/// </summary>
	public static That<uint> That(uint subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<uint>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start expectations for the current <see cref="uint" /> <paramref name="subject" />.
	/// </summary>
	public static That<uint?> That(uint? subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<uint?>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start expectations for the current <see cref="nint" /> <paramref name="subject" />.
	/// </summary>
	public static That<nint> That(nint subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<nint>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start expectations for the current <see cref="nint" /> <paramref name="subject" />.
	/// </summary>
	public static That<nint?> That(nint? subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<nint?>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start expectations for the current <see cref="nuint" /> <paramref name="subject" />.
	/// </summary>
	public static That<nuint> That(nuint subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<nuint>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start expectations for the current <see cref="nuint" /> <paramref name="subject" />.
	/// </summary>
	public static That<nuint?> That(nuint? subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<nuint?>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<byte> That(byte subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<byte>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<byte?> That(byte? subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<byte?>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<sbyte> That(sbyte subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<sbyte>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<sbyte?> That(sbyte? subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<sbyte?>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<short> That(short subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<short>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<short?> That(short? subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<short?>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<ushort> That(ushort subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<ushort>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<ushort?> That(ushort? subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<ushort?>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<long> That(long subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<long>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<long?> That(long? subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<long?>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<ulong> That(ulong subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<ulong>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<ulong?> That(ulong? subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<ulong?>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<float> That(float subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<float>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<float?> That(float? subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<float?>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<double> That(double subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<double>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<double?> That(double? subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<double?>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<decimal> That(decimal subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<decimal>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<decimal?> That(decimal? subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<decimal?>(subject, doNotPopulateThisValue));
}
