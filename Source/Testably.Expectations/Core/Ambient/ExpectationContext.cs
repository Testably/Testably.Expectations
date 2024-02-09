using System.Threading;

namespace Testably.Expectations.Core.Ambient;

internal class ExpectationContext
{
	private static readonly AsyncLocal<ExpectationContext> CurrentScope = new();

	public static ExpectationContext Current
	{
		get
		{
			ExpectationContext? context = CurrentScope.Value;
			if (context == null)
			{
				context = new ExpectationContext();
				CurrentScope.Value = context;
			}

			return context;
		}
	}
}
