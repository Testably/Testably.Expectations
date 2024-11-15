using System.Threading;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.EvaluationContext;
using Testably.Expectations.Core.Nodes;
using Testably.Expectations.Internal.Tests.TestHelpers;

namespace Testably.Expectations.Internal.Tests.Core.Nodes;

public class ExpectationNodeTests
{
	[Fact]
	public async Task AddConstraint_WithMapping_ShouldAddConstraintToMapping()
	{
		ExpectationNode node = new();
		node.AddMapping(PropertyAccessor<int, int>.FromFunc(i => 2 * i, "foo"));
		node.AddConstraint(new CheckConstraint(i => i == 6));

		ConstraintResult result = await node
			.IsMetBy(3, new EvaluationContext(), CancellationToken.None);

		await That(result).Should().Be<ConstraintResult.Success>();
	}

	[Fact]
	public async Task AddNode_ShouldThrowInvalidOperationException()
	{
		ExpectationNode node = new();
		void Act() => node.AddNode(new ExpectationNode());

		await That(Act).Should().Throw<NotSupportedException>()
			.WithMessage(
				$"Don't specify the inner node for Expectation nodes directly. You can use {nameof(ExpectationNode.AddMapping)} instead.");
	}

	[Theory]
	[AutoData]
	public async Task ToString_WhenNodeHasAConstraint_ShouldReturnConstraintName(
		string constraintName)
	{
		ExpectationNode node = new();
		node.AddConstraint(new MyConstraint(name: constraintName));

		string? result = node.ToString();

		await That(result).Should().Be(constraintName);
	}

	[Fact]
	public async Task ToString_WhenNodeIsEmpty_ShouldReturnEmptyInBrackets()
	{
		ExpectationNode node = new();

		string? result = node.ToString();

		await That(result).Should().Be("<empty>");
	}

	[Fact]
	public async Task ToString_WithMapping_ShouldReturnMappingAndInnerConstraint()
	{
		ExpectationNode node = new();
		node.AddMapping(PropertyAccessor<int, int>.FromFunc(i => i, "foo-"));
		node.AddConstraint(new MyConstraint(name: "bar"));

		string? result = node.ToString();

		await That(result).Should().Be("foo-bar");
	}

	[Fact]
	public async Task ToString_WithConstraintAndMapping_ShouldReturnBoth()
	{
		ExpectationNode node = new();
		node.AddConstraint(new MyConstraint(name: "baz "));
		node.AddMapping(PropertyAccessor<int, int>.FromFunc(i => i, "foo-"));
		node.AddConstraint(new MyConstraint(name: "bar"));

		string? result = node.ToString();

		await That(result).Should().Be("baz foo-bar");
	}

	private class CheckConstraint(Func<int, bool> isMatch) : IValueConstraint<int>
	{
		#region IValueConstraint<int> Members

		/// <inheritdoc />
		public ConstraintResult IsMetBy(int actual)
		{
			if (isMatch(actual))
			{
				return new ConstraintResult.Success("");
			}

			return new ConstraintResult.Failure("", "");
		}

		#endregion
	}
}
