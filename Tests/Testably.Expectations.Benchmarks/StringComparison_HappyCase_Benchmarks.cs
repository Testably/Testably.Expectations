using BenchmarkDotNet.Attributes;
using FluentAssertions;
using FluentAssertions.Primitives;

namespace Testably.Expectations.Benchmarks;

[MemoryDiagnoser]
public class StringComparison_HappyCase_Benchmarks
{
	private readonly string _expected = "foo";
	private readonly string _subject = "foo";

	[Benchmark]
	public AndConstraint<StringAssertions> FluentAssertions()
		=> _subject.Should().Be(_expected);

	[Benchmark]
	public async Task<string?> Testably_Expectations()
		=> await Expect.That(_subject).Should().Be(_expected);

	[Benchmark]
	public async Task<string?> TUnit()
		=> await Assert.That(_subject).IsEqualTo(_expected);
}
