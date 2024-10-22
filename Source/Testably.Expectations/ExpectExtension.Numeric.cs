using System.Runtime.CompilerServices;
using Testably.Expectations.Core;

namespace Testably.Expectations;

public static partial class ExpectExtension
{
	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<int> Should(this ExpectThat<int> subject)
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<int?> Should(this ExpectThat<int?> subject)
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="uint" /> <paramref name="subject" />.
	/// </summary>
	public static That<uint> Should(this ExpectThat<uint> subject)
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="uint" /> <paramref name="subject" />.
	/// </summary>
	public static That<uint?> Should(this ExpectThat<uint?> subject)
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="nint" /> <paramref name="subject" />.
	/// </summary>
	public static That<nint> Should(this ExpectThat<nint> subject)
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="nint" /> <paramref name="subject" />.
	/// </summary>
	public static That<nint?> Should(this ExpectThat<nint?> subject)
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="nuint" /> <paramref name="subject" />.
	/// </summary>
	public static That<nuint> Should(this ExpectThat<nuint> subject)
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="nuint" /> <paramref name="subject" />.
	/// </summary>
	public static That<nuint?> Should(this ExpectThat<nuint?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<byte> Should(this ExpectThat<byte> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<byte?> Should(this ExpectThat<byte?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<sbyte> Should(this ExpectThat<sbyte> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<sbyte?> Should(this ExpectThat<sbyte?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<short> Should(this ExpectThat<short> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<short?> Should(this ExpectThat<short?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<ushort> Should(this ExpectThat<ushort> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<ushort?> Should(this ExpectThat<ushort?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<long> Should(this ExpectThat<long> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<long?> Should(this ExpectThat<long?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<ulong> Should(this ExpectThat<ulong> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<ulong?> Should(this ExpectThat<ulong?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<float> Should(this ExpectThat<float> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<float?> Should(this ExpectThat<float?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<double> Should(this ExpectThat<double> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<double?> Should(this ExpectThat<double?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<decimal> Should(this ExpectThat<decimal> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<decimal?> Should(this ExpectThat<decimal?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);
}
