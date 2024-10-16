//using Testably.Expectations.Tests.TestHelpers;
//using Xunit;

//namespace Testably.Expectations.Tests.Core;

//public sealed class NullableExpectationTests
//{
//	[Fact]
//	public void And_ShouldFailWhenAnyArgumentFails()
//	{
//		void Act1()
//			=> ExpectVoid.That(true,
//				Should.Be.ANullableExpectation(false).And().Be.ANullableExpectation(true));

//		void Act2()
//			=> ExpectVoid.That(true,
//				Should.Be.ANullableExpectation(true).And().Be.ANullableExpectation(false));

//		ExpectVoid.That(Act1, Should.Throw.Exception());
//		ExpectVoid.That(Act2, Should.Throw.Exception());
//	}

//	[Fact]
//	public void And_ShouldRequireBothArgumentsToSucceed()
//	{
//		ExpectVoid.That(true, Should.Be.ANullableExpectation(true).And().Be.ANullableExpectation(true));
//	}

//	[Fact]
//	public void Or_ShouldFailWhenBothArgumentsFail()
//	{
//		void Act()
//			=> ExpectVoid.That(true,
//				Should.Be.ANullableExpectation(false).Or().Be.ANullableExpectation(false));

//		ExpectVoid.That(Act, Should.Throw.Exception());
//	}

//	[Fact]
//	public void Or_ShouldRequireAnyArgumentToSucceed()
//	{
//		ExpectVoid.That(true, Should.Be.ANullableExpectation(false).Or().Be.ANullableExpectation(true));
//		ExpectVoid.That(true, Should.Be.ANullableExpectation(true).Or().Be.ANullableExpectation(false));
//	}

//	[Fact]
//	public void ToString_ShouldStartWithExpect()
//	{
//		var sut = Should.Be.ANullableExpectation(false);

//		var result = sut.ToString();

//		ExpectVoid.That(result, Should.Start.With("Expect "));
//	}
//}


