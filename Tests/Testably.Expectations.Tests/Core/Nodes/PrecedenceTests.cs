//using Testably.Expectations.Tests.TestHelpers;
//using Xunit;
//using Xunit.Sdk;

//namespace Testably.Expectations.Tests.Core.Nodes;

//public sealed class PrecedenceTests
//{
//	private class Dummy
//	{
//		public int Value { get; }
//	}

//	public sealed class OrOverAnd
//	{
//		[Fact]
//		public void F_and_T_or_F_ShouldFail()
//		{
//			Dummy sut = new();

//			void Act()
//				=> ExpectVoid.That(sut,
//					Should.Be.AMappedTest<Dummy>("to map")
//						.Which(p => p.Value, Should.Be.AFailedTest("to be A", "found X")).And()
//						.Which(p => p.Value, Should.Be.ASuccessfulTest("to be B")).Or()
//						.Which(p => p.Value, Should.Be.AFailedTest("to be C", "found Y")));

//			Assert.Throws<XunitException>(Act);
//			ExpectVoid.That(Act, Should.Throw.Exception().WhichMessage(
//				Should.Be.EqualTo(
//					"Expected sut .Value to be A and .Value to be B or .Value to be C, but found X and found Y.")));
//		}

//		[Fact]
//		public void F_and_T_or_T_ShouldSucceed()
//		{
//			Dummy sut = new();

//			void Act()
//				=> ExpectVoid.That(sut,
//					Should.Be.AMappedTest<Dummy>("to map")
//						.Which(p => p.Value, Should.Be.AFailedTest("to be A", "found X")).And()
//						.Which(p => p.Value, Should.Be.ASuccessfulTest("to be B")).Or()
//						.Which(p => p.Value, Should.Be.ASuccessfulTest("to be C")));

//			ExpectVoid.That(Act, Should.Not.Throw.Exception());
//		}

//		[Fact]
//		public void F_or_T_and_F_ShouldFail()
//		{
//			Dummy sut = new();

//			void Act()
//				=> ExpectVoid.That(sut,
//					Should.Be.AMappedTest<Dummy>("to map")
//						.Which("Value", Should.Be.AFailedTest("to be A", "found X")).Or()
//						.Which("Value", Should.Be.ASuccessfulTest("to be B")).And()
//						.Which("Value", Should.Be.AFailedTest("to be C", "found Y")));

//			ExpectVoid.That(Act, Should.Throw.Exception().WhichMessage(
//				Should.Be.EqualTo(
//					"Expected sut .Value to be A or .Value to be B and .Value to be C, but found X and found Y.")));
//		}

//		[Fact]
//		public void T_and_F_or_F_ShouldFail()
//		{
//			Dummy sut = new();

//			void Act()
//				=> ExpectVoid.That(sut,
//					Should.Be.AMappedTest<Dummy>("to map")
//						.Which("Value", Should.Be.ASuccessfulTest("to be A")).And()
//						.Which("Value", Should.Be.AFailedTest("to be B", "found X")).Or()
//						.Which("Value", Should.Be.AFailedTest("to be C", "found Y")));

//			ExpectVoid.That(Act, Should.Throw.Exception().WhichMessage(
//				Should.Be.EqualTo(
//					"Expected sut .Value to be A and .Value to be B or .Value to be C, but found X and found Y.")));
//		}

//		[Fact]
//		public void T_and_F_or_T_ShouldSucceed()
//		{
//			Dummy sut = new();

//			void Act()
//				=> ExpectVoid.That(sut,
//					Should.Be.AMappedTest<Dummy>("to map")
//						.Which("Value", Should.Be.ASuccessfulTest("to be A")).And()
//						.Which("Value", Should.Be.AFailedTest("to be B", "found X")).Or()
//						.Which("Value", Should.Be.ASuccessfulTest("to be C")));

//			ExpectVoid.That(Act, Should.Not.Throw.Exception());
//		}

//		[Fact]
//		public void T_or_T_and_F_ShouldSucceed()
//		{
//			Dummy sut = new();

//			void Act()
//				=> ExpectVoid.That(sut,
//					Should.Be.AMappedTest<Dummy>("to map")
//						.Which("Value", Should.Be.ASuccessfulTest("to be A")).Or()
//						.Which("Value", Should.Be.ASuccessfulTest("to be B")).And()
//						.Which("Value", Should.Be.AFailedTest("to be C", "found X")));

//			ExpectVoid.That(Act, Should.Not.Throw.Exception());
//		}
//	}
//}


