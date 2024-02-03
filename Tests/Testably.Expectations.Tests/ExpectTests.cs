using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Testably.Expectations.Tests;

public sealed class ExpectTests
{
	private readonly ITestOutputHelper testOutputHelper;

	public ExpectTests(ITestOutputHelper testOutputHelper)
	{
		this.testOutputHelper = testOutputHelper;
	}

	[Fact]
	public void IsNull_ShouldNotThrowOnNull()
	{
		Dummy? nullDummy = null;
		string? sut2 = "foo";

		Expect.That(sut2, Does.StartWith("f").And().EndsWith("o"));
		Expect.That(nullDummy, Is.Null());
	}

	[Fact]
	public void IsNull_ShouldThrowOnNotNull()
	{
		Dummy? nullDummy = new Dummy();

		var act = () => { Expect.That(nullDummy, Is.Null<Dummy>()); };

		var exception = Assert.Throws<XunitException>(act);
		Assert.StartsWith($"Expected {nameof(nullDummy)} to be null, but found", exception.Message);
	}

	[Fact]
	public void True_Message()
	{
		var sut2 = false;

		var act = () => { Expect.That(sut2, Is.True); };

		var exception = Assert.Throws<XunitException>(act);
		Assert.Equal($"Expected {nameof(sut2)} to be True, but found False.", exception.Message);
	}

	[Fact]
	public void False_Message()
	{
		var fo2klsif = true;

		var act = () => { Expect.That(fo2klsif, Is.False); };

		var exception = Assert.Throws<XunitException>(act);
		Assert.Equal($"Expected {nameof(fo2klsif)} to be False, but found True.", exception.Message);
	}

	[Fact]
	public void True()
	{
		var sut = true;

		Expect.That(sut, Is.True);
	}

	[Fact]
	public void False()
	{
		var sut = false;

		Expect.That(sut, Is.False);
	}

	[Fact]
	public void Throws()
	{
		Action sut = () => throw new ArgumentException("foo");

		//Expect.That(sut, _ => _.Throws<ArgumentException>());
	}

	private class Dummy
	{
		public int Id { get; set; }
	}
}
