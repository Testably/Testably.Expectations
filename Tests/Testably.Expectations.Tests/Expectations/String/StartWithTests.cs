using Xunit;

namespace Testably.Expectations.Tests.Expectations.String;

public sealed class StartWithTests
{
	[Fact]
	public void MatchingStart_ShouldNotThrow()
	{
		string sut = "foo";

		Expect.That(sut, Should.Start.With("fo"));
	}

	[Fact]
	public void NotMatchingStart_ShouldThrow()
	{
		string sut = "foo";

		void Act()
			=> Expect.That(sut, Should.Start.With(" fo"));

		Expect.That(Act,
			Should.Throw.Exception().Which(
				p => p.Message,
				Should.Be.EqualTo("Expected sut to start with ' fo', but found 'foo'.")));

	}
}
