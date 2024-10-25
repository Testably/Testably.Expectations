using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatObjectShould
{
	/// <summary>
	///     Verifies that the value satisfies the <paramref name="expectations" /> on the properties selected by the
	///     <paramref name="selector" />.
	/// </summary>
	public static AndOrExpectationResult<T, That<object?>> Satisfy<T, TProperty>(
		this That<object?> source,
		Expression<Func<T, TProperty?>> selector,
		Action<That<TProperty?>> expectations,
		[CallerArgumentExpression("selector")] string doNotPopulateThisValue1 = "",
		[CallerArgumentExpression("expectations")]
		string doNotPopulateThisValue2 = "")
		=> new(source.ExpectationBuilder.Which<T, TProperty?>(
				PropertyAccessor<T, TProperty?>.FromExpression(selector),
				expectations,
				b => b.AppendGenericMethod<T, TProperty>(nameof(Satisfy), doNotPopulateThisValue1,
					doNotPopulateThisValue2),
				whichTextSeparator: "satisfy ",
				whichPropertyTextSeparator: "to "),
			source);
}
