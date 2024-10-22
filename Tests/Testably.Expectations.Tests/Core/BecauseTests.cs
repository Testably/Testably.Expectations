using Testably.Expectations.Tests.TestHelpers;

namespace Testably.Expectations.Tests.Core;

public class BecauseTests
{
	[Fact]
	public async Task Apply_Because_Reason_On_Action()
	{
		string because = "this is the reason";
		Action subject = () => throw new Exception();

		async Task Act()
			=> await Expect.That(subject).Should().DoesNotThrow().Because(because);

		await Expect.That(Act).Should().ThrowsWithMessage($"*{because}*");
	}

	[Fact]
	public async Task Apply_Because_Reason_When_Combining_With_And()
	{
		string because1 = "this is the first reason";
		string because2 = "this is the second reason";
		bool subject = true;

		async Task Act()
			=> await Expect.That(subject).Should().IsTrue().Because(because1)
				.And.IsFalse().Because(because2);

		await Expect.That(Act).Should().ThrowsWithMessage($"*{because2}*");
	}

	[Fact]
	public async Task Apply_Because_Reason_When_Combining_With_Or()
	{
		string because1 = "this is the first reason";
		string because2 = "this is the second reason";
		bool subject = true;

		async Task Act()
			=> await Expect.That(subject).Should().IsTrue().Because(because1)
				.And.IsFalse().Because(because2);

		await Expect.That(Act).Should().ThrowsWithMessage($"*{because1}*{because2}*");
	}

	[Fact]
	public async Task Apply_Because_Reasons_Only_On_Previous_Constraints()
	{
		string expectedMessage = """
		                         Expected that subject
		                         is True, because we only apply it to previous constraints and is False,
		                         but found True
		                         at Expect.That(subject).Should().IsTrue().And.IsFalse()
		                         """;
		string because = "we only apply it to previous constraints";
		bool subject = true;

		async Task Act()
			=> await Expect.That(subject).Should().IsTrue().Because(because)
				.And.IsFalse();

		await Expect.That(Act).Should().ThrowsException()
			.Which.HasMessage(expectedMessage);
	}

	[Fact]
	public async Task Do_Not_Overwrite_Previous_Because_Reasons()
	{
		string because1 = "this is the first reason";
		string because2 = "this is the second reason";
		bool subject = false;

		async Task Act()
			=> await Expect.That(subject).Should().IsTrue().Because(because1)
				.And.IsFalse().Because(because2);

		await Expect.That(Act).Should().ThrowsWithMessage($"*{because1}*");
	}

	[Fact]
	public async Task Honor_Already_Present_Because_Prefix()
	{
		string because = "because we honor a leading 'because'";
		bool subject = true;

		async Task Act()
			=> await Expect.That(subject).Should().IsFalse().Because(because);

		Exception exception = await Expect.That(Act).Should().ThrowsWithMessage("*because*");
		await Expect.That(exception.Message).Should().DoesNotContain("because because");
	}

	[Fact]
	public async Task Include_Because_Reason_In_Message()
	{
		string because = "I want to test 'because'";
		bool subject = true;

		async Task Act()
			=> await Expect.That(subject).Should().IsFalse().Because(because);

		await Expect.That(Act).Should().ThrowsWithMessage($"*{because}*");
	}

	[Theory]
	[InlineData("we prefix the reason", "because we prefix the reason")]
	[InlineData("  we ignore whitespace", "because we ignore whitespace")]
	[InlineData("because we honor a leading 'because'", "because we honor a leading 'because'")]
	public async Task Prefix_Because_Message(string because, string expectedWithPrefix)
	{
		bool subject = true;

		async Task Act()
			=> await Expect.That(subject).Should().IsFalse().Because(because);

		await Expect.That(Act).Should().ThrowsWithMessage($"*{expectedWithPrefix}*");
	}

	[Fact]
	public async Task Without_Because_Use_Empty_String()
	{
		string expectedMessage = """
		                         Expected that subject
		                         is False,
		                         but found True
		                         at Expect.That(subject).Should().IsFalse()
		                         """;

		bool subject = true;

		async Task Act()
			=> await Expect.That(subject).Should().IsFalse();

		await Expect.That(Act).Should().ThrowsException()
			.Which.HasMessage(expectedMessage);
	}
}
