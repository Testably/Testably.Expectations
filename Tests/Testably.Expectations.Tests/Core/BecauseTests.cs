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
			=> await Expect.That(subject).Should().NotThrow().Because(because);

		await Expect.That(Act).Should().ThrowException().WithMessage($"*{because}*").AsWildcard();
	}

	[Fact]
	public async Task Apply_Because_Reason_When_Combining_With_And()
	{
		string because1 = "this is the first reason";
		string because2 = "this is the second reason";
		bool subject = true;

		async Task Act()
			=> await Expect.That(subject).Should().BeTrue().Because(because1)
				.And.BeFalse().Because(because2);

		await Expect.That(Act).Should().ThrowException().WithMessage($"*{because2}*").AsWildcard();
	}

	[Fact]
	public async Task Apply_Because_Reason_When_Combining_With_Or()
	{
		string because1 = "this is the first reason";
		string because2 = "this is the second reason";
		bool subject = true;

		async Task Act()
			=> await Expect.That(subject).Should().BeTrue().Because(because1)
				.And.BeFalse().Because(because2);

		await Expect.That(Act).Should().ThrowException().WithMessage($"*{because1}*{because2}*").AsWildcard();
	}

	[Fact]
	public async Task Apply_Because_Reasons_Only_On_Previous_Constraints()
	{
		string expectedMessage = """
		                         Expected subject to
		                         be True, because we only apply it to previous constraints and be False,
		                         but found True
		                         at Expect.That(subject).Should().BeTrue().And.BeFalse()
		                         """;
		string because = "we only apply it to previous constraints";
		bool subject = true;

		async Task Act()
			=> await Expect.That(subject).Should().BeTrue().Because(because)
				.And.BeFalse();

		await Expect.That(Act).Should().ThrowException()
			.WithMessage(expectedMessage);
	}

	[Fact]
	public async Task Do_Not_Overwrite_Previous_Because_Reasons()
	{
		string because1 = "this is the first reason";
		string because2 = "this is the second reason";
		bool subject = false;

		async Task Act()
			=> await Expect.That(subject).Should().BeTrue().Because(because1)
				.And.BeFalse().Because(because2);

		await Expect.That(Act).Should().ThrowException().WithMessage($"*{because1}*").AsWildcard();
	}

	[Fact]
	public async Task Honor_Already_Present_Because_Prefix()
	{
		string because = "because we honor a leading 'because'";
		bool subject = true;

		async Task Act()
			=> await Expect.That(subject).Should().BeFalse().Because(because);

		Exception exception = await Expect.That(Act).Should().ThrowException().WithMessage("*because*").AsWildcard();
		await Expect.That(exception.Message).Should().NotContain("because because");
	}

	[Fact]
	public async Task Include_Because_Reason_In_Message()
	{
		string because = "I want to test 'because'";
		bool subject = true;

		async Task Act()
			=> await Expect.That(subject).Should().BeFalse().Because(because);

		await Expect.That(Act).Should().ThrowException().WithMessage($"*{because}*").AsWildcard();
	}

	[Theory]
	[InlineData("we prefix the reason", "because we prefix the reason")]
	[InlineData("  we ignore whitespace", "because we ignore whitespace")]
	[InlineData("because we honor a leading 'because'", "because we honor a leading 'because'")]
	public async Task Prefix_Because_Message(string because, string expectedWithPrefix)
	{
		bool subject = true;

		async Task Act()
			=> await Expect.That(subject).Should().BeFalse().Because(because);

		await Expect.That(Act).Should().ThrowException().WithMessage($"*{expectedWithPrefix}*").AsWildcard();
	}

	[Fact]
	public async Task Without_Because_Use_Empty_String()
	{
		string expectedMessage = """
		                         Expected subject to
		                         be False,
		                         but found True
		                         at Expect.That(subject).Should().BeFalse()
		                         """;

		bool subject = true;

		async Task Act()
			=> await Expect.That(subject).Should().BeFalse();

		await Expect.That(Act).Should().ThrowException()
			.WithMessage(expectedMessage);
	}
}
