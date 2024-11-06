using System.Globalization;

namespace Testably.Expectations.Tests.ThatTests.Numbers;

public sealed partial class NumberShould
{
	public sealed class BeTests
	{
		[Theory]
		[InlineData(1.0F, 2.1F)]
		[InlineData(5.8F, -3.03F)]
		public async Task ShouldFailForDifferentFloatValues(float subject,
			float expected)
		{
			async Task Act()
				=> await That(subject).Should().Be(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be {expected.ToString(CultureInfo.InvariantCulture)},
				              but found {subject.ToString(CultureInfo.InvariantCulture)}
				              at Expect.That(subject).Should().Be(expected)
				              """);
		}

		[Theory]
		[InlineData(1, 2)]
		[InlineData(5, -3)]
		public async Task ShouldFailForDifferentIntegerValues(int subject,
			int expected)
		{
			async Task Act()
				=> await That(subject).Should().Be(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be {expected},
				              but found {subject}
				              at Expect.That(subject).Should().Be(expected)
				              """);
		}

		[Theory]
		[InlineData(1.0F, 2.1F)]
		[InlineData(5.8F, -3.03F)]
		public async Task ShouldFailForDifferentNullableFloatValues(float? subject,
			float? expected)
		{
			async Task Act()
				=> await That(subject).Should().Be(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be {expected?.ToString(CultureInfo.InvariantCulture) ?? "<null>"},
				              but found {subject?.ToString(CultureInfo.InvariantCulture) ?? "<null>"}
				              at Expect.That(subject).Should().Be(expected)
				              """);
		}

		[Theory]
		[InlineData(1, 2)]
		[InlineData(5, -3)]
		public async Task ShouldFailForDifferentNullableIntegerValues(int? subject,
			int? expected)
		{
			async Task Act()
				=> await That(subject).Should().Be(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be {expected},
				              but found {subject}
				              at Expect.That(subject).Should().Be(expected)
				              """);
		}

		[Theory]
		[AutoData]
		public async Task ShouldFailForFloatComparisonWithNull(float subject)
		{
			float? expected = null;

			async Task Act()
				=> await That(subject).Should().Be(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be <null>,
				              but found {subject}
				              at Expect.That(subject).Should().Be(expected)
				              """);
		}

		[Theory]
		[AutoData]
		public async Task ShouldFailForIntegerComparisonWithNull(int subject)
		{
			int? expected = null;

			async Task Act()
				=> await That(subject).Should().Be(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be <null>,
				              but found {subject}
				              at Expect.That(subject).Should().Be(expected)
				              """);
		}

		[Theory]
		[AutoData]
		public async Task ShouldFailForNullableFloatComparisonWithNull(float? subject)
		{
			float? expected = null;

			async Task Act()
				=> await That(subject).Should().Be(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be <null>,
				              but found {subject}
				              at Expect.That(subject).Should().Be(expected)
				              """);
		}

		[Theory]
		[AutoData]
		public async Task ShouldFailForNullableIntegerComparisonWithNull(int? subject)
		{
			int? expected = null;

			async Task Act()
				=> await That(subject).Should().Be(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be <null>,
				              but found {subject}
				              at Expect.That(subject).Should().Be(expected)
				              """);
		}

		[Theory]
		[AutoData]
		public async Task ShouldSucceedForEqualDoubleAndFloatValues(float expected)
		{
			double subject = expected;

			async Task Act()
				=> await That(subject).Should().Be(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[AutoData]
		public async Task ShouldSucceedForEqualFloatValueAndNullableValue(float subject)
		{
			float? expected = subject;

			async Task Act()
				=> await That(subject).Should().Be(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[AutoData]
		public async Task ShouldSucceedForEqualFloatValues(float subject)
		{
			float expected = subject;

			async Task Act()
				=> await That(subject).Should().Be(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[AutoData]
		public async Task ShouldSucceedForEqualIntegerValueAndNullableValue(int subject)
		{
			int? expected = subject;

			async Task Act()
				=> await That(subject).Should().Be(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[AutoData]
		public async Task ShouldSucceedForEqualIntegerValues(int subject)
		{
			int expected = subject;

			async Task Act()
				=> await That(subject).Should().Be(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[AutoData]
		public async Task ShouldSucceedForEqualLongAndIntegerValues(int expected)
		{
			long subject = expected;

			async Task Act()
				=> await That(subject).Should().Be(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[AutoData]
		public async Task ShouldSucceedForEqualNullableDoubleAndNullableFloatValues(float? expected)
		{
			double? subject = expected;

			async Task Act()
				=> await That(subject).Should().Be(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[AutoData]
		public async Task ShouldSucceedForEqualNullableFloatValueAndExpectedValue(float expected)
		{
			float? subject = expected;

			async Task Act()
				=> await That(subject).Should().Be(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[AutoData]
		public async Task ShouldSucceedForEqualNullableFloatValues(float? subject)
		{
			float? expected = subject;

			async Task Act()
				=> await That(subject).Should().Be(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[AutoData]
		public async Task ShouldSucceedForEqualNullableIntegerValueAndExpectedValue(int expected)
		{
			int? subject = expected;

			async Task Act()
				=> await That(subject).Should().Be(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[AutoData]
		public async Task ShouldSucceedForEqualNullableIntegerValues(int? subject)
		{
			int? expected = subject;

			async Task Act()
				=> await That(subject).Should().Be(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[AutoData]
		public async Task ShouldSucceedForEqualNullableLongAndNullableIntegerValues(int? expected)
		{
			long? subject = expected;

			async Task Act()
				=> await That(subject).Should().Be(expected);

			await That(Act).Should().NotThrow();
		}
	}

	public sealed class NotBeTests
	{
		[Theory]
		[InlineData(1, 2)]
		[InlineData(5, -3)]
		public async Task WhenNullableSubjectIsDifferent_ShouldSucceed(int? subject, int? expected)
		{
			async Task Act()
				=> await That(subject).Should().NotBe(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[AutoData]
		public async Task WhenNullableSubjectIsTheSame_ShouldFail(int? subject)
		{
			int? expected = subject;

			async Task Act()
				=> await That(subject).Should().NotBe(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              not be {expected},
				              but found {subject}
				              at Expect.That(subject).Should().NotBe(expected)
				              """);
		}

		[Theory]
		[InlineData(1, 2)]
		[InlineData(5, -3)]
		public async Task WhenSubjectIsDifferent_ShouldSucceed(int subject, int expected)
		{
			async Task Act()
				=> await That(subject).Should().NotBe(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[AutoData]
		public async Task WhenSubjectIsTheSame_ShouldFail(int subject)
		{
			int expected = subject;

			async Task Act()
				=> await That(subject).Should().NotBe(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              not be {expected},
				              but found {subject}
				              at Expect.That(subject).Should().NotBe(expected)
				              """);
		}
	}
}
