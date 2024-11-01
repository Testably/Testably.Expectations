namespace Testably.Expectations.Tests.ThatTests.Objects;

public sealed partial class ObjectShould
{
	public sealed class BeTests
	{
		[Theory]
		[AutoData]
		public async Task WhenAwaited_ShouldReturnTypedResult(int value)
		{
			object? subject = new MyClass { Value = value };

			MyClass result = await That(subject).Should().Be<MyClass>();
			await That(result.Value).Should().Be(value);
		}

		[Theory]
		[AutoData]
		public async Task WhenTypeDoesNotMatch_ShouldFail(int value)
		{
			object subject = new MyClass { Value = value };

			async Task Act()
				=> await That(subject).Should().Be<OtherClass>()
					.Because("we want to test the failure");

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($$"""
				               Expected subject to
				               be type OtherClass, because we want to test the failure,
				               but found MyClass{
				                 Value = {{value}}
				               }
				               at Expect.That(subject).Should().Be<OtherClass>().Because("we want to test the failure")
				               """);
		}

		[Fact]
		public async Task WhenTypeIsSubtype_ShouldSucceed()
		{
			object subject = new MyClass();

			async Task Act()
				=> await That(subject).Should().Be<MyBaseClass>();

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[AutoData]
		public async Task WhenTypeIsSupertype_ShouldFail(int value, string reason)
		{
			object subject = new MyBaseClass { Value = value };

			async Task Act()
				=> await That(subject).Should().Be<MyClass>()
					.Because(reason);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($$"""
				               Expected subject to
				               be type MyClass, because {{reason}},
				               but found MyBaseClass{
				                 Value = {{value}}
				               }
				               at Expect.That(subject).Should().Be<MyClass>().Because(reason)
				               """);
		}

		[Fact]
		public async Task WhenTypeMatches_ShouldSucceed()
		{
			object subject = new MyClass();

			async Task Act()
				=> await That(subject).Should().Be<MyClass>();

			await That(Act).Should().NotThrow();
		}
	}
}
