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
	///     Verifies that the value on the property selected by the <paramref name="selector" />...
	/// </summary>
	public static SatisfyResult<TProperty, AndOrExpectationResult<T, That<object?>>> Satisfy<T,
		TProperty>(
		this That<object?> source,
		Expression<Func<T, TProperty?>> selector,
		[CallerArgumentExpression("selector")] string doNotPopulateThisValue1 = "")
		=> new((expectations, doNotPopulateThisValue2) =>
			new AndOrExpectationResult<T, That<object?>>(
				source.ExpectationBuilder.Which<T, TProperty?>(
					PropertyAccessor<T, TProperty?>.FromExpression(selector),
					expectations,
					b => b.AppendGenericMethod<T, TProperty>(nameof(Satisfy),
							doNotPopulateThisValue1)
						.AppendMethod(nameof(SatisfyResult<TProperty, T>.To),
							doNotPopulateThisValue2),
					whichTextSeparator: "satisfy ",
					whichPropertyTextSeparator: "to "),
				source));

	/// <summary>
	///     Intermediate result for chaining Satisfy and To methods.
	/// </summary>
	public class SatisfyResult<TProperty, TReturn>(
		Func<Action<That<TProperty?>>, string, TReturn> resultCallback)
	{
		/// <summary>
		///     ...satisfies the <paramref name="expectations" />
		/// </summary>
		public TReturn To(
			Action<That<TProperty?>> expectations,
			[CallerArgumentExpression("expectations")]
			string doNotPopulateThisValue = "")
		{
			return resultCallback(expectations, doNotPopulateThisValue);
		}
	}
}
