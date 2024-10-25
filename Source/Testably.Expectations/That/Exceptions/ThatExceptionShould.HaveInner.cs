using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="Exception" /> values.
/// </summary>
public static partial class ThatExceptionShould
{
	/// <summary>
	///     Verifies that the actual exception has an inner exception of type <typeparamref name="TException" /> which
	///     satisfies the <paramref name="expectations" />.
	/// </summary>
	public static AndOrExpectationResult<Exception, That<Exception?>> HaveInner<TException>(
		this That<Exception?> source,
		Action<That<TException?>> expectations,
		[CallerArgumentExpression("expectations")]
		string doNotPopulateThisValue = "")
		where TException : Exception?
		=> new(source.ExpectationBuilder.WhichCast<Exception, Exception?, TException?>(
				PropertyAccessor<Exception, Exception?>.FromFunc(e => e.Value?.InnerException,
					$"have an inner {typeof(TException).Name} which should "),
				new CastException<Exception, TException>(),
				expectations,
				b => b.AppendGenericMethod<TException>(nameof(HaveInner), doNotPopulateThisValue),
				""),
			source);

	/// <summary>
	///     Verifies that the actual exception has an inner exception of type <typeparamref name="TException" />.
	/// </summary>
	public static AndOrExpectationResult<Exception, That<Exception?>> HaveInner<TException>(
		this That<Exception?> source)
		where TException : Exception?
		=> new(source.ExpectationBuilder.Add(
				new HasInnerExceptionConstraint<TException>(),
				b => b.AppendGenericMethod<TException>(nameof(HaveInner))),
			source);
}
