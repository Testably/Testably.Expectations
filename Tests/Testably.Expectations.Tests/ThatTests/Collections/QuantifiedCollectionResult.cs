using System.Collections.Generic;

namespace Testably.Expectations.Tests.ThatTests.Collections;

public partial class QuantifiedCollectionResult
{
	public class MyClass(int Value);

	public class SubClass(int Value) : MyClass(Value);

	public class OtherClass(int Value);
}
