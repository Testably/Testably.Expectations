using System.Globalization;

namespace Testably.Expectations.Tests.ThatTests.Numbers;

public sealed partial class NumberShould
{
	public sealed class BeGreaterThanTests
	{
		[Theory]
		[AutoData]
		public async Task ShouldFailForFloatComparisonWithNull(float subject)
		{
			float? expected = null;

			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than <null>,
				              but found {subject}
				              at Expect.That(subject).Should().BeGreaterThan(expected)
				              """);
		}

		[Theory]
		[AutoData]
		public async Task ShouldFailForIntegerComparisonWithNull(int subject)
		{
			int? expected = null;

			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than <null>,
				              but found {subject}
				              at Expect.That(subject).Should().BeGreaterThan(expected)
				              """);
		}

		[Theory]
		[AutoData]
		public async Task ShouldFailForNullableFloatComparisonWithNull(float? subject)
		{
			float? expected = null;

			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than <null>,
				              but found {subject}
				              at Expect.That(subject).Should().BeGreaterThan(expected)
				              """);
		}

		[Theory]
		[AutoData]
		public async Task ShouldFailForNullableIntegerComparisonWithNull(int? subject)
		{
			int? expected = null;

			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than <null>,
				              but found {subject}
				              at Expect.That(subject).Should().BeGreaterThan(expected)
				              """);
		}

		[Theory]
		[InlineData(1.0F, 2.1F)]
		[InlineData(-3.03F, 5.8F)]
		[InlineData(0.0F, 0.0F)]
		public async Task ShouldFailForSmallerOrEqualFloatValues(
			float subject, float expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than {expected.ToString(CultureInfo.InvariantCulture)},
				              but found {subject.ToString(CultureInfo.InvariantCulture)}
				              at Expect.That(subject).Should().BeGreaterThan(expected)
				              """);
		}

		[Theory]
		[InlineData(1, 2)]
		[InlineData(-3, 5)]
		[InlineData(0, 0)]
		public async Task ShouldFailForSmallerOrEqualIntegerValues(
			int subject, int expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than {expected},
				              but found {subject}
				              at Expect.That(subject).Should().BeGreaterThan(expected)
				              """);
		}

		[Theory]
		[InlineData(1.0F, 2.1F)]
		[InlineData(-3.03F, 5.8F)]
		[InlineData(0.0F, 0.0F)]
		public async Task ShouldFailForSmallerOrEqualNullableFloatValues(
			float? subject, float? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than {expected?.ToString(CultureInfo.InvariantCulture) ?? "<null>"},
				              but found {subject?.ToString(CultureInfo.InvariantCulture) ?? "<null>"}
				              at Expect.That(subject).Should().BeGreaterThan(expected)
				              """);
		}

		[Theory]
		[InlineData(1, 2)]
		[InlineData(-3, 5)]
		[InlineData(0, 0)]
		public async Task ShouldFailForSmallerOrEqualNullableIntegerValues(
			int? subject, int? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than {expected},
				              but found {subject}
				              at Expect.That(subject).Should().BeGreaterThan(expected)
				              """);
		}

		[Theory]
		[InlineData(2.0, 1.0F)]
		public async Task ShouldSucceedForLargerDoubleAndFloatValues(double subject, float expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(2.0F, 1.0F)]
		public async Task ShouldSucceedForLargerFloatValueAndNullableValue(float subject,
			float? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(2.0F, 1.0F)]
		public async Task ShouldSucceedForLargerFloatValues(float subject, float expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(2, 1)]
		public async Task ShouldSucceedForLargerIntegerValueAndNullableValue(int subject,
			int? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(2, 1)]
		public async Task ShouldSucceedForLargerIntegerValues(int subject, int expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(2L, 1)]
		public async Task ShouldSucceedForLargerLongAndIntegerValues(long subject, int expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(2.0, 1.0F)]
		public async Task ShouldSucceedForLargerNullableDoubleAndNullableFloatValues(
			double? subject, float? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(2.0F, 1.0F)]
		public async Task ShouldSucceedForLargerNullableFloatValueAndExpectedValue(float? subject,
			float expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(2.0F, 1.0F)]
		public async Task ShouldSucceedForLargerNullableFloatValues(float? subject, float? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(2, 1)]
		public async Task ShouldSucceedForLargerNullableIntegerValueAndExpectedValue(int? subject,
			int expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(2, 1)]
		public async Task ShouldSucceedForLargerNullableIntegerValues(int? subject, int? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(2L, 1)]
		public async Task ShouldSucceedForLargerNullableLongAndNullableIntegerValues(long? subject,
			int? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().NotThrow();
		}
	}
}
