using System.Collections.Generic;

namespace Testably.Expectations.Tests.ThatTests.Objects;

public sealed partial class ObjectShould
{
	public sealed class BeEquivalentToTests
	{
		[Fact]
		public async Task BasicObjects_ShouldBeEquivalent()
		{
			MyClass subject = new MyClass { Value = "Foo" };
			MyClass expected = new MyClass { Value = "Foo" };

			await That(subject).Should().BeEquivalentTo(expected);
		}

		[Fact]
		public async Task MismatchedObjects_ShouldNotBeEquivalent()
		{
			MyClass subject = new MyClass();
			MyClass expected = new MyClass { Value = "Foo" };

			await That(async () => await That(subject).Should().BeEquivalentTo(expected))
				.Should()
				.ThrowException().WithMessage("""
				                              Expected subject to
				                              be equivalent to expected,
				                              but Property Value did not match:
				                                Expected: "Foo"
				                                Received: <null>
				                              at Expect.That(subject).Should().BeEquivalentTo(expected)
				                              """);
		}

		[Fact]
		public async Task ObjectsWithNestedEnumerableMatches_ShouldBeEquivalent()
		{
			MyClass subject = new MyClass
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
			MyClass expected = new MyClass
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

			await That(subject).Should().BeEquivalentTo(expected);
		}

		[Fact]
		public void ObjectsWithNestedEnumerableMismatch_ShouldNotBeEquivalent()
		{
			MyClass subject = new MyClass
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

			MyClass expected = new MyClass
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

			That(async () => await That(subject).Should().BeEquivalentTo(expected))
				.Should()
				.ThrowException().WithMessage("""
				                              Expected subject to
				                              be equivalent to expected,
				                              but EnumerableItem Inner.Inner.Collection.[3] did not match
				                                Expected: "4"
				                                Received: null
				                              at Expect.That(subject).Should().BeEquivalentTo(expected)
				                              """);
		}

		[Fact]
		public async Task ObjectsWithNestedEnumerableMismatch_WithIgnoreRule_ShouldBeEquivalent()
		{
			MyClass subject = new MyClass
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

			MyClass expected = new MyClass
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

			await That(subject).Should().BeEquivalentTo(expected)
				.IgnoringMember("Inner.Inner.Collection.[3]");
		}

		[Fact]
		public async Task ObjectsWithNestedMatches_ShouldBeEquivalent()
		{
			MyClass subject = new MyClass
			{
				Value = "Foo",
				Inner = new InnerClass
				{
					Value = "Bar",
					Inner = new InnerClass { Value = "Baz" }
				}
			};
			MyClass expected = new MyClass
			{
				Value = "Foo",
				Inner = new InnerClass
				{
					Value = "Bar",
					Inner = new InnerClass { Value = "Baz" }
				}
			};

			await That(subject).Should().BeEquivalentTo(expected);
		}

		[Fact]
		public async Task ObjectsWithNestedMismatch_ShouldNotBeEquivalent()
		{
			MyClass subject = new MyClass
			{
				Value = "Foo",
				Inner = new InnerClass
				{
					Value = "Bar",
					Inner = new InnerClass()
				}
			};
			MyClass expected = new MyClass
			{
				Value = "Foo",
				Inner = new InnerClass
				{
					Value = "Bar",
					Inner = new InnerClass { Value = "Baz" }
				}
			};

			await That(async () => await That(subject).Should().BeEquivalentTo(expected))
				.Should()
				.ThrowException().WithMessage("""
				                              Expected subject to
				                              be equivalent to expected,
				                              but Property Inner.Inner.Value did not match:
				                                Expected: "Baz"
				                                Received: <null>
				                              at Expect.That(subject).Should().BeEquivalentTo(expected)
				                              """).Exactly();
		}

		public class InnerClass
		{
			public IEnumerable<string>? Collection { get; set; }

			public InnerClass? Inner { get; set; }
			public string? Value { get; set; }
		}

		public class MyClass
		{
			public InnerClass? Inner { get; set; }
			public string? Value { get; set; }
		}
	}
}
