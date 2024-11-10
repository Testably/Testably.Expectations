using Testably.Expectations.Results;

namespace Testably.Expectations.Tests.Results;

public class ExpectationTests
{
	[Fact]
	public async Task Equals_ShouldThrowNotSupportedException()
	{
		Expectation sut = That(true).Should().BeTrue();

		bool Act() => sut.Equals(That(true).Should().BeTrue());

		await That(Act).Should().Throw<NotSupportedException>();
	}

	[Fact]
	public async Task GetHashCode_ShouldThrowNotSupportedException()
	{
		Expectation sut = That(true).Should().BeTrue();

		int Act() => sut.GetHashCode();

		await That(Act).Should().Throw<NotSupportedException>();
	}
}
