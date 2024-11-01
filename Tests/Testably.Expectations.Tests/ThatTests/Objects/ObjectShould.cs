namespace Testably.Expectations.Tests.ThatTests.Objects;

public sealed partial class ObjectShould
{
	private class MyBaseClass
	{
		public int Value { get; set; }
	}

	private class MyClass : MyBaseClass;

	private class OtherClass;
}
