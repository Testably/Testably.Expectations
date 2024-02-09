using Xunit;

namespace Testably.Expectations.Tests.Expectations.String;

public sealed class EndWithTests
{
	[Fact]
	public void MatchingEnd_ShouldNotThrow()
	{
		string sut = "foo";

		Expect.That(sut, Should.End.With("oo"));
	}

	[Fact]
	public void NotMatchingEnd_ShouldThrow()
	{
		string sut = "foo";

		void Act()
			=> Expect.That(sut, Should.End.With("oo1"));

		Expect.That(Act,
			Should.Throw.Exception().Which(
				p => p.Message,
				Should.Be.EqualTo("Expected sut to end with 'oo1', but found 'foo'.")));
	}
}
