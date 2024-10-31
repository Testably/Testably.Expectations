using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="Exception" /> values.
/// </summary>
public partial class ThatExceptionShould<TException>
{
	/// <summary>
	///     Verifies that the actual exception has an inner exception which satisfies the <paramref name="expectations" />.
	/// </summary>
	public AndOrExpectationResult<TException?, ThatExceptionShould<TException>> HaveRecursiveInnerExceptions(
		Action<IThat<IEnumerable<Exception>>> expectations,
		[CallerArgumentExpression("expectations")]
		string doNotPopulateThisValue = "")
		=> new(ExpectationBuilder
				.ForProperty(PropertyAccessor<Exception?, IEnumerable<Exception>>.FromFunc(GetInnerExpectations, "recursive inner exceptions "),
					(property, expectation) => $"have {property}which {expectation}")
				.AddExpectations(e => expectations(new Expect.ThatSubject<IEnumerable<Exception>>(e)))
				.AppendMethodStatement(nameof(HaveRecursiveInnerExceptions),
					doNotPopulateThisValue),
			this);
	
	private IEnumerable<Exception> GetInnerExpectations(Exception? actual)
	{
		if (actual == null)
		{
			yield break;
		}
		if (actual.InnerException != null)
		{
			yield return actual.InnerException;
			foreach (var inner in GetInnerExpectations(actual.InnerException))
			{
				yield return inner;
			}
		}

		if (actual is AggregateException aggregateException)
		{
			foreach (var innerException in aggregateException.InnerExceptions)
			{
				yield return innerException;
				foreach (var inner in GetInnerExpectations(innerException))
				{
					yield return inner;
				}
			}
		}
	}
}
