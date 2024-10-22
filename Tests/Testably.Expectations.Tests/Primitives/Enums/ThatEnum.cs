namespace Testably.Expectations.Tests.Primitives.Enums;

public sealed partial class ThatEnum
{
	[Flags]
	public enum MyColors
	{
		Blue = 1,
		Green = 2,
		Yellow = 4,
		Red = 8
	}
}
