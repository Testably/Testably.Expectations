using BenchmarkDotNet.Attributes;
using FluentAssertions;
using FluentAssertions.Primitives;
using TUnit.Assertions;
using TUnit.Assertions.Extensions;

namespace Testably.Expectations.Benchmarks;

[MemoryDiagnoser]
public class SpecialBenchmark
{
	private class Foo
	{
		public string GetValue(int input)
		{
			return $"{input}-";
		}
	}
	private class Foo2(Func<int, string> getValue)
	{
		public string GetValue(int input)
		{
			return getValue(input);
		}
	}

	[Benchmark]
	public void WithStruct()
	{
		for (int i=0;i<100;i++)
		{
			_ = new Foo().GetValue(i);
		}
	}

	[Benchmark]
	public void WithFunc()
	{
		for (int i=0;i<100;i++)
		{
			_ = new Foo2(s => $"{s}-").GetValue(i);
		}
	}
}
