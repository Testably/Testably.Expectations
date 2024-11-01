using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Results;
// ReSharper disable once CheckNamespace

namespace Testably.Expectations;

public partial class ThatDelegateThrows<TException>
{
	/// <summary>
	///     Verifies that the actual exception recursively has inner exceptions which satisfy the
	///     <paramref name="expectations" />.
	/// </summary>
	public AndOrExpectationResult<TException?, ThatDelegateThrows<TException>>
		WithRecursiveInnerExceptions(
			Action<IThat<IEnumerable<Exception>>> expectations,
			[CallerArgumentExpression("expectations")]
			string doNotPopulateThisValue = "")
		=> new(ExpectationBuilder
				.ForProperty(
					PropertyAccessor<Exception?, IEnumerable<Exception>>.FromFunc(
						e => e.GetInnerExpectations(), "recursive inner exceptions "),
					(property, expectation) => $"with {property}which {expectation}")
				.AddExpectations(e
					=> expectations(new Expect.ThatSubject<IEnumerable<Exception>>(e)))
				.AppendMethodStatement(nameof(WithRecursiveInnerExceptions),
					doNotPopulateThisValue),
			this);
}
