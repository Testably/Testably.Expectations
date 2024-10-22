using System.Collections.Generic;
using Testably.Expectations.Tests.TestHelpers;

namespace Testably.Expectations.Tests.Primitives.Objects;

public sealed partial class ThatObject
{
	public sealed class IsEquivalentToTests
	{
		[Fact]
		public async Task BasicObjects_ShouldBeEquivalent()
		{
			var subject = new MyClass
			{
				Value = "Foo"
			};
			var expected = new MyClass
			{
				Value = "Foo"
			};

			await Expect.That(subject).IsEquivalentTo(expected);
		}

		[Fact]
		public async Task MismatchedObjects_ShouldNotBeEquivalent()
		{
			var subject = new MyClass();
			var expected = new MyClass
			{
				Value = "Foo"
			};

			await Expect.That(async () => await Expect.That(subject).IsEquivalentTo(expected))
				.ThrowsWithMessage("""
				                   Expected that subject
				                   is equivalent to expected,
				                   but Property Value did not match:
				                     Expected: "Foo"
				                     Received: <null>
				                   at Expect.That(subject).IsEquivalentTo(expected)
				                   """);
		}

		[Fact]
		public async Task ObjectsWithNestedMismatch_ShouldNotBeEquivalent()
		{
			var subject = new MyClass
			{
				Value = "Foo",
				Inner = new InnerClass
				{
					Value = "Bar",
					Inner = new InnerClass()
				}
			};
			var expected = new MyClass
			{
				Value = "Foo",
				Inner = new InnerClass
				{
					Value = "Bar",
					Inner = new InnerClass
					{
						Value = "Baz"
					}
				}
			};

			await Expect.That(async () => await Expect.That(subject).IsEquivalentTo(expected))
				.ThrowsWithMessage("""
				                   Expected that subject
				                   is equivalent to expected,
				                   but Property Inner.Inner.Value did not match:
				                     Expected: "Baz"
				                     Received: <null>
				                   at Expect.That(subject).IsEquivalentTo(expected)
				                   """).Exactly();
		}

		[Fact]
		public async Task ObjectsWithNestedMatches_ShouldBeEquivalent()
		{
			var subject = new MyClass
			{
				Value = "Foo",
				Inner = new InnerClass
				{
					Value = "Bar",
					Inner = new InnerClass
					{
						Value = "Baz"
					}
				}
			};
			var expected = new MyClass
			{
				Value = "Foo",
				Inner = new InnerClass
				{
					Value = "Bar",
					Inner = new InnerClass
					{
						Value = "Baz"
					}
				}
			};

			await Expect.That(subject).IsEquivalentTo(expected);
		}

		[Fact]
		public void ObjectsWithNestedEnumerableMismatch_ShouldNotBeEquivalent()
		{
			var subject = new MyClass
			{
				Value = "Foo",
				Inner = new InnerClass
				{
					Value = "Bar",
					Inner = new InnerClass
					{
						Value = "Baz",
						Collection = ["1", "2", "3"]
					}
				}
			};

			var expected = new MyClass
			{
				Value = "Foo",
				Inner = new InnerClass
				{
					Value = "Bar",
					Inner = new InnerClass
					{
						Value = "Baz",
						Collection = ["1", "2", "3", "4"]
					}
				}
			};

			Expect.That(async () => await Expect.That(subject).IsEquivalentTo(expected))
				.ThrowsWithMessage("""
				                   Expected that subject
				                   is equivalent to expected,
				                   but EnumerableItem Inner.Inner.Collection.[3] did not match
				                     Expected: "4"
				                     Received: null
				                   at Expect.That(subject).IsEquivalentTo(expected)
				                   """);
		}

		[Fact]
		public async Task ObjectsWithNestedEnumerableMismatch_WithIgnoreRule_ShouldBeEquivalent()
		{
			var subject = new MyClass
			{
				Value = "Foo",
				Inner = new InnerClass
				{
					Value = "Bar",
					Inner = new InnerClass
					{
						Value = "Baz",
						Collection = ["1", "2", "3"]
					}
				}
			};

			var expected = new MyClass
			{
				Value = "Foo",
				Inner = new InnerClass
				{
					Value = "Bar",
					Inner = new InnerClass
					{
						Value = "Baz",
						Collection = ["1", "2", "3", "4"]
					}
				}
			};

			await Expect.That(subject).IsEquivalentTo(expected).IgnoringMember("Inner.Inner.Collection.[3]");
		}

		[Fact]
		public async Task ObjectsWithNestedEnumerableMatches_ShouldBeEquivalent()
		{
			var subject = new MyClass
			{
				Value = "Foo",
				Inner = new InnerClass
				{
					Value = "Bar",
					Inner = new InnerClass
					{
						Value = "Baz",
						Collection = ["1", "2", "3"]
					}
				}
			};
			var expected = new MyClass
			{
				Value = "Foo",
				Inner = new InnerClass
				{
					Value = "Bar",
					Inner = new InnerClass
					{
						Value = "Baz",
						Collection = ["1", "2", "3"]
					}
				}
			};

			await Expect.That(subject).IsEquivalentTo(expected);
		}

		public class MyClass
		{
			public string? Value { get; set; }
			public InnerClass? Inner { get; set; }
		}

		public class InnerClass
		{
			public string? Value { get; set; }

			public InnerClass? Inner { get; set; }

			public IEnumerable<string>? Collection { get; set; }
		}
	}
}
