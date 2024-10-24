using System.Collections.Generic;
using System.Linq;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatCollectionShould
{
	/// <summary>
	///     Verifies that the actual collection is empty.
	/// </summary>
	public static AndOrExpectationResult<ICollection<TItem>, That<ICollection<TItem>>>
		BeEmpty<TItem>(
			this That<ICollection<TItem>> source)
		=> new(source.ExpectationBuilder.Add(new IsEmptyConstraint<TItem>(),
				b => b.AppendMethod(nameof(BeEmpty))),
			source);

	/// <summary>
	///     Verifies that the actual collection is not empty.
	/// </summary>
	public static AndOrExpectationResult<ICollection<TItem>, That<ICollection<TItem>>>
		NotBeEmpty<TItem>(
			this That<ICollection<TItem>> source)
		=> new(source.ExpectationBuilder.Add(new IsNotEmptyConstraint<TItem>(),
				b => b.AppendMethod(nameof(NotBeEmpty))),
			source);

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
			=> "be empty";
	}

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
			=> "not be empty";
	}
}
