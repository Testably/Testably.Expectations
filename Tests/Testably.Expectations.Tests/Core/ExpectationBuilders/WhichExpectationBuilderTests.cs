using System;
using Testably.Expectations.Tests.TestHelpers;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests.Core.ExpectationBuilders;

public sealed class WhichExpectationBuilderTests
{

	[Fact]
	public void __TODO()
	{
		Dummy sut = new();

		var expectation = Should.Be.AMappedTest<Dummy>()
			.Which(p => p.Value, Should.Be.AFailedTest()).Or()
			.Which(p => p.Value, Should.Be.ASuccessfulTest()).And()
			.Which(p => p.Value, Should.Be.AFailedTest());
		var test = expectation.ToString();

		Assert.Equal("Expect Map(Dummy -> Dummy) .Value Expect failure OR .Value Expect success AND .Value Expect failure", test);
	}

	[Fact]
	public void CombineMultipleWhich_ShouldEvaluateBothExpectations()
	{
		Dummy sut = new()
		{
			Inner = new Dummy.Nested
			{
				Id = 1
			},
			Value = "foo"
		};

		void Act()
			=> Expect.That(sut,
				Should.Be.AMappedTest<Dummy>()
					.Which(p => p.Inner!.Id, Should.Be.EqualTo(1)).Or()
					.Which(p => p.Value, Should.Start.With("other-value")).Or()
					.Which(p => p.Value, Should.End.With("oo")));

		Expect.That(Act, Should.Throw.TypeOf<XunitException>().WhichMessage(
			Should.Be.EqualTo("Expected sut .Value to be equal to other-value, but found foo.")));
	}

	[Fact]
	public void PrecedenceTest_T_or_T_and_F_ShouldSucceed()
	{
		Dummy sut = new();

		void Act()
			=> Expect.That(sut,
				Should.Be.AMappedTest<Dummy>()
					.Which(p => p.Value, Should.Be.ASuccessfulTest()).Or()
					.Which(p => p.Value, Should.Be.ASuccessfulTest()).And()
					.Which(p => p.Value, Should.Be.AFailedTest()));

		Expect.That(Act, Should.Not.Throw.Exception());
	}

	[Fact]
	public void PrecedenceTest_T_and_F_or_T_ShouldSucceed()
	{
		Dummy sut = new();

		void Act()
			=> Expect.That(sut,
				Should.Be.AMappedTest<Dummy>()
					.Which(p => p.Value, Should.Be.ASuccessfulTest()).And()
					.Which(p => p.Value, Should.Be.AFailedTest()).Or()
					.Which(p => p.Value, Should.Be.ASuccessfulTest()));

		Expect.That(Act, Should.Not.Throw.Exception());
	}

	[Fact]
	public void PrecedenceTest_F_and_T_or_T_ShouldSucceed()
	{
		Dummy sut = new();

		void Act()
			=> Expect.That(sut,
				Should.Be.AMappedTest<Dummy>()
					.Which(p => p.Value, Should.Be.AFailedTest()).And()
					.Which(p => p.Value, Should.Be.ASuccessfulTest()).Or()
					.Which(p => p.Value, Should.Be.ASuccessfulTest()));

		Expect.That(Act, Should.Not.Throw.Exception());
	}

	[Fact]
	public void PrecedenceTest_F_or_T_and_F_ShouldFail()
	{
		Dummy sut = new();

		void Act()
			=> Expect.That(sut,
				Should.Be.AMappedTest<Dummy>()
					.Which(p => p.Value, Should.Be.AFailedTest()).Or()
					.Which(p => p.Value, Should.Be.ASuccessfulTest()).And()
					.Which(p => p.Value, Should.Be.AFailedTest()));

		Expect.That(Act, Should.Throw.Exception().WhichMessage(Should.Start.With("Expected")));
	}

