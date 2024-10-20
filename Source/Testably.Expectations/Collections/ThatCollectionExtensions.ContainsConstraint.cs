using System.Collections.Generic;
using System.Linq;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Formatting;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatCollectionExtensions
{
	private readonly struct ContainsConstraint<TItem>(TItem expected)
		: IConstraint<IEnumerable<TItem>>
	{
		public ConstraintResult IsMetBy(IEnumerable<TItem> actual)
		{
			List<TItem> list = actual.ToList();
			if (list.Contains(expected))
			{
				return new ConstraintResult.Success<IEnumerable<TItem>>(list, ToString());
			}

			return new ConstraintResult.Failure(ToString(), $"found {Formatter.Format(list)}");
		}

		public override string ToString()
			=> $"contains {Formatter.Format(expected)}";
	}
}
