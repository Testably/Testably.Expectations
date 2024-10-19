using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Testably.Expectations.Collections;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;
using Testably.Expectations.Core.Helpers;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on collections.
/// </summary>
public static class ThatCollectionExtensions
{
	/// <summary>
	///     Verifies that all items in the collection...
	/// </summary>
	public static QuantifiableCollection<TItem> All<TItem>(this That<IEnumerable<TItem>> source)
	{
		source.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(All)));
		return new QuantifiableCollection<TItem>(source, Quantifier.All);
	}

	/// <summary>
	///     Verifies that at least <paramref name="minimum" /> items in the collection...
	/// </summary>
	public static QuantifiableCollection<TItem> AtLeast<TItem>(this That<IEnumerable<TItem>> source,
		int minimum, [CallerArgumentExpression("minimum")] string doNotPopulateThisValue = "")
	{
		source.ExpectationBuilder.AppendExpression(b
			=> b.AppendMethod(nameof(AtLeast), doNotPopulateThisValue));
		return new QuantifiableCollection<TItem>(source, Quantifier.AtLeast(minimum));
	}

	/// <summary>
	///     Verifies that at most <paramref name="maximum" /> items in the collection...
	/// </summary>
	public static QuantifiableCollection<TItem> AtMost<TItem>(this That<IEnumerable<TItem>> source,
		int maximum, [CallerArgumentExpression("maximum")] string doNotPopulateThisValue = "")
	{
		source.ExpectationBuilder.AppendExpression(b
			=> b.AppendMethod(nameof(AtMost), doNotPopulateThisValue));
		return new QuantifiableCollection<TItem>(source, Quantifier.AtMost(maximum));
	}

	/// <summary>
	///     Verifies that between <paramref name="minimum" /> and <paramref name="maximum" /> items in the collection...
	/// </summary>
	public static QuantifiableCollection<TItem> Between<TItem>(this That<IEnumerable<TItem>> source,
		int minimum, int maximum,
		[CallerArgumentExpression("minimum")] string doNotPopulateThisValue1 = "",
		[CallerArgumentExpression("maximum")] string doNotPopulateThisValue2 = "")
	{
		source.ExpectationBuilder.AppendExpression(b
			=> b.AppendMethod(nameof(Between), doNotPopulateThisValue1, doNotPopulateThisValue2));
		return new QuantifiableCollection<TItem>(source, Quantifier.Between(minimum, maximum));
	}

	/// <summary>
	///     Verifies that the actual collection contains the <paramref name="expected" /> value.
	/// </summary>
	public static AssertionResult<IEnumerable<TItem>, That<IEnumerable<TItem>>> Contains<TItem>(
		this That<IEnumerable<TItem>> source,
		TItem expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(new ContainsExpectation<TItem>(expected),
				b => b.AppendMethod(nameof(Contains), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the actual collection is empty.
	/// </summary>
	public static AssertionResult<IEnumerable<TItem>, That<IEnumerable<TItem>>> IsEmpty<TItem>(
		this That<IEnumerable<TItem>> source)
		=> new(source.ExpectationBuilder.Add(new IsEmptyExpectation<TItem>(),
				b => b.AppendMethod(nameof(IsEmpty))),
			source);

	/// <summary>
	///     Verifies that the actual collection is not empty.
	/// </summary>
	public static AssertionResult<IEnumerable<TItem>, That<IEnumerable<TItem>>> IsNotEmpty<TItem>(
		this That<IEnumerable<TItem>> source)
		=> new(source.ExpectationBuilder.Add(new IsNotEmptyExpectation<TItem>(),
				b => b.AppendMethod(nameof(IsNotEmpty))),
			source);

	/// <summary>
	///     Verifies that no items in the collection...
	/// </summary>
	public static QuantifiableCollection<TItem> None<TItem>(this That<IEnumerable<TItem>> source)
	{
		source.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(None)));
		return new QuantifiableCollection<TItem>(source, Quantifier.None);
	}

	private readonly struct ContainsExpectation<TItem>(TItem expected)
		: IExpectation<IEnumerable<TItem>>
	{
		public ExpectationResult IsMetBy(IEnumerable<TItem> actual)
		{
			List<TItem>? list = actual.ToList();
			if (list.Contains(expected))
			{
				return new ExpectationResult.Success<IEnumerable<TItem>>(list, ToString());
			}

			return new ExpectationResult.Failure(ToString(), $"found {Formatter.Format(list)}");
		}

		public override string ToString()
			=> $"contains {Formatter.Format(expected)}";
	}

	private readonly struct IsEmptyExpectation<TItem> : IExpectation<IEnumerable<TItem>>
	{
		public ExpectationResult IsMetBy(IEnumerable<TItem> actual)
		{
			List<TItem>? list = actual.ToList();
			if (!list.Any())
			{
				return new ExpectationResult.Success<IEnumerable<TItem>>(list, ToString());
			}

			return new ExpectationResult.Failure(ToString(), $"found {Formatter.Format(list)}");
		}

		public override string ToString()
			=> "is empty";
	}

	private readonly struct IsNotEmptyExpectation<TItem> : IExpectation<IEnumerable<TItem>>
	{
		public ExpectationResult IsMetBy(IEnumerable<TItem> actual)
		{
			List<TItem>? list = actual.ToList();
			if (list.Any())
			{
				return new ExpectationResult.Success<IEnumerable<TItem>>(list, ToString());
			}

			return new ExpectationResult.Failure(ToString(), "it was");
		}

		public override string ToString()
			=> "is not empty";
	}
}
