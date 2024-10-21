using System.Collections.Generic;

namespace Testably.Expectations.Tests.TestHelpers;

internal static class Factory
{
	/// <summary>
	///     Returns an infinite <see cref="IEnumerable{T}" /> of fibonacci numbers.
	/// </summary>
	public static IEnumerable<int> GetFibonacciNumbers()
	{
		int a = 0, b = 1;

		do
		{
			yield return b;
			(a, b) = (b, a + b);
		} while (true);
	}
}
