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
	///     Verifies that the actual exception has an inner exception.
	/// </summary>
	public static AndOrExpectationResult<Exception, ThatExceptionShould<Exception?>> HaveInnerException(
		this ThatExceptionShould<Exception?> source)
		=> new(source.ExpectationBuilder.Add(
				new HasInnerExceptionConstraint<Exception>(),
				b => b.AppendMethod(nameof(HaveInnerException))),
			source);

	/// <summary>
	///     Verifies that the actual exception has an inner exception which satisfies the <paramref name="expectations" />.
	/// </summary>
	public static AndOrExpectationResult<Exception?, ThatExceptionShould<Exception?>> HaveInnerException(
		this ThatExceptionShould<Exception?> source,
		Action<ThatExceptionShould<Exception?>> expectations,
		[CallerArgumentExpression("expectations")]
		string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Which<Exception, Exception?, ThatExceptionShould<Exception?>>(
				PropertyAccessor<Exception, Exception?>.FromFunc(e => e.Value?.InnerException,
					"have an inner exception which should "),
				expectations,
				e => new ThatExceptionShould<Exception?>(e),
				b => b.AppendMethod(nameof(HaveInnerException), doNotPopulateThisValue),
				whichTextSeparator: ""),
			source);
}
