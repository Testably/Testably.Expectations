using System.Collections.Generic;
using System.Linq;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatCollectionExtensions
{
	private readonly struct IsEmptyConstraint<TItem> : IExpectation<IEnumerable<TItem>>
	{
		public ConstraintResult IsMetBy(IEnumerable<TItem> actual)
		{
			List<TItem> list = actual.ToList();
			if (!list.Any())
			{
				return new ConstraintResult.Success<IEnumerable<TItem>>(list, ToString());
			}

			return new ConstraintResult.Failure(ToString(), $"found {Formatter.Format(list)}");
		}

		public override string ToString()
			=> "is empty";
	}
}
