using System.Collections.Generic;
using System.Linq;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Formatting;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatStringCollectionExtensions
{
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
			=> $"contains {Formatter.Format(expected)}";
	}
}
