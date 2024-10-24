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

public static partial class ThatEnumerableShould
{
	/// <summary>
	///     Verifies that the actual enumerable contains the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrExpectationResult<IEnumerable<TItem>, That<IEnumerable<TItem>>>
		Contain<TItem>(
			this That<IEnumerable<TItem>> source,
			TItem expected,
			[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(new ContainsConstraint<TItem>(expected),
				b => b.AppendMethod(nameof(Contain), doNotPopulateThisValue)),
			source);

	private readonly struct ContainsConstraint<TItem>(TItem expected)
		: IConstraint<IEnumerable<TItem>>
	{
		public ConstraintResult IsMetBy(IEnumerable<TItem> actual)
		{
			foreach (TItem item in actual)
			{
				if (item?.Equals(expected) == true)
				{
					return new ConstraintResult.Success<IEnumerable<TItem>>(actual, ToString());
				}
			}

			return new ConstraintResult.Failure(ToString(),
				$"found {Formatter.Format(actual.Take(10).ToArray())}");
		}

		public override string ToString()
			=> $"contains {Formatter.Format(expected)}";
	}
}
