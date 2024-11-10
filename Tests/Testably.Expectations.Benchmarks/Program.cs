using BenchmarkDotNet.Running;
using Testably.Expectations.Benchmarks;

BenchmarkRunner.Run<BoolComparison_HappyCase_Benchmarks>();
BenchmarkRunner.Run<StringComparison_HappyCase_Benchmarks>();
