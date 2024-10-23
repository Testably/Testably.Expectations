using System.Runtime.CompilerServices;
using Testably.Expectations.Core;

namespace Testably.Expectations;

public static partial class ExpectExtension
{
	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<int> Should(this IExpectThat<int> subject)
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<int?> Should(this IExpectThat<int?> subject)
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="uint" /> <paramref name="subject" />.
	/// </summary>
	public static That<uint> Should(this IExpectThat<uint> subject)
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="uint" /> <paramref name="subject" />.
	/// </summary>
	public static That<uint?> Should(this IExpectThat<uint?> subject)
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="nint" /> <paramref name="subject" />.
	/// </summary>
	public static That<nint> Should(this IExpectThat<nint> subject)
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="nint" /> <paramref name="subject" />.
	/// </summary>
	public static That<nint?> Should(this IExpectThat<nint?> subject)
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="nuint" /> <paramref name="subject" />.
	/// </summary>
	public static That<nuint> Should(this IExpectThat<nuint> subject)
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="nuint" /> <paramref name="subject" />.
	/// </summary>
	public static That<nuint?> Should(this IExpectThat<nuint?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<byte> Should(this IExpectThat<byte> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<byte?> Should(this IExpectThat<byte?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<sbyte> Should(this IExpectThat<sbyte> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<sbyte?> Should(this IExpectThat<sbyte?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<short> Should(this IExpectThat<short> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<short?> Should(this IExpectThat<short?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<ushort> Should(this IExpectThat<ushort> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<ushort?> Should(this IExpectThat<ushort?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<long> Should(this IExpectThat<long> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<long?> Should(this IExpectThat<long?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<ulong> Should(this IExpectThat<ulong> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<ulong?> Should(this IExpectThat<ulong?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<float> Should(this IExpectThat<float> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<float?> Should(this IExpectThat<float?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<double> Should(this IExpectThat<double> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<double?> Should(this IExpectThat<double?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<decimal> Should(this IExpectThat<decimal> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static That<decimal?> Should(this IExpectThat<decimal?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);
}
