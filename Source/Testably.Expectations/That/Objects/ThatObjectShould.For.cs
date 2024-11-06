using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Results;

namespace Testably.Expectations;

public static partial class ThatObjectShould
{
	/// <summary>
	///     Verifies the <paramref name="expectations" /> on the property selected by the <paramref name="selector" />.
	/// </summary>
	public static AndOrResult<T, IThat<object?>> For<T, TProperty>(
		this IThat<object?> source,
		Expression<Func<T, TProperty?>> selector,
		Action<IThat<TProperty?>> expectations,
		[CallerArgumentExpression("selector")] string doNotPopulateThisValue1 = "",
		[CallerArgumentExpression("expectations")]
		string doNotPopulateThisValue2 = "")
		=> new(source.ExpectationBuilder
				.ForProperty(PropertyAccessor<T, TProperty?>.FromExpression(selector),
					(property, expectation) => $"for {property}{expectation}")
				.AddExpectations(e => expectations(new Expect.ThatSubject<TProperty?>(e)))
				.AppendGenericMethodStatement<T, TProperty>(nameof(For),
					doNotPopulateThisValue1, doNotPopulateThisValue2),
			source);
}
