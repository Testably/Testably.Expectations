namespace Testably.Expectations.Tests.Primitives.Objects;

public sealed partial class ThatObject
{
	private class OtherBase
	{
		public int Value { get; set; }
	}

	private class Other : OtherBase
	{

	}
}
