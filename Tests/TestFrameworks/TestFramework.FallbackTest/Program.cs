using Testably.Expectations;

namespace TestFramework.FallbackTest;

internal class Program
{
	private static async Task<int> Main()
	{
		try
		{
			await Expect.That(true).Should().IsFalse();
		}
		catch (FailException)
		{
			return 1;
		}

		return 2;
	}
}
