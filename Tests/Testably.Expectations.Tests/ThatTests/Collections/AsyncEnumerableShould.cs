#if NET6_0_OR_GREATER
using System.Collections.Generic;
using System.Threading;

namespace Testably.Expectations.Tests.ThatTests.Collections;

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

	public sealed class ThrowWhenIteratingTwiceEnumerable : IAsyncEnumerable<int>
	{
		private bool _isEnumerated;

		#region IAsyncEnumerable<int> Members

		/// <inheritdoc />
		public IAsyncEnumerator<int> GetAsyncEnumerator(
			CancellationToken cancellationToken = default)
			=> GetAsyncEnumerator();

		#endregion

		public async IAsyncEnumerator<int> GetAsyncEnumerator()
		{
			if (_isEnumerated)
			{
				Fail.Test("The enumerable was enumerated twice!");
			}

			await Task.Yield();
			_isEnumerated = true;
			yield return 1;
		}
	}
}
#endif
