using System.Collections;
using System.Collections.Generic;

namespace Testably.Expectations.Tests.That.Collections;

public partial class ThatEnumerableShould
{
	public static IEnumerable<int> ToEnumerable(int[] items)
	{
		foreach (int item in items)
		{
			yield return item;
		}
	}

	public sealed class ThrowWhenIteratingTwiceEnumerable : IEnumerable<int>
	{
		private bool _isEnumerated = false;

		public IEnumerator<int> GetEnumerator()
		{
			if (_isEnumerated)
			{ 
				Fail.Test("The enumerable was enumerated twice!");
			}

			_isEnumerated = true;
			yield return 1;
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}

	public class MyClass
	{
		public InnerClass? Inner { get; set; }
		public string? Value { get; set; }
	}

	public class InnerClass
	{
		public IEnumerable<string>? Collection { get; set; }

		public InnerClass? Inner { get; set; }
		public string? Value { get; set; }
	}
}
