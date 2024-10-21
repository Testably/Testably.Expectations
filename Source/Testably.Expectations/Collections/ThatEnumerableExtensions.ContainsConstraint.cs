using System.Collections.Generic;
using System.Linq;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Formatting;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatEnumerableExtensions
{
	private readonly struct ContainsConstraint<TItem>(TItem expected)
		: IConstraint<IEnumerable<TItem>>
	{
		public ConstraintResult IsMetBy(IEnumerable<TItem> actual)
		{
			foreach (var item in actual)
			{
				if (item?.Equals(expected) == true)
				{
					return new ConstraintResult.Success<IEnumerable<TItem>>(actual, ToString());
				}
			}
			return new ConstraintResult.Failure(ToString(), $"found {Formatter.Format(actual.Take(10).ToArray())}");
		}

		public override string ToString()
			=> $"contains {Formatter.Format(expected)}";
	}
}
