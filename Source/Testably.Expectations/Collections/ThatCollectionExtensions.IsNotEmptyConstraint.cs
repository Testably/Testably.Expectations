using System.Collections.Generic;
using System.Linq;
using Testably.Expectations.Core.Constraints;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatCollectionExtensions
{
	private readonly struct IsNotEmptyConstraint<TItem> : IConstraint<ICollection<TItem>>
	{
		public ConstraintResult IsMetBy(ICollection<TItem> actual)
		{
			List<TItem> list = actual.ToList();
			if (list.Any())
			{
				return new ConstraintResult.Success<ICollection<TItem>>(list, ToString());
			}

			return new ConstraintResult.Failure(ToString(), "it was");
		}

		public override string ToString()
			=> "is not empty";
	}
}