	[Fact]
	public void PrecedenceTest_T_and_F_or_F_ShouldFail()
	{
		Dummy sut = new();

		void Act()
			=> Expect.That(sut,
				Should.Be.AMappedTest<Dummy>()
					.Which(p => p.Value, Should.Be.ASuccessfulTest()).And()
					.Which(p => p.Value, Should.Be.AFailedTest()).Or()
					.Which(p => p.Value, Should.Be.AFailedTest()));

		Expect.That(Act, Should.Throw.Exception().WhichMessage(Should.Start.With("Expected")));
	}

	[Fact]
	public void PrecedenceTest_F_and_T_or_F_ShouldFail()
	{
		Dummy sut = new();

		void Act()
			=> Expect.That(sut,
				Should.Be.AMappedTest<Dummy>()
					.Which(p => p.Value, Should.Be.AFailedTest()).And()
					.Which(p => p.Value, Should.Be.ASuccessfulTest()).Or()
					.Which(p => p.Value, Should.Be.AFailedTest()));

		Expect.That(Act, Should.Throw.Exception().WhichMessage(Should.Start.With("Expected")));
	}

	[Fact]
	public void ShouldAccessCorrectPropertyValue()
	{
		Dummy sut = new()
		{
			Value = "foo"
		};

		Expect.That(sut,
			Should.Be.AMappedTest<Dummy>().Which(p => p.Value, Should.Start.With("f")));
	}

	[Fact]
	public void ShouldIncludeCorrectPropertyPathInMessage()
	{
		Dummy? sut = new()
		{
			Value = "foo"
		};

		void Act()
			=> Expect.That(sut,
				Should.Be.AMappedTest<Dummy>().Which(p => p.Value, Should.Be.EqualTo("foo2")));

		Expect.That(Act, Should.Throw.Exception().WhichMessage(
			Should.Be.EqualTo("Expected sut .Value to be equal to foo2, but found foo.")));
	}

	[Fact]
	public void WhenExpressionRefersToAField_ShouldThrowArgumentException()
	{
		Dummy? sut = new();

		void Act()
			=> Expect.That(sut,
				Should.Be.AMappedTest<Dummy>()
					.Which(p => p.Inner!.Field, Should.Be.ASuccessfulTest()));

		Expect.That(Act, Should.Throw.TypeOf<ArgumentException>().WhichMessage(
			Should.Be.EqualTo("Expression 'p.Inner.Field' does not refer to a property.")));
	}

	[Fact]
	public void WhenExpressionRefersToAMethod_ShouldThrowArgumentException()
	{
		Dummy? sut = new();

		void Act()
			=> Expect.That(sut,
				Should.Be.AMappedTest<Dummy>()
					.Which(p => p.Inner!.Method(), Should.Be.ASuccessfulTest()));

		Expect.That(Act, Should.Throw.TypeOf<ArgumentException>().WhichMessage(
			Should.Be.EqualTo("Expression 'p.Inner.Method()' does not refer to a property.")));
	}

	[Fact]
	public void WhenReferringToANestedProperty_ShouldAccessCorrectPropertyValue()
	{
		Dummy sut = new()
		{
			Inner = new Dummy.Nested
			{
				Id = 1
			},
			Value = "foo"
		};

		Expect.That(sut,
			Should.Be.AMappedTest<Dummy>().Which(p => p.Inner!.Id, Should.Be.EqualTo(1)));
	}

	[Fact]
	public void WhenReferringToANestedProperty_ShouldIncludeCorrectPropertyPathInMessage()
	{
		Dummy? sut = new()
		{
			Inner = new Dummy.Nested
			{
				Id = 1
			},
			Value = "foo"
		};

		void Act()
			=> Expect.That(sut,
				Should.Be.AMappedTest<Dummy>().Which(p => p.Inner!.Id, Should.Be.EqualTo(2)));

		Expect.That(Act, Should.Throw.Exception().WhichMessage(
			Should.Be.EqualTo("Expected sut .Inner.Id to be equal to 2, but found 1.")));
	}

	private class Dummy
	{
		public Nested? Inner { get; set; }
		public string? Value { get; set; }

		public class Nested
		{
			public int Id { get; set; }
			#pragma warning disable CS0649
			public int Field;
			#pragma warning restore CS0649

			public int Method() => Id + 1;
		}
	}
}
