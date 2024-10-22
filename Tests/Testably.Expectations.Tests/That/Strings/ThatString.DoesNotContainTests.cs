namespace Testably.Expectations.Tests.That.Strings;

public sealed partial class ThatString
{
	public class DoesNotContainTests
	{
		[Fact]
		public async Task IgnoringCase_ShouldIncludeSettingInExpectationText()
		{
			string subject =
				"In this text in between the word an investigator should find the word 'IN' multiple times.";
			string expected = "INVESTIGATOR";

			async Task Act()
				=> await Expect.That(subject).Should().DoesNotContain(expected).IgnoringCase();

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  does not contain "INVESTIGATOR" ignoring case,
				                  but found it 1 times in "In this text in between the word an investigator should find the word 'IN' multiple times."
				                  at Expect.That(subject).DoesNotContain(expected).Should().IgnoringCase()
				                  """);
		}
		[Fact]
		public async Task Using_ShouldIncludeComparerInExpectationText()
		{
			string subject =
				"In this text in between the word an investigator should find the word 'IN' multiple times.";
			string expected = "InvEstIgAtOr";

			async Task Act()
				=> await Expect.That(subject).Should().DoesNotContain(expected).Using(new IgnoreCaseForVocalsComparer());

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  does not contain "InvEstIgAtOr" using IgnoreCaseForVocalsComparer,
				                  but found it 1 times in "In this text in between the word an investigator should find the word 'IN' multiple times."
				                  at Expect.That(subject).DoesNotContain(expected).Should().Using(new IgnoreCaseForVocalsComparer())
				                  """);
		}


		[Fact]
		public async Task WhenExpectedStringIsContained_ShouldFail()
		{
			string subject = "some text";
			string expected = "me";

			async Task Act()
				=> await Expect.That(subject).Should().DoesNotContain(expected);

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  does not contain "me",
				                  but found it 1 times in "some text"
				                  at Expect.That(subject).Should().DoesNotContain(expected)
				                  """);
		}

		[Fact]
		public async Task WhenExpectedStringIsNotContained_ShouldSucceed()
		{
			string subject = "some text";
			string expected = "not";

			async Task Act()
				=> await Expect.That(subject).Should().DoesNotContain(expected);

			await Expect.That(Act).Should().DoesNotThrow();
		}
	}
}
