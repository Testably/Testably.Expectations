#if NET6_0_OR_GREATER
using System.Collections;
using System.Collections.Generic;

namespace Testably.Expectations.Tests.That.Collections;

public partial class AsyncEnumerableShould
{
	public static async IAsyncEnumerable<int> ToAsyncEnumerable(int[] items)
	{
		foreach (int item in items)
		{
			await Task.Yield();
			yield return item;
		}
	}

}
#endif
