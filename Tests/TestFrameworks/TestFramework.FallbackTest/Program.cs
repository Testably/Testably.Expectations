using Testably.Expectations;

namespace TestFramework.FallbackTest;

internal class Program
{
	private static int Main()
	{
		try
		{
			Expect.That(true).IsFalse();
		}
		catch (ExpectationException)
		{
			return 1;
		}

		return 2;
	}
}
