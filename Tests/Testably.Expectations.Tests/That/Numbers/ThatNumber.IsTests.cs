namespace Testably.Expectations.Tests.That.Numbers;

public sealed partial class ThatNumber
{
	public sealed class IsTests
	{
		[Theory]
		[InlineData(1.0, 2.1)]
		[InlineData(5.8, -3.03)]
		public async Task ShouldFailForDifferentFloatValues(float subject,
			float expected)
		{
			async Task Act()
				=> await Expect.That(subject).Should().Is(expected);

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected subject to
				                   is {expected},
				                   but found {subject}
				                   at Expect.That(subject).Should().Is(expected)
				                   """);
		}

		[Theory]
		[InlineData(1, 2)]
		[InlineData(5, -3)]
		public async Task ShouldFailForDifferentIntegerValues(int subject,
			int expected)
		{
			async Task Act()
				=> await Expect.That(subject).Should().Is(expected);

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected subject to
				                   is {expected},
				                   but found {subject}
				                   at Expect.That(subject).Should().Is(expected)
				                   """);
		}

		[Theory]
		[AutoData]
		public async Task ShouldFailForFloatComparisonWithNull(float subject)
		{
			float? expected = null;

			async Task Act()
				=> await Expect.That(subject).Should().Is(expected);

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected subject to
				                   is <null>,
				                   but found {subject}
				                   at Expect.That(subject).Should().Is(expected)
				                   """);
		}

		[Theory]
		[AutoData]
		public async Task ShouldFailForIntegerComparisonWithNull(int subject)
		{
			int? expected = null;

			async Task Act()
				=> await Expect.That(subject).Should().Is(expected);

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected subject to
				                   is <null>,
				                   but found {subject}
				                   at Expect.That(subject).Should().Is(expected)
				                   """);
		}

		[Theory]
		[AutoData]
		public async Task ShouldSucceedForEqualDoubleAndFloatValues(float expected)
		{
			double subject = expected;

			async Task Act()
				=> await Expect.That(subject).Should().Is(expected);

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Theory]
		[AutoData]
		public async Task ShouldSucceedForEqualFloatValueAndNullableValue(float subject)
		{
			float? expected = subject;

			async Task Act()
				=> await Expect.That(subject).Should().Is(expected);

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Theory]
		[AutoData]
		public async Task ShouldSucceedForEqualFloatValues(float subject)
		{
			float expected = subject;

			async Task Act()
				=> await Expect.That(subject).Should().Is(expected);

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Theory]
		[AutoData]
		public async Task ShouldSucceedForEqualIntegerValueAndNullableValue(int subject)
		{
			int? expected = subject;

			async Task Act()
				=> await Expect.That(subject).Should().Is(expected);

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Theory]
		[AutoData]
		public async Task ShouldSucceedForEqualIntegerValues(int subject)
		{
			int expected = subject;

			async Task Act()
				=> await Expect.That(subject).Should().Is(expected);

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Theory]
		[AutoData]
		public async Task ShouldSucceedForEqualLongAndIntegerValues(int expected)
		{
			long subject = expected;

			async Task Act()
				=> await Expect.That(subject).Should().Is(expected);

			await Expect.That(Act).Should().DoesNotThrow();
		}
	}
}
