using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
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
		=> subject.Should(expectationBuilder => expectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<int?> Should(this IExpectSubject<int?> subject)
		=> subject.Should(expectationBuilder => expectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="uint" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<uint> Should(this IExpectSubject<uint> subject)
		=> subject.Should(expectationBuilder => expectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="uint" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<uint?> Should(this IExpectSubject<uint?> subject)
		=> subject.Should(expectationBuilder => expectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see langword="nint" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<nint> Should(this IExpectSubject<nint> subject)
		=> subject.Should(expectationBuilder => expectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see langword="nint" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<nint?> Should(this IExpectSubject<nint?> subject)
		=> subject.Should(expectationBuilder => expectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see langword="nuint" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<nuint> Should(this IExpectSubject<nuint> subject)
		=> subject.Should(expectationBuilder => expectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see langword="nuint" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<nuint?> Should(this IExpectSubject<nuint?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> subject.Should(expectationBuilder => expectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<byte> Should(this IExpectSubject<byte> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> subject.Should(expectationBuilder => expectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<byte?> Should(this IExpectSubject<byte?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> subject.Should(expectationBuilder => expectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<sbyte> Should(this IExpectSubject<sbyte> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> subject.Should(expectationBuilder => expectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<sbyte?> Should(this IExpectSubject<sbyte?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> subject.Should(expectationBuilder => expectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<short> Should(this IExpectSubject<short> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> subject.Should(expectationBuilder => expectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<short?> Should(this IExpectSubject<short?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> subject.Should(expectationBuilder => expectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<ushort> Should(this IExpectSubject<ushort> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> subject.Should(expectationBuilder => expectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<ushort?> Should(this IExpectSubject<ushort?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> subject.Should(expectationBuilder => expectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<long> Should(this IExpectSubject<long> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> subject.Should(expectationBuilder => expectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<long?> Should(this IExpectSubject<long?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> subject.Should(expectationBuilder => expectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<ulong> Should(this IExpectSubject<ulong> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> subject.Should(expectationBuilder => expectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<ulong?> Should(this IExpectSubject<ulong?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> subject.Should(expectationBuilder => expectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<float> Should(this IExpectSubject<float> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> subject.Should(expectationBuilder => expectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<float?> Should(this IExpectSubject<float?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> subject.Should(expectationBuilder => expectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<double> Should(this IExpectSubject<double> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> subject.Should(expectationBuilder => expectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<double?> Should(this IExpectSubject<double?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> subject.Should(expectationBuilder => expectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<decimal> Should(this IExpectSubject<decimal> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> subject.Should(expectationBuilder => expectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<decimal?> Should(this IExpectSubject<decimal?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> subject.Should(expectationBuilder => expectationBuilder
			.AppendMethodStatement(nameof(Should)));
	
	
	private readonly struct GenericConstraint<T>(
		T expected,
		string expectation,
		Func<T, T, bool> condition,
		Func<T, T, string> failureMessageFactory)
		: IValueConstraint<T>
	{
		public ConstraintResult IsMetBy(T actual)
		{
			if (condition(actual, expected))
			{
				return new ConstraintResult.Success<T>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(), failureMessageFactory(actual, expected));
		}

		public override string ToString()
			=> expectation;
	}
}
