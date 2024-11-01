namespace Testably.Expectations.Tests.ThatTests.Collections;

public partial class QuantifiedCollectionResult
{
	public class MyClass(int Value);

	public class SubClass(int value) : MyClass(value);

	public class OtherClass(int Value);
}
