using System.Collections.Generic;
using System.Linq;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Formatting;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatCollectionExtensions
{
	private readonly struct IsEmptyConstraint<TItem> : IConstraint<ICollection<TItem>>
	{
		public ConstraintResult IsMetBy(ICollection<TItem> actual)
		{
			List<TItem> list = actual.ToList();
			if (!list.Any())
			{
				return new ConstraintResult.Success<ICollection<TItem>>(list, ToString());
			}

			return new ConstraintResult.Failure(ToString(), $"found {Formatter.Format(list)}");
		}

		public override string ToString()
			=> "is empty";
	}
}
