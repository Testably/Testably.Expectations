using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Nodes;
using Testably.Expectations.Internal.Tests.TestHelpers;

namespace Testably.Expectations.Internal.Tests.Core.Nodes;

public class MappingNodeTests
{
	[Fact]
	public async Task CombineResults_OnlyLeftFailure_ShouldReturnLeftFailure()
	{
		MappingNode<int, int> node = new(
			PropertyAccessor<int, int>.FromFunc(i => i, " prop "));
		ConstraintResult.Failure left = new("expect1", "foo");
		ConstraintResult.Success right = new("expect2");

		ConstraintResult combined = node.CombineResults(left, right);

		await That(combined).Should().Be<ConstraintResult.Failure>()
			.Which(f => f.ExpectationText).Should(f => f.Be("expect1 prop expect2"))
			.Which(f => f.ResultText).Should(f => f.Be("foo"));
	}

	[Fact]
	public async Task CombineResults_OnlyRightFailure_ShouldReturnLeftFailure()
	{
		MappingNode<int, int> node = new(
			PropertyAccessor<int, int>.FromFunc(i => i, " prop "));
		ConstraintResult.Success left = new("expect1");
		ConstraintResult.Failure right = new("expect2", "foo");

		ConstraintResult combined = node.CombineResults(left, right);

		await That(combined).Should().Be<ConstraintResult.Failure>()
			.Which(f => f.ExpectationText).Should(f => f.Be("expect1 prop expect2"))
			.Which(f => f.ResultText).Should(f => f.Be("foo"));
	}

	[Fact]
	public async Task CombineResults_ShouldIncludeAndAsSeparator()
	{
		MappingNode<int, int> node = new(
			PropertyAccessor<int, int>.FromFunc(i => i, ""));
		ConstraintResult.Failure left = new("expect1", "foo");
		ConstraintResult.Failure right = new("expect2", "bar");

		ConstraintResult combined = node.CombineResults(left, right);

		await That(combined).Should().Be<ConstraintResult.Failure>()
			.Which(f => f.ResultText).Should(f => f.Be("foo and bar"));
	}

	[Fact]
	public async Task CombineResults_ShouldOnlyIncludeDistinctFailures()
	{
		MappingNode<int, int> node = new(
			PropertyAccessor<int, int>.FromFunc(i => i, " prop "));
		ConstraintResult.Failure left = new("expect1", "foo");
		ConstraintResult.Failure right = new("expect2", "foo");

		ConstraintResult combined = node.CombineResults(left, right);

		await That(combined).Should().Be<ConstraintResult.Failure>()
			.Which(f => f.ExpectationText).Should(f => f.Be("expect1 prop expect2"))
			.Which(f => f.ResultText).Should(f => f.Be("foo"));
	}

	[Fact]
	public async Task ToString_WhenNodeIsEmpty_ShouldReturnPropertyNameAndEmptyInBrackets()
	{
		MappingNode<int, int> node = new(PropertyAccessor<int, int>.FromFunc(i => i, "foo "));

		string? result = node.ToString();

		await That(result).Should().Be("foo <empty>");
	}

	[Theory]
	[AutoData]
	public async Task ToString_WhenNodeIsNotEmpty_ShouldReturnPropertyNameAndNodeName(
		string propertyName, string nodeName)
	{
		MappingNode<int, int> node = new(PropertyAccessor<int, int>.FromFunc(i => i, propertyName));
		node.AddConstraint(new MyConstraint(name: nodeName));
		string expectedResult = propertyName + nodeName;

		string? result = node.ToString();

		await That(result).Should().Be(expectedResult);
	}
}
