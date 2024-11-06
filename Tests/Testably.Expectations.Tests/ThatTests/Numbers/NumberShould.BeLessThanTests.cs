using System.Globalization;

namespace Testably.Expectations.Tests.ThatTests.Numbers;

public sealed partial class NumberShould
{
	public sealed class BeLessThanTests
	{
		[Theory]
		[AutoData]
		public async Task ShouldFailForFloatComparisonWithNull(float subject)
		{
			float? expected = null;

			async Task Act()
				=> await That(subject).Should().BeLessThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be less than <null>,
				              but found {subject}
				              at Expect.That(subject).Should().BeLessThan(expected)
				              """);
		}

		[Theory]
		[AutoData]
		public async Task ShouldFailForIntegerComparisonWithNull(int subject)
		{
			int? expected = null;

			async Task Act()
				=> await That(subject).Should().BeLessThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be less than <null>,
				              but found {subject}
				              at Expect.That(subject).Should().BeLessThan(expected)
				              """);
		}

		[Theory]
		[AutoData]
		public async Task ShouldFailForNullableFloatComparisonWithNull(float? subject)
		{
			float? expected = null;

			async Task Act()
				=> await That(subject).Should().BeLessThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be less than <null>,
				              but found {subject}
				              at Expect.That(subject).Should().BeLessThan(expected)
				              """);
		}

		[Theory]
		[AutoData]
		public async Task ShouldFailForNullableIntegerComparisonWithNull(int? subject)
		{
			int? expected = null;

			async Task Act()
				=> await That(subject).Should().BeLessThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be less than <null>,
				              but found {subject}
				              at Expect.That(subject).Should().BeLessThan(expected)
				              """);
		}

		[Theory]
		[InlineData(2.1F, 1.0F)]
		[InlineData(5.8F, -3.03F)]
		[InlineData(0.0F, 0.0F)]
		public async Task ShouldFailForLargerOrEqualFloatValues(
			float subject, float expected)
		{
			async Task Act()
				=> await That(subject).Should().BeLessThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be less than {expected.ToString(CultureInfo.InvariantCulture)},
				              but found {subject.ToString(CultureInfo.InvariantCulture)}
				              at Expect.That(subject).Should().BeLessThan(expected)
				              """);
		}

		[Theory]
		[InlineData(2, 1)]
		[InlineData(5, -3)]
		[InlineData(0, 0)]
		public async Task ShouldFailForLargerOrEqualIntegerValues(
			int subject, int expected)
		{
			async Task Act()
				=> await That(subject).Should().BeLessThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be less than {expected},
				              but found {subject}
				              at Expect.That(subject).Should().BeLessThan(expected)
				              """);
		}

		[Theory]
		[InlineData(2.1F, 1.0F)]
		[InlineData(5.8F, -3.03F)]
		[InlineData(0.0F, 0.0F)]
		public async Task ShouldFailForLargerOrEqualNullableFloatValues(
			float? subject, float? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeLessThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be less than {expected?.ToString(CultureInfo.InvariantCulture) ?? "<null>"},
				              but found {subject?.ToString(CultureInfo.InvariantCulture) ?? "<null>"}
				              at Expect.That(subject).Should().BeLessThan(expected)
				              """);
		}

		[Theory]
		[InlineData(2, 1)]
		[InlineData(5, -3)]
		[InlineData(0, 0)]
		public async Task ShouldFailForLargerOrEqualNullableIntegerValues(
			int? subject, int? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeLessThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be less than {expected},
				              but found {subject}
				              at Expect.That(subject).Should().BeLessThan(expected)
				              """);
		}

		[Theory]
		[InlineData(1.0, 2.0F)]
		public async Task ShouldSucceedForSmallerDoubleAndFloatValues(double subject, float expected)
		{
			async Task Act()
				=> await That(subject).Should().BeLessThan(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(1.0F, 2.0F)]
		public async Task ShouldSucceedForSmallerFloatValueAndNullableValue(float subject,
			float? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeLessThan(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(1.0F, 2.0F)]
		public async Task ShouldSucceedForSmallerFloatValues(float subject, float expected)
		{
			async Task Act()
				=> await That(subject).Should().BeLessThan(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(1, 2)]
		public async Task ShouldSucceedForSmallerIntegerValueAndNullableValue(int subject,
			int? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeLessThan(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(1, 2)]
		public async Task ShouldSucceedForSmallerIntegerValues(int subject, int expected)
		{
			async Task Act()
				=> await That(subject).Should().BeLessThan(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(1L, 2)]
		public async Task ShouldSucceedForSmallerLongAndIntegerValues(long subject, int expected)
		{
			async Task Act()
				=> await That(subject).Should().BeLessThan(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(1.0, 2.0F)]
		public async Task ShouldSucceedForSmallerNullableDoubleAndNullableFloatValues(
			double? subject, float? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeLessThan(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(1.0F, 2.0F)]
		public async Task ShouldSucceedForSmallerNullableFloatValueAndExpectedValue(float? subject,
			float expected)
		{
			async Task Act()
				=> await That(subject).Should().BeLessThan(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(1.0F, 2.0F)]
		public async Task ShouldSucceedForSmallerNullableFloatValues(float? subject, float? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeLessThan(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(1, 2)]
		public async Task ShouldSucceedForSmallerNullableIntegerValueAndExpectedValue(int? subject,
			int expected)
		{
			async Task Act()
				=> await That(subject).Should().BeLessThan(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(1, 2)]
		public async Task ShouldSucceedForSmallerNullableIntegerValues(int? subject, int? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeLessThan(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(1L, 2)]
		public async Task ShouldSucceedForSmallerNullableLongAndNullableIntegerValues(long? subject,
			int? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeLessThan(expected);

			await That(Act).Should().NotThrow();
		}
	}
}
