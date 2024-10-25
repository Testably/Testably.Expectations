using System.Collections;
using System.Collections.Generic;

namespace Testably.Expectations.Core.EvaluationContext;

/// <summary>
///     Extension methods for the <see cref="IEvaluationContext" />.
/// </summary>
public static class EvaluationContextExtensions
{
	private const string MaterializedEnumerableKey = nameof(MaterializedEnumerableKey);

	/// <summary>
	///     Avoids enumerating an <see cref="IEnumerable{TItem}" /> multiple times,
	///     by caching already materialized items in the <paramref name="evaluationContext" />.
	/// </summary>
	public static IEnumerable<TItem> UseMaterializedEnumerable<TItem, TCollection>(
		this IEvaluationContext evaluationContext, TCollection collection)
		where TCollection : IEnumerable<TItem>
	{
		if (evaluationContext.TryReceive<IEnumerable<TItem>>(MaterializedEnumerableKey,
			out IEnumerable<TItem>? existingValue))
		{
			return existingValue;
		}

		IEnumerable<TItem> materializedEnumerable = MaterializingEnumerable<TItem>.Wrap(collection);
		// ReSharper disable once PossibleMultipleEnumeration
		evaluationContext.Store(MaterializedEnumerableKey, materializedEnumerable);
		// ReSharper disable once PossibleMultipleEnumeration
		return materializedEnumerable;
	}

	private class MaterializingEnumerable<T> : IEnumerable<T>
	{
		private readonly IEnumerator<T> _enumerator;
		private readonly List<T> _materializedItems = new();

		private MaterializingEnumerable(IEnumerable<T> enumerable)
		{
			_enumerator = enumerable.GetEnumerator();
		}

		#region IEnumerable<T> Members

		/// <inheritdoc />
		IEnumerator IEnumerable.GetEnumerator()
			=> GetEnumerator();

		/// <inheritdoc />
		public IEnumerator<T> GetEnumerator()
		{
			foreach (T materializedItem in _materializedItems)
			{
				yield return materializedItem;
			}

			while (_enumerator.MoveNext())
			{
				T item = _enumerator.Current;
				_materializedItems.Add(item);
				yield return item;
			}
		}

		#endregion

		public static IEnumerable<T> Wrap(IEnumerable<T> enumerable)
		{
			if (enumerable is ICollection<T>)
			{
				return enumerable;
			}

			return new MaterializingEnumerable<T>(enumerable);
		}
	}
}
