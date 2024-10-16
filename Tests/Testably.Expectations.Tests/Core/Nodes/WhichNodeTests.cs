//using Testably.Expectations.Tests.TestHelpers;
//using Xunit;
//using Xunit.Sdk;

//namespace Testably.Expectations.Tests.Core.Nodes;

//public sealed class WhichNodeTests
//{
//	[Fact]
//	public void CombineMultipleWhich_ShouldEvaluateBothExpectations()
//	{
//		Dummy sut = new()
//		{
//			Inner = new Dummy.Nested
//			{
//				Id = 1
//			},
//			Value = "foo"
//		};

//		void Act()
//			=> ExpectVoid.That(sut,
//				Should.Be.AMappedTest<Dummy>("to map")
//					.Which(p => p.Inner!.Id, Should.Be.EqualTo(1)).And()
//					.Which(p => p.Value, Should.Start.With("other-value")).And()
//					.Which(p => p.Value, Should.End.With("oo")));

//		ExpectVoid.That(Act, Should.Throw.TypeOf<XunitException>().WhichMessage(
//			Should.Be.EqualTo(
//				"Expected sut .Inner.Id to be equal to 1 and .Value to start with \"other-value\" and .Value to end with \"oo\", but found \"foo\".")));
//	}

//	[Fact]
//	public void ShouldAccessCorrectPropertyValue()
//	{
//		Dummy sut = new()
//		{
//			Value = "foo"
//		};

//		ExpectVoid.That(sut,
//			Should.Be.AMappedTest<Dummy>("to map").Which(p => p.Value, Should.Start.With("f")));
//	}

//	[Fact]
//	public void ShouldIncludeCorrectPropertyPathInMessage()
//	{
//		Dummy? sut = new()
//		{
//			Value = "foo"
//		};

//		void Act()
//			=> ExpectVoid.That(sut,
//				Should.Be.AMappedTest<Dummy>("to map")
//					.Which(p => p.Value, Should.Be.EqualTo("foo2")));

//		ExpectVoid.That(Act, Should.Throw.Exception().WhichMessage(
//			Should.Be.EqualTo("Expected sut .Value to be equal to \"foo2\", but found \"foo\".")));
//	}

//	[Fact]
//	public void WhenReferringToANestedProperty_ShouldAccessCorrectPropertyValue()
//	{
//		Dummy sut = new()
//		{
//			Inner = new Dummy.Nested
//			{
//				Id = 1
//			},
//			Value = "foo"
//		};

//		ExpectVoid.That(sut,
//			Should.Be.AMappedTest<Dummy>("to map").Which(p => p.Inner!.Id, Should.Be.EqualTo(1)));
//	}

//	[Fact]
//	public void WhenReferringToANestedProperty_ShouldIncludeCorrectPropertyPathInMessage()
//	{
//		Dummy? sut = new()
//		{
//			Inner = new Dummy.Nested
//			{
//				Id = 1
//			},
//			Value = "foo"
//		};

//		void Act()
//			=> ExpectVoid.That(sut,
//				Should.Be.AMappedTest<Dummy>("to map")
//					.Which(p => p.Inner!.Id, Should.Be.EqualTo(2)));

//		ExpectVoid.That(Act, Should.Throw.Exception().WhichMessage(
//			Should.Be.EqualTo("Expected sut .Inner.Id to be equal to 2, but found 1.")));
//	}

//	private class Dummy
//	{
//		public Nested? Inner { get; set; }
//		public string? Value { get; set; }

//		public class Nested
//		{
//			public int Id { get; set; }
//			#pragma warning disable CS0649
//			public int Field;
//			#pragma warning restore CS0649

//			public int Method() => Id + 1;
//		}
//	}
//}
