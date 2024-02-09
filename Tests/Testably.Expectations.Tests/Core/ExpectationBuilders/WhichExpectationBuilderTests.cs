using System;
using Testably.Expectations.Tests.TestHelpers;
using Xunit;

namespace Testably.Expectations.Tests.Core.ExpectationBuilders;

public sealed class WhichExpectationBuilderTests
{
	[Fact]
	public void ShouldAccessCorrectPropertyValue()
	{
		Dummy sut = new()
		{
			Value = "foo"
		};

		Expect.That(sut,
			Should.Be.AMappedTest<Dummy>().Which(p => p.Value, Should.Be.EqualTo("foo")));
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
