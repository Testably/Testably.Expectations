using BenchmarkDotNet.Attributes;
using FluentAssertions;
using FluentAssertions.Primitives;
using TUnit.Assertions;
using TUnit.Assertions.Extensions;

namespace Testably.Expectations.Benchmarks;

[MemoryDiagnoser]
public class HappyCaseForString
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
