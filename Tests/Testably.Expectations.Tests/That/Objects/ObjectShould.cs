namespace Testably.Expectations.Tests.That.Objects;

public sealed partial class ObjectShould
{
	private class OtherBase
	{
		public int Value { get; set; }
	}

	private class Other : OtherBase
	{
	}
}
