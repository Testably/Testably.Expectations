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
	public static AndOrExpectationResult<Exception, That<Exception?>> HaveInnerException(
		this That<Exception?> source)
		=> new(source.ExpectationBuilder.Add(
				new HasInnerExceptionConstraint<Exception>(),
				b => b.AppendMethod(nameof(HaveInnerException))),
			source);

	/// <summary>
	///     Verifies that the actual exception has an inner exception which satisfies the <paramref name="expectations" />.
	/// </summary>
	public static AndOrExpectationResult<Exception?, That<Exception?>> HaveInnerException(
		this That<Exception?> source,
		Action<That<Exception?>> expectations,
		[CallerArgumentExpression("expectations")]
		string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Which<Exception, Exception?>(
				PropertyAccessor<Exception, Exception?>.FromFunc(e => e.Value?.InnerException,
					"have an inner exception which should "),
				expectations,
				b => b.AppendMethod(nameof(HaveInnerException), doNotPopulateThisValue),
				whichTextSeparator: ""),
			source);
}
