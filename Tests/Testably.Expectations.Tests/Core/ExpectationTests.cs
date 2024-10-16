//using Testably.Expectations.Tests.TestHelpers;
//using Xunit;

//namespace Testably.Expectations.Tests.Core;

//public sealed class ExpectationTests
//{
//	[Fact]
//	public void And_ShouldFailWhenAnyArgumentFails()
//	{
//		void Act1()
//			=> ExpectVoid.That(true, Should.Be.AnExpectation(false).And().Be.AnExpectation(true));

//		void Act2()
//			=> ExpectVoid.That(true, Should.Be.AnExpectation(true).And().Be.AnExpectation(false));

//		ExpectVoid.That(Act1, Should.Throw.Exception());
//		ExpectVoid.That(Act2, Should.Throw.Exception());
//	}

//	[Fact]
//	public void And_ShouldRequireBothArgumentsToSucceed()
//	{
//		ExpectVoid.That(true, Should.Be.AnExpectation(true).And().Be.AnExpectation(true));
//	}

//	[Fact]
//	public void Or_ShouldFailWhenBothArgumentsFail()
//	{
//		void Act()
//			=> ExpectVoid.That(true, Should.Be.AnExpectation(false).Or().Be.AnExpectation(false));

//		ExpectVoid.That(Act, Should.Throw.Exception());
//	}

//	[Fact]
//	public void Or_ShouldRequireAnyArgumentToSucceed()
//	{
//		ExpectVoid.That(true, Should.Be.AnExpectation(false).Or().Be.AnExpectation(true));
//		ExpectVoid.That(true, Should.Be.AnExpectation(true).Or().Be.AnExpectation(false));
//	}

//	[Fact]
//	public void ToString_ShouldStartWithExpect()
//	{
//		var sut = Should.Be.AnExpectation(false);

//		var result = sut.ToString();

//		ExpectVoid.That(result, Should.Start.With("Expect "));
//	}
//}
