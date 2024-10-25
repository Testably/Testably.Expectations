using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Core.Sources;
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
	public StringMatcherExpectationResult<TException?, ThatExceptionShould<TException?>> HaveMessage(
		StringMatcher expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(ExpectationBuilder.Add(
				new HasMessageConstraint<TException>(expected),
				b => b.AppendMethod(nameof(HaveMessage), doNotPopulateThisValue)),
			this,
			expected);

	private readonly struct HasMessageConstraint<T>(StringMatcher expected) : IConstraint<T>,
		IDelegateConstraint<DelegateSource.NoValue>
		where T : Exception?
	{
		public ConstraintResult IsMetBy(SourceValue<DelegateSource.NoValue> value)
		{
			return IsMetBy(value.Exception as T);
		}

		public ConstraintResult IsMetBy(T? actual)
		{
			if (expected.Matches(actual?.Message))
			{
				return new ConstraintResult.Success<T?>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(),
				expected.GetExtendedFailure(actual?.Message));
		}

		public override string ToString()
			=> $"have Message {expected.GetExpectation(GrammaticVoice.PassiveVoice)}";
	}
}
