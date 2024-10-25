using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatStringCollectionShould
{
	/// <summary>
	///     Verifies that the actual collection contains the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrExpectationResult<IEnumerable<string>, That<IEnumerable<string>>> Contains(
		this That<IEnumerable<string>> source,
		string expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(new ContainsConstraint(expected),
				b => b.AppendMethod(nameof(Contains), doNotPopulateThisValue)),
			source);

	private readonly struct ContainsConstraint(string expected) : IConstraint<IEnumerable<string>>
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
			=> $"contain {Formatter.Format(expected)}";
	}
}
