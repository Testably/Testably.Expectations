using System.Collections.Generic;
using System.Linq;
using Testably.Expectations.Core.Nodes;
using Testably.Expectations.Internal.Tests.TestHelpers;

namespace Testably.Expectations.Internal.Tests.Core.Nodes;

public sealed class AndNodeTests
{
	[Theory]
	[AutoData]
	public async Task ToString_ShouldCombineAllNodes(
		params string[] nodeNames)
	{
		List<ExpectationNode> nodes = nodeNames.Select(x =>
		{
			ExpectationNode node = new();
			node.AddConstraint(new MyConstraint(name: x));
			return node;
		}).ToList();
		AndNode sut = new(nodes.First());
		foreach (ExpectationNode? node in nodes.Skip(1))
		{
			sut.AddNode(node);
		}

		string expectedResult = string.Join(" and ", nodeNames);

		string? result = sut.ToString();

		await That(result).Should().Be(expectedResult);
	}

	[Fact]
	public async Task ToString_WhenEmpty_ShouldCombineAllNodes()
	{
		AndNode sut = new(new ExpectationNode());

		string expectedResult = "<empty>";

		string? result = sut.ToString();

		await That(result).Should().Be(expectedResult);
	}
}
