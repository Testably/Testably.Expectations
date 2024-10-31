using System.Collections;
using System.Collections.Generic;

namespace Testably.Expectations.Tests.ThatTests.Collections;

public partial class EnumerableShould
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
		private bool _isEnumerated;

		#region IEnumerable<int> Members

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		public IEnumerator<int> GetEnumerator()
		{
			if (_isEnumerated)
			{
				Fail.Test("The enumerable was enumerated twice!");
			}

			_isEnumerated = true;
			yield return 1;
		}

		#endregion
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
