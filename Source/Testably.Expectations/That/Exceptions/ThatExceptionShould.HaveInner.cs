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
public partial class ThatExceptionShould<TException>
{
	/// <summary>
	///     Verifies that the actual exception has an inner exception of type <typeparamref name="TInnerException" /> which
	///     satisfies the <paramref name="expectations" />.
	/// </summary>
	public AndOrExpectationResult<TException, ThatExceptionShould<TException?>> HaveInner<TInnerException>(
		Action<ThatExceptionShould<TInnerException?>> expectations,
		[CallerArgumentExpression("expectations")] string doNotPopulateThisValue = "")
		where TInnerException : Exception?
		=> new(ExpectationBuilder.WhichCast<Exception, Exception?, TInnerException?, ThatExceptionShould<TInnerException?>>(
				PropertyAccessor<Exception, Exception?>.FromFunc(e => e.Value?.InnerException,
					$"have an inner {typeof(TInnerException).Name} which should "),
				new ThatExceptionShould.CastException<Exception, TInnerException>(),
				expectations,
				e => new ThatExceptionShould<TInnerException?>(e),
				b => b.AppendGenericMethod<TInnerException>(nameof(HaveInner), doNotPopulateThisValue),
				""),
			this);

	/// <summary>
	///     Verifies that the actual exception has an inner exception of type <typeparamref name="TException" />.
	/// </summary>
	public AndOrExpectationResult<TException, ThatExceptionShould<TException?>> HaveInner<TInnerException>()
		where TInnerException : Exception?
		=> new(ExpectationBuilder.Add(
				new ThatExceptionShould.HasInnerExceptionValueConstraint<TInnerException>("have"),
				b => b.AppendGenericMethod<TInnerException>(nameof(HaveInner))),
			this);
}
