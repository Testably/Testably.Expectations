using System;
using Testably.Expectations.Expectations;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Testably.Expectations.Tests;

public sealed class DummyTests
{
	#region Test Setup

	private readonly ITestOutputHelper testOutputHelper;

	public DummyTests(ITestOutputHelper testOutputHelper)
	{
		this.testOutputHelper = testOutputHelper;
	}

	#endregion

	[Fact]
	public void False()
	{
		bool sut = false;

		Expect.That(sut, Should.Be.False());
	}

	[Fact]
	public void False_Message()
	{
		bool fo2klsif = true;

		Action act = () => { Expect.That(fo2klsif, Should.Be.False()); };

		XunitException exception = Assert.Throws<XunitException>(act);
		Assert.Equal($"Expected {nameof(fo2klsif)} to be False, but found True.",
			exception.Message);
	}

	[Fact]
	public void IsNull_ShouldNotThrowOnNull()
	{
		Dummy? nullDummy = null;
		string? sut2 = "foo";

		Expect.That(sut2, Should.Start.With("f").And().End.With("o"));
		Expect.That(nullDummy, Should.Be.Null());
	}

	[Fact]
	public void IsNull_ShouldThrowOnNotNull()
	{
		Dummy? nullDummy = new()
		{
			Id = 2,
			Value2 = "fog"
		};

		Action act = () => { Expect.That(nullDummy, Should.Be.Null()); };

		Expect.That(nullDummy, Should.Be.OfType<Dummy>()
			.Which(_1 => _1.Id, Should.Be.EqualTo(2)).And()
			.Which(_1 => _1.Value2, Should.Start.With("f").And()
				.End.With("g")));

		XunitException exception = Assert.Throws<XunitException>(act);
		Assert.StartsWith($"Expected {nameof(nullDummy)} to be null, but found", exception.Message);
	}

	[Fact]
	public void Throws2()
	{
		Action sut = () => throw new ArgumentException("foo");

		Expect.That(sut, Should.Throw.TypeOf<ArgumentException>()
			.Which(_ => _.Message, Should.Start.With("f").And().End.With("o")));
	}

	[Fact]
	public void True()
	{
		bool sut = true;

		Expect.That(sut, Should.Be.True());
	}

	[Fact]
	public void True_Message()
	{
		bool sut2 = false;

		Action act = () => { Expect.That(sut2, Should.Be.True()); };

		XunitException exception = Assert.Throws<XunitException>(act);
		Assert.Equal($"Expected {nameof(sut2)} to be True, but found False.", exception.Message);
	}

	private class Dummy
	{
		public int Id { get; set; }
		public string? Value2 { get; set; }
	}
}
