using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Core.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="string" /> collections.
/// </summary>
public static class ThatStringCollectionExtensions
{
	/// <summary>
	///     Verifies that the actual collection contains the <paramref name="expected" /> value.
	/// </summary>
	public static AssertionResultAndOr<IEnumerable<string>, That<IEnumerable<string>>> Contains(
		this That<IEnumerable<string>> source,
		string expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(new ContainsExpectation(expected),
				b => b.AppendMethod(nameof(Contains), doNotPopulateThisValue)),
			source);

	private readonly struct ContainsExpectation(string expected) : IExpectation<IEnumerable<string>>
	{
		public ConstraintResult IsMetBy(IEnumerable<string> actual)
		{
			List<string> list = actual.ToList();
			if (list.Contains(expected))
			{
				return new ConstraintResult.Success<IEnumerable<string>>(list, ToString());
			}

			return new ConstraintResult.Failure(ToString(), $"found {Formatter.Format(list)}");
		}

		public override string ToString()
			=> $"contains {Formatter.Format(expected)}";
	}
}
