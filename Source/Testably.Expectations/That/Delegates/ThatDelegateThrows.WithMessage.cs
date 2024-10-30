using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Options;
using Testably.Expectations.Results;
// ReSharper disable once CheckNamespace

namespace Testably.Expectations;

public partial class ThatDelegateThrows<TException>
{
	/// <summary>
	///     Verifies that the thrown exception has a message equal to <paramref name="expected" />
	/// </summary>
	public StringMatcherExpectationResult<TException, ThatDelegateThrows<TException>>
		WithMessage(
			StringMatcher expected,
			[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(ExpectationBuilder
				.AddConstraint(new ThatExceptionShould.HasMessageValueConstraint<TException>(
					expected, "with"))
				.AppendMethodStatement(nameof(WithMessage), doNotPopulateThisValue),
			this,
			expected);
}
