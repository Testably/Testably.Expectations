using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Results;
using Testably.Expectations.That.Delegates;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="Exception" /> values.
/// </summary>
public static partial class ThatExceptionShould
{
	/// <summary>
	///     Verifies that the actual <see cref="ArgumentException" /> has an <paramref name="expected" /> param name.
	/// </summary>
	public static AndOrExpectationResult<TException, ThatExceptionShould<TException>>
		HaveParamName<TException>(
			this ThatExceptionShould<TException> source,
			string expected,
			[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		where TException : ArgumentException?
		=> new(source.ExpectationBuilder
				.AddConstraint(new HasParamNameValueConstraint<TException>(expected, "have"))
				.AppendMethodStatement(nameof(HaveParamName), doNotPopulateThisValue),
			source);

	/// <summary>
	///     Verifies that the actual <see cref="ArgumentException" /> has an <paramref name="expected" /> param name.
	/// </summary>
	public static AndOrExpectationResult<TException, ThatDelegateThrows<TException>>
		WithParamName<TException>(
			this ThatDelegateThrows<TException> source,
			string expected,
			[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		where TException : ArgumentException?
		=> new(source.ExpectationBuilder
				.AddConstraint(new HasParamNameValueConstraint<TException>(expected, "with"))
				.AppendMethodStatement(nameof(HaveParamName), doNotPopulateThisValue),
			source);
}
