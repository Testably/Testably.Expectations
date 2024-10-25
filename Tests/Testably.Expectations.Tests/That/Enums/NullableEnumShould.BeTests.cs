namespace Testably.Expectations.Tests.That.Enums;

public sealed partial class NullableEnumShould
{
	public sealed class BeTests
	{
		[Fact]
		public async Task WhenSubjectAndExpectedAreNull_ShouldSucceed()
		{
			MyColors? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().Be(null);

			await Expect.That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(MyColors.Blue, MyColors.Green)]
		[InlineData(MyColors.Blue, null)]
		[InlineData(MyColors.Green, MyColors.Blue)]
		[InlineData(MyColors.Green, null)]
		[InlineData(null, MyColors.Blue)]
		[InlineData(null, MyColors.Green)]
		public async Task WhenSubjectIsDifferent_ShouldFail(MyColors? subject, MyColors? expected)
		{
			async Task Act()
				=> await Expect.That(subject).Should().Be(expected);

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HaveMessage($"""
				                    Expected subject to
				                    be {expected?.ToString() ?? "<null>"},
				                    but found {subject?.ToString() ?? "<null>"}
				                    at Expect.That(subject).Should().Be(expected)
				                    """);
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			MyColors? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().Be(MyColors.Red);

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HaveMessage("""
				                   Expected subject to
				                   be Red,
				                   but found <null>
				                   at Expect.That(subject).Should().Be(MyColors.Red)
				                   """);
		}

		[Theory]
		[InlineData(MyColors.Blue)]
		[InlineData(MyColors.Green)]
		public async Task WhenSubjectIsTheSame_ShouldSucceed(MyColors? subject)
		{
			MyColors? expected = subject;

			async Task Act()
				=> await Expect.That(subject).Should().Be(expected);

			await Expect.That(Act).Should().NotThrow();
		}
	}

	public sealed class NotBeTests
	{
		[Fact]
		public async Task WhenSubjectAndExpectedAreNull_ShouldFail()
		{
			MyColors? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().NotBe(null);

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HaveMessage("""
				                   Expected subject to
				                   not be <null>,
				                   but found <null>
				                   at Expect.That(subject).Should().NotBe(null)
				                   """);
		}

		[Theory]
		[InlineData(MyColors.Blue, MyColors.Green)]
		[InlineData(MyColors.Blue, null)]
		[InlineData(MyColors.Green, MyColors.Blue)]
		[InlineData(MyColors.Green, null)]
		[InlineData(null, MyColors.Blue)]
		[InlineData(null, MyColors.Green)]
		public async Task WhenSubjectIsDifferent_ShouldSucceed(MyColors? subject,
			MyColors? unexpected)
		{
			async Task Act()
				=> await Expect.That(subject).Should().NotBe(unexpected);

			await Expect.That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(MyColors.Blue)]
		[InlineData(MyColors.Green)]
		[InlineData(null)]
		public async Task WhenSubjectIsTheSame_ShouldFail(MyColors? subject)
		{
			MyColors? unexpected = subject;

			async Task Act()
				=> await Expect.That(subject).Should().NotBe(unexpected);

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HaveMessage($"""
				                    Expected subject to
				                    not be {unexpected?.ToString() ?? "<null>"},
				                    but found {subject?.ToString() ?? "<null>"}
				                    at Expect.That(subject).Should().NotBe(unexpected)
				                    """);
		}
	}
}
