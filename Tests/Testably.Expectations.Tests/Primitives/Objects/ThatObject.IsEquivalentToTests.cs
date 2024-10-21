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
			var object1 = new MyClass
			{
				Value = "Foo"
			};
			var object2 = new MyClass
			{
				Value = "Foo"
			};

			await Expect.That(object1).IsEquivalentTo(object2);
		}

		[Fact]
		public async Task MismatchedObjects_ShouldNotBeEquivalent()
		{
			var object1 = new MyClass();
			var object2 = new MyClass
			{
				Value = "Foo"
			};

			await Expect.That(async () => await Expect.That(object1).IsEquivalentTo(object2))
				.ThrowsWithMessage("""
				                   Expected that object1
				                   is equivalent to object2,
				                   but Property Value did not match:
				                     Expected: "Foo"
				                     Received: <null>
				                   at Expect.That(object1).IsEquivalentTo(object2)
				                   """);
		}

		[Fact]
		public async Task ObjectsWithNestedMismatch_ShouldNotBeEquivalent()
		{
			var object1 = new MyClass
			{
				Value = "Foo",
				Inner = new InnerClass
				{
					Value = "Bar",
					Inner = new InnerClass()
				}
			};
			var object2 = new MyClass
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

			await Expect.That(async () => await Expect.That(object1).IsEquivalentTo(object2))
				.ThrowsWithMessage("""
				                   Expected that object1
				                   is equivalent to object2,
				                   but Property Inner.Inner.Value did not match:
				                     Expected: "Baz"
				                     Received: <null>
				                   at Expect.That(object1).IsEquivalentTo(object2)
				                   """).Exactly();
		}

		[Fact]
		public async Task ObjectsWithNestedMatches_ShouldBeEquivalent()
		{
			var object1 = new MyClass
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
			var object2 = new MyClass
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

			await Expect.That(object1).IsEquivalentTo(object2);
		}

		[Fact]
		public void ObjectsWithNestedEnumerableMismatch_ShouldNotBeEquivalent()
		{
			var object1 = new MyClass
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

			var object2 = new MyClass
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

			Expect.That(async () => await Expect.That(object1).IsEquivalentTo(object2))
				.ThrowsWithMessage("""
				                   Expected that object1
				                   is equivalent to object2,
				                   but EnumerableItem Inner.Inner.Collection.[3] did not match
				                     Expected: "4"
				                     Received: null
				                   at Expect.That(object1).IsEquivalentTo(object2)
				                   """);
		}

		[Fact]
		public async Task ObjectsWithNestedEnumerableMismatch_WithIgnoreRule_ShouldBeEquivalent()
		{
			var object1 = new MyClass
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

			var object2 = new MyClass
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

			await Expect.That(object1).IsEquivalentTo(object2).IgnoringMember("Inner.Inner.Collection.[3]");
		}

		[Fact]
		public async Task ObjectsWithNestedEnumerableMatches_ShouldBeEquivalent()
		{
			var object1 = new MyClass
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
			var object2 = new MyClass
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

			await Expect.That(object1).IsEquivalentTo(object2);
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
