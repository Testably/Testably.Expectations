using Xunit;

namespace Testably.Expectations.Tests.Expectations.String;

public sealed class ContainSubstringTests
{
	[Fact]
	public void MatchingContain_ShouldNotThrow()
	{
		string sut = "foobar";

		Expect.That(sut, Should.Contain.Substring("oo"));
	}

	[Fact]
	public void NotMatchingContain_ShouldThrow()
	{
		string sut = "foo";

		void Act()
			=> Expect.That(sut, Should.Contain.Substring("o2"));

		Expect.That(Act,
			Should.Throw.Exception().Which(
				p => p.Message,
				Should.Be.EqualTo("Expected sut to contain \"o2\", but found \"foo\".")));
	}
}
