using System.Globalization;

namespace Testably.Expectations.Tests.ThatTests.Numbers;

public sealed partial class NumberShould
{
	public sealed class BeLessThanOrEqualToTests
	{
		[Theory]
		[AutoData]
		public async Task ShouldFailForFloatComparisonWithNull(float subject)
		{
			float? expected = null;

			async Task Act()
				=> await That(subject).Should().BeLessThanOrEqualTo(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be less than or equal to <null>,
				              but found {subject}
				              at Expect.That(subject).Should().BeLessThanOrEqualTo(expected)
				              """);
		}

		[Theory]
		[AutoData]
		public async Task ShouldFailForIntegerComparisonWithNull(int subject)
		{
			int? expected = null;

			async Task Act()
				=> await That(subject).Should().BeLessThanOrEqualTo(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be less than or equal to <null>,
				              but found {subject}
				              at Expect.That(subject).Should().BeLessThanOrEqualTo(expected)
				              """);
		}

		[Theory]
		[InlineData(2.1F, 1.0F)]
		[InlineData(5.8F, -3.03F)]
		public async Task ShouldFailForLargerFloatValues(
			float subject, float expected)
		{
			async Task Act()
				=> await That(subject).Should().BeLessThanOrEqualTo(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be less than or equal to {expected.ToString(CultureInfo.InvariantCulture)},
				              but found {subject.ToString(CultureInfo.InvariantCulture)}
				              at Expect.That(subject).Should().BeLessThanOrEqualTo(expected)
				              """);
		}

		[Theory]
		[InlineData(2, 1)]
		[InlineData(5, -3)]
		public async Task ShouldFailForLargerIntegerValues(
			int subject, int expected)
		{
			async Task Act()
				=> await That(subject).Should().BeLessThanOrEqualTo(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be less than or equal to {expected},
				              but found {subject}
				              at Expect.That(subject).Should().BeLessThanOrEqualTo(expected)
				              """);
		}

		[Theory]
		[InlineData(2.1F, 1.0F)]
		[InlineData(5.8F, -3.03F)]
		public async Task ShouldFailForLargerNullableFloatValues(
			float? subject, float? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeLessThanOrEqualTo(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be less than or equal to {expected?.ToString(CultureInfo.InvariantCulture) ?? "<null>"},
				              but found {subject?.ToString(CultureInfo.InvariantCulture) ?? "<null>"}
				              at Expect.That(subject).Should().BeLessThanOrEqualTo(expected)
				              """);
		}

		[Theory]
		[InlineData(2, 1)]
		[InlineData(5, -3)]
		public async Task ShouldFailForLargerNullableIntegerValues(
			int? subject, int? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeLessThanOrEqualTo(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be less than or equal to {expected},
				              but found {subject}
				              at Expect.That(subject).Should().BeLessThanOrEqualTo(expected)
				              """);
		}

		[Theory]
		[AutoData]
		public async Task ShouldFailForNullableFloatComparisonWithNull(float? subject)
		{
			float? expected = null;

			async Task Act()
				=> await That(subject).Should().BeLessThanOrEqualTo(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be less than or equal to <null>,
				              but found {subject}
				              at Expect.That(subject).Should().BeLessThanOrEqualTo(expected)
				              """);
		}

		[Theory]
		[AutoData]
		public async Task ShouldFailForNullableIntegerComparisonWithNull(int? subject)
		{
			int? expected = null;

			async Task Act()
				=> await That(subject).Should().BeLessThanOrEqualTo(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be less than or equal to <null>,
				              but found {subject}
				              at Expect.That(subject).Should().BeLessThanOrEqualTo(expected)
				              """);
		}

		[Theory]
		[InlineData(1.0, 2.0F)]
		[InlineData(0.0, 0.0F)]
		public async Task ShouldSucceedForSmallerOrEqualDoubleAndFloatValues(double subject,
			float expected)
		{
			async Task Act()
				=> await That(subject).Should().BeLessThanOrEqualTo(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(1.0F, 2.0F)]
		[InlineData(0.0F, 0.0F)]
		public async Task ShouldSucceedForSmallerOrEqualFloatValueAndNullableValue(float subject,
			float? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeLessThanOrEqualTo(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(1.0F, 2.0F)]
		[InlineData(0.0F, 0.0F)]
		public async Task ShouldSucceedForSmallerOrEqualFloatValues(float subject, float expected)
		{
			async Task Act()
				=> await That(subject).Should().BeLessThanOrEqualTo(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(1, 2)]
		[InlineData(0, 0)]
		public async Task ShouldSucceedForSmallerOrEqualIntegerValueAndNullableValue(int subject,
			int? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeLessThanOrEqualTo(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(1, 2)]
		[InlineData(0, 0)]
		public async Task ShouldSucceedForSmallerOrEqualIntegerValues(int subject, int expected)
		{
			async Task Act()
				=> await That(subject).Should().BeLessThanOrEqualTo(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(1L, 2)]
		[InlineData(0L, 0)]
		public async Task ShouldSucceedForSmallerOrEqualLongAndIntegerValues(long subject,
			int expected)
		{
			async Task Act()
				=> await That(subject).Should().BeLessThanOrEqualTo(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(1.0, 2.0F)]
		[InlineData(0.0, 0.0F)]
		public async Task ShouldSucceedForSmallerOrEqualNullableDoubleAndNullableFloatValues(
			double? subject, float? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeLessThanOrEqualTo(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(1.0F, 2.0F)]
		[InlineData(0.0F, 0.0F)]
		public async Task ShouldSucceedForSmallerOrEqualNullableFloatValueAndExpectedValue(
			float? subject,
			float expected)
		{
			async Task Act()
				=> await That(subject).Should().BeLessThanOrEqualTo(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(1.0F, 2.0F)]
		[InlineData(0.0F, 0.0F)]
		public async Task ShouldSucceedForSmallerOrEqualNullableFloatValues(float? subject,
			float? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeLessThanOrEqualTo(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(1, 2)]
		[InlineData(0, 0)]
		public async Task ShouldSucceedForSmallerOrEqualNullableIntegerValueAndExpectedValue(
			int? subject,
			int expected)
		{
			async Task Act()
				=> await That(subject).Should().BeLessThanOrEqualTo(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(1, 2)]
		[InlineData(0, 0)]
		public async Task ShouldSucceedForSmallerOrEqualNullableIntegerValues(int? subject,
			int? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeLessThanOrEqualTo(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(1L, 2)]
		[InlineData(0L, 0)]
		public async Task ShouldSucceedForSmallerOrEqualNullableLongAndNullableIntegerValues(
			long? subject,
			int? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeLessThanOrEqualTo(expected);

			await That(Act).Should().NotThrow();
		}
	}
}
