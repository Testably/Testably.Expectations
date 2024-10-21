using System.Collections;
using System.Collections.Generic;

namespace Testably.Expectations.Core;

internal class MaterializingEnumerable<T> : IEnumerable<T>
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
