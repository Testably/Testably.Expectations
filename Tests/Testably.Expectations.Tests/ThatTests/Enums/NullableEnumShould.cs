namespace Testably.Expectations.Tests.ThatTests.Enums;

public sealed partial class NullableEnumShould
{
	[Flags]
	public enum MyColors
	{
		Blue = 1 << 0,
		Green = 1 << 1,
		Yellow = 1 << 2,
		Red = 1 << 3
	}

	public enum MyNumbers
	{
		One = 1,
		Two = 2,
		Three = 3
	}
}
