using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Options;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="Exception" /> values.
/// </summary>
public partial class ThatExceptionShould<TException>
{
	/// <summary>
	///     Verifies that the actual exception has a message equal to <paramref name="expected" />
	/// </summary>
	public StringMatcherExpectationResult<TException?, ThatExceptionShould<TException>>
		HaveMessage(
			StringMatcher expected,
			[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(ExpectationBuilder
				.AddConstraint(
					new ThatExceptionShould.HasMessageValueConstraint<TException>(expected, "have"))
				.AppendMethodStatement(nameof(HaveMessage), doNotPopulateThisValue),
			this,
			expected);
}
