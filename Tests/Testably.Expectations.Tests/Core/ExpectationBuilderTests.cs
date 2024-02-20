using Testably.Expectations.Core;
using Testably.Expectations.Core.Nodes;
using Xunit;

namespace Testably.Expectations.Tests.Core;

public sealed class ExpectationBuilderTests
{
	public sealed class TreeValidation
	{
		[Fact]
		public void A_And_B_Or_C()
		{
			ExpectationBuilder.Tree tree = new();
			tree.AddExpectation(new DummyExpectation("a"));
			tree.AddCombination(n => new AndNode(n, Node.None), 2);
			tree.AddExpectation(new DummyExpectation("b"));
			tree.AddCombination(n => new OrNode(n, Node.None), 1);
			tree.AddExpectation(new DummyExpectation("c"));

			Expect.That(tree.ToString(), Should.Be.EqualTo("(a AND b) OR c"));
		}

		[Fact]
		public void A_And_B_Or_Not_C()
		{
			ExpectationBuilder.Tree tree = new();
			tree.AddExpectation(new DummyExpectation("a"));
			tree.AddCombination(n => new AndNode(n, Node.None), 2);
			tree.AddExpectation(new DummyExpectation("b"));
			tree.AddCombination(n => new OrNode(n, Node.None), 1);
			tree.AddManipulation(n => new NotNode(n));
			tree.AddExpectation(new DummyExpectation("c"));

			Expect.That(tree.ToString(), Should.Be.EqualTo("(a AND b) OR NOT c"));
		}

		[Fact]
		public void A_And_B()
		{
			ExpectationBuilder.Tree tree = new();
			tree.AddExpectation(new DummyExpectation("a"));
			tree.AddCombination(n => new AndNode(n, Node.None), 2);
			tree.AddExpectation(new DummyExpectation("b"));

			Expect.That(tree.ToString(), Should.Be.EqualTo("a AND b"));
		}

		[Fact]
		public void A_Or_B_And_C()
		{
			ExpectationBuilder.Tree tree = new();
			tree.AddExpectation(new DummyExpectation("a"));
			tree.AddCombination(n => new OrNode(n, Node.None), 1);
			tree.AddExpectation(new DummyExpectation("b"));
			tree.AddCombination(n => new AndNode(n, Node.None), 2);
			tree.AddExpectation(new DummyExpectation("c"));

			Expect.That(tree.ToString(), Should.Be.EqualTo("a OR (b AND c)"));
		}

		[Fact]
		public void A()
		{
			ExpectationBuilder.Tree tree = new();
			tree.AddExpectation(new DummyExpectation("a"));

			Expect.That(tree.ToString(), Should.Be.EqualTo("a"));
		}

		[Fact]
		public void Not_A()
		{
			ExpectationBuilder.Tree tree = new();
			tree.AddManipulation(n => new NotNode(n));
			tree.AddExpectation(new DummyExpectation("a"));

			Expect.That(tree.ToString(), Should.Be.EqualTo("NOT a"));
		}

		private class DummyExpectation : IExpectation
		{
			private readonly string _name;

			public DummyExpectation(string name)
			{
				_name = name;
			}

			/// <inheritdoc />
			public override string ToString()
				=> _name;
		}
	}
}
