using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

namespace Testably.Expectations;

public static partial class ThatStringCollectionShould
{
	/// <summary>
	///     Verifies that the actual collection contains the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<IEnumerable<string>, IThat<IEnumerable<string>>> Contain(
		this IThat<IEnumerable<string>> source,
		string expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder
				.AddConstraint(new ContainsValueConstraint(expected))
				.AppendMethodStatement(nameof(Contain), doNotPopulateThisValue),
			source);

	private readonly struct ContainsValueConstraint(string expected)
		: IValueConstraint<IEnumerable<string>>
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
