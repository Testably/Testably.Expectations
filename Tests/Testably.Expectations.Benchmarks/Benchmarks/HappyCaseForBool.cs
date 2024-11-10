using BenchmarkDotNet.Attributes;
using FluentAssertions;
using FluentAssertions.Primitives;

namespace Testably.Expectations.Benchmarks;

[MemoryDiagnoser]
public class HappyCaseForBool
{
	private readonly bool _subject = true;

	[Benchmark]
	public AndConstraint<BooleanAssertions> FluentAssertions()
		=> _subject.Should().BeTrue();

	[Benchmark]
	public async Task<bool> Testably_Expectations()
		=> await Expect.That(_subject).Should().BeTrue();

	[Benchmark]
	public async Task<bool> TUnit()
		=> await Assert.That(_subject).IsTrue();
}
