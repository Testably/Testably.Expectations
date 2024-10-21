using System.Collections.Generic;
using Testably.Expectations.Core.Constraints;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatEnumerableExtensions
{
	private readonly struct IsNotEmptyConstraint<TItem> : IConstraint<IEnumerable<TItem>>
	{
		public ConstraintResult IsMetBy(IEnumerable<TItem> actual)
		{
			using IEnumerator<TItem> enumerator = actual.GetEnumerator();
			if (enumerator.MoveNext())
			{
				return new ConstraintResult.Success<IEnumerable<TItem>>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(), "it was");
		}

		public override string ToString()
			=> "is not empty";
	}
}
