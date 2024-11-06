using System.Globalization;

namespace Testably.Expectations.Tests.ThatTests.Numbers;

public sealed partial class NumberShould
{
	public sealed class BeGreaterThanOrEqualToTests
	{
		[Theory]
		[AutoData]
		public async Task ShouldFailForFloatComparisonWithNull(float subject)
		{
			float? expected = null;

			async Task Act()
				=> await That(subject).Should().BeGreaterThanOrEqualTo(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than or equal to <null>,
				              but found {subject}
				              at Expect.That(subject).Should().BeGreaterThanOrEqualTo(expected)
				              """);
		}

		[Theory]
		[AutoData]
		public async Task ShouldFailForIntegerComparisonWithNull(int subject)
		{
			int? expected = null;

			async Task Act()
				=> await That(subject).Should().BeGreaterThanOrEqualTo(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than or equal to <null>,
				              but found {subject}
				              at Expect.That(subject).Should().BeGreaterThanOrEqualTo(expected)
				              """);
		}

		[Theory]
		[AutoData]
		public async Task ShouldFailForNullableFloatComparisonWithNull(float? subject)
		{
			float? expected = null;

			async Task Act()
				=> await That(subject).Should().BeGreaterThanOrEqualTo(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than or equal to <null>,
				              but found {subject}
				              at Expect.That(subject).Should().BeGreaterThanOrEqualTo(expected)
				              """);
		}

		[Theory]
		[AutoData]
		public async Task ShouldFailForNullableIntegerComparisonWithNull(int? subject)
		{
			int? expected = null;

			async Task Act()
				=> await That(subject).Should().BeGreaterThanOrEqualTo(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than or equal to <null>,
				              but found {subject}
				              at Expect.That(subject).Should().BeGreaterThanOrEqualTo(expected)
				              """);
		}

		[Theory]
		[InlineData(1.0F, 2.1F)]
		[InlineData(-3.03F, 5.8F)]
		public async Task ShouldFailForSmallerFloatValues(
			float subject, float expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThanOrEqualTo(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than or equal to {expected.ToString(CultureInfo.InvariantCulture)},
				              but found {subject.ToString(CultureInfo.InvariantCulture)}
				              at Expect.That(subject).Should().BeGreaterThanOrEqualTo(expected)
				              """);
		}

		[Theory]
		[InlineData(1, 2)]
		[InlineData(-3, 5)]
		public async Task ShouldFailForSmallerIntegerValues(
			int subject, int expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThanOrEqualTo(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than or equal to {expected},
				              but found {subject}
				              at Expect.That(subject).Should().BeGreaterThanOrEqualTo(expected)
				              """);
		}

		[Theory]
		[InlineData(1.0F, 2.1F)]
		[InlineData(-3.03F, 5.8F)]
		public async Task ShouldFailForSmallerNullableFloatValues(
			float? subject, float? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThanOrEqualTo(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than or equal to {expected?.ToString(CultureInfo.InvariantCulture) ?? "<null>"},
				              but found {subject?.ToString(CultureInfo.InvariantCulture) ?? "<null>"}
				              at Expect.That(subject).Should().BeGreaterThanOrEqualTo(expected)
				              """);
		}

		[Theory]
		[InlineData(1, 2)]
		[InlineData(-3, 5)]
		public async Task ShouldFailForSmallerNullableIntegerValues(
			int? subject, int? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThanOrEqualTo(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than or equal to {expected},
				              but found {subject}
				              at Expect.That(subject).Should().BeGreaterThanOrEqualTo(expected)
				              """);
		}

		[Theory]
		[InlineData(2.0, 1.0F)]
		[InlineData(0.0, 0.0F)]
		public async Task ShouldSucceedForLargerOrEqualDoubleAndFloatValues(double subject,
			float expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThanOrEqualTo(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(2.0F, 1.0F)]
		[InlineData(0.0F, 0.0F)]
		public async Task ShouldSucceedForLargerOrEqualFloatValueAndNullableValue(float subject,
			float? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThanOrEqualTo(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(2.0F, 1.0F)]
		[InlineData(0.0F, 0.0F)]
		public async Task ShouldSucceedForLargerOrEqualFloatValues(float subject, float expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThanOrEqualTo(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(2, 1)]
		[InlineData(0, 0)]
		public async Task ShouldSucceedForLargerOrEqualIntegerValueAndNullableValue(int subject,
			int? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThanOrEqualTo(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(2, 1)]
		[InlineData(0, 0)]
		public async Task ShouldSucceedForLargerOrEqualIntegerValues(int subject, int expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThanOrEqualTo(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(2L, 1)]
		[InlineData(0L, 0)]
		public async Task ShouldSucceedForLargerOrEqualLongAndIntegerValues(long subject,
			int expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThanOrEqualTo(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(2.0, 1.0F)]
		[InlineData(0.0, 0.0F)]
		public async Task ShouldSucceedForLargerOrEqualNullableDoubleAndNullableFloatValues(
			double? subject, float? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThanOrEqualTo(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(2.0F, 1.0F)]
		[InlineData(0.0F, 0.0F)]
		public async Task ShouldSucceedForLargerOrEqualNullableFloatValueAndExpectedValue(
			float? subject,
			float expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThanOrEqualTo(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(2.0F, 1.0F)]
		[InlineData(0.0F, 0.0F)]
		public async Task ShouldSucceedForLargerOrEqualNullableFloatValues(float? subject,
			float? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThanOrEqualTo(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(2, 1)]
		[InlineData(0, 0)]
		public async Task ShouldSucceedForLargerOrEqualNullableIntegerValueAndExpectedValue(
			int? subject,
			int expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThanOrEqualTo(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(2, 1)]
		[InlineData(0, 0)]
		public async Task ShouldSucceedForLargerOrEqualNullableIntegerValues(int? subject,
			int? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThanOrEqualTo(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(2L, 1)]
		[InlineData(0L, 0)]
		public async Task ShouldSucceedForLargerOrEqualNullableLongAndNullableIntegerValues(
			long? subject,
			int? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThanOrEqualTo(expected);

			await That(Act).Should().NotThrow();
		}
	}
}
