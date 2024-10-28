using System.Runtime.CompilerServices;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Options;
using Testably.Expectations.Results;

namespace Testably.Expectations.That.Delegates;

public partial class ThatDelegateThrows<TException>
{
	/// <summary>
	///     Verifies that the thrown exception has a message equal to <paramref name="expected" />
	/// </summary>
	public StringMatcherExpectationResult<TException, ThatDelegateThrows<TException>>
		WithMessage(
			StringMatcher expected,
			[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(ExpectationBuilder.Add(
				new ThatExceptionShould.HasMessageValueConstraint<TException>(expected, "with"),
				b => b.AppendMethod(nameof(WithMessage), doNotPopulateThisValue)),
			this,
			expected);
}
