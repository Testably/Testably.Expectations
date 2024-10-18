//using System;
//using Testably.Expectations.Core;
//using Xunit;

//namespace Testably.Expectations.Tests.Core.Nodes;

//public sealed class ExpectationNodeTests
//{
//	[Fact]
//	public async Task CanOnlyAddASingleExpectation()
//	{
//		ShouldBe shouldBe = Should.Be;
//		shouldBe.True();

//		void Act()
//			=> shouldBe.True();

//		await Expect.That(Act,
//			Should.Throw.TypeOf<InvalidOperationException>().WhichMessage(
//				Should.Be.EqualTo(
//					"You have to specify how to combine the expectations! Use `And()` or `Or()` in between adding expectations.")));
//	}

//	[Fact]
//	public async Task WhenTypeDoesNotMatch_ShouldThrowInvalidOperationException()
//	{
//		int value = 4;

//		void Act()
//			=> await Expect.That(value, Should.Be.True().And().Be.GreaterThan(1));

//		await Expect.That(Act,
//			Should.Throw.TypeOf<InvalidOperationException>().WhichMessage(
//				Should.Be.EqualTo(
//					"The expectation does not support Int32 4")));
//	}
//}


