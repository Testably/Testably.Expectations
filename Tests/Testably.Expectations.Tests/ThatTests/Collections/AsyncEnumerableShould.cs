﻿#if NET6_0_OR_GREATER
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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

	public static async IAsyncEnumerable<int> ToDelayedAsyncEnumerable(
		int[] items,
		[EnumeratorCancellation] CancellationToken cancellationToken = default)
	{
		foreach (int item in items)
		{
			await Task.Delay(TimeSpan.FromMilliseconds(100), cancellationToken);
			if (cancellationToken.IsCancellationRequested)
			{
				break;
			}

			yield return item;
		}
	}

	/// <summary>
	///     Returns an <see cref="IAsyncEnumerable{T}" /> with incrementing numbers, starting with 0, which cancels the
	///     <paramref name="cancellationTokenSource" /> after <paramref name="cancelAfter" /> iteration.
	/// </summary>
	private static async IAsyncEnumerable<int> GetCancellingAsyncEnumerable(
		int cancelAfter,
		CancellationTokenSource cancellationTokenSource,
		[EnumeratorCancellation] CancellationToken cancellationToken = default)
	{
		int index = 0;
		while (!cancellationToken.IsCancellationRequested)
		{
			if (index == cancelAfter)
			{
				cancellationTokenSource.Cancel();
			}

			await Task.Yield();
			yield return index++;
		}
	}

	public sealed class ThrowWhenIteratingTwiceAsyncEnumerable : IAsyncEnumerable<int>
	{
		private bool _isEnumerated;

		#region IAsyncEnumerable<int> Members

		public async IAsyncEnumerator<int> GetAsyncEnumerator(
			CancellationToken cancellationToken = default)
		{
			if (_isEnumerated)
			{
				Fail.Test("The enumerable was enumerated twice!");
			}

			await Task.Yield();
			_isEnumerated = true;
			yield return 1;
		}

		#endregion
	}
}
#endif
