﻿namespace Testably.Expectations.Tests.ThatTests.Numbers;

public sealed partial class NumberShould
{
	public sealed class BeGreaterThanTests
	{
		[Theory]
		[AutoData]
		public async Task ForByte_WhenExpectedIsNull_ShouldFail(
			byte subject)
		{
			byte? expected = null;

			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than <null>,
				              but found {Formatter.Format(subject)}.
				              """);
		}

		[Theory]
		[InlineData((byte)2, (byte)1)]
		public async Task ForByte_WhenValueIsGreaterThanExpected_ShouldSucceed(byte subject,
			byte? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData((byte)1, (byte)2)]
		[InlineData((byte)0, (byte)0)]
		public async Task ForByte_WhenValueIsLessThanOrEqualToExpected_ShouldFail(byte subject,
			byte? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than {Formatter.Format(expected)},
				              but found {Formatter.Format(subject)}.
				              """);
		}

		[Theory]
		[AutoData]
		public async Task ForDecimal_WhenExpectedIsNull_ShouldFail(decimal subject)
		{
			decimal? expected = null;

			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than <null>,
				              but found {Formatter.Format(subject)}.
				              """);
		}

		[Theory]
		[InlineData(2.1, 1.1)]
		public async Task ForDecimal_WhenValueIsGreaterThanExpected_ShouldSucceed(
			double subjectValue, double expectedValue)
		{
			decimal subject = new(subjectValue);
			decimal? expected = new(expectedValue);

			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(1.0, 2.1)]
		[InlineData(-3.03, 5.8)]
		[InlineData(0.0, 0.0)]
		public async Task ForDecimal_WhenValueIsLessThanOrEqualToExpected_ShouldFail(
			double subjectValue, double expectedValue)
		{
			decimal subject = new(subjectValue);
			decimal expected = new(expectedValue);

			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than {Formatter.Format(expected)},
				              but found {Formatter.Format(subject)}.
				              """);
		}

		[Theory]
		[AutoData]
		public async Task ForDouble_WhenExpectedIsNull_ShouldFail(double subject)
		{
			double? expected = null;

			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than <null>,
				              but found {Formatter.Format(subject)}.
				              """);
		}

		[Theory]
		[InlineData(2.0, 1.0F)]
		public async Task ForDouble_WhenExpectedIsSmallerFloat_ShouldSucceed(double subject,
			float expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(double.NaN, 0.0)]
		[InlineData(0.0, double.NaN)]
		public async Task ForDouble_WhenSubjectOrExpectedIsNaN_ShouldFail(
			double subject, double expected)
		{
			async Task Act() => await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than {Formatter.Format(expected)},
				              but found {Formatter.Format(subject)}.
				              """);
		}

		[Theory]
		[InlineData(2.1, 1.1)]
		public async Task ForDouble_WhenValueIsGreaterThanExpected_ShouldSucceed(
			double subject, double? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(1.0, 2.1)]
		[InlineData(-3.03, 5.8)]
		[InlineData(0.0, 0.0)]
		public async Task ForDouble_WhenValueIsLessThanOrEqualToExpected_ShouldFail(
			double subject, double? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than {Formatter.Format(expected)},
				              but found {Formatter.Format(subject)}.
				              """);
		}

		[Theory]
		[AutoData]
		public async Task ForFloat_WhenExpectedIsNull_ShouldFail(float subject)
		{
			float? expected = null;

			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than <null>,
				              but found {Formatter.Format(subject)}.
				              """);
		}

		[Theory]
		[InlineData(float.NaN, 0.0)]
		[InlineData(0.0, float.NaN)]
		public async Task ForFloat_WhenSubjectOrExpectedIsNaN_ShouldFail(
			float subject, float expected)
		{
			async Task Act() => await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than {Formatter.Format(expected)},
				              but found {Formatter.Format(subject)}.
				              """);
		}

		[Theory]
		[InlineData((float)2.1, (float)1.1)]
		public async Task ForFloat_WhenValueIsGreaterThanExpected_ShouldSucceed(
			float subject, float? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData((float)1.0, (float)2.1)]
		[InlineData((float)-3.03, (float)5.8)]
		[InlineData((float)0.0, (float)0.0)]
		public async Task ForFloat_WhenValueIsLessThanOrEqualToExpected_ShouldFail(
			float subject, float? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than {Formatter.Format(expected)},
				              but found {Formatter.Format(subject)}.
				              """);
		}

		[Theory]
		[AutoData]
		public async Task ForInt_WhenExpectedIsNull_ShouldFail(
			int subject)
		{
			int? expected = null;

			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than <null>,
				              but found {Formatter.Format(subject)}.
				              """);
		}

		[Theory]
		[InlineData(2, 1)]
		public async Task ForInt_WhenValueIsGreaterThanExpected_ShouldSucceed(int subject,
			int? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(-2, -1)]
		[InlineData(0, 0)]
		public async Task ForInt_WhenValueIsLessThanOrEqualToExpected_ShouldFail(int subject,
			int? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than {Formatter.Format(expected)},
				              but found {Formatter.Format(subject)}.
				              """);
		}

		[Theory]
		[AutoData]
		public async Task ForLong_WhenExpectedIsNull_ShouldFail(
			long subject)
		{
			long? expected = null;

			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than <null>,
				              but found {Formatter.Format(subject)}.
				              """);
		}

		[Theory]
		[InlineData(2L, 1)]
		public async Task ForLong_WhenExpectedIsSmallerInt_ShouldSucceed(long subject, int expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData((long)2, (long)1)]
		public async Task ForLong_WhenValueIsGreaterThanExpected_ShouldSucceed(long subject,
			long? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData((long)-2, (long)-1)]
		[InlineData((long)0, (long)0)]
		public async Task ForLong_WhenValueIsLessThanOrEqualToExpected_ShouldFail(long subject,
			long? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than {Formatter.Format(expected)},
				              but found {Formatter.Format(subject)}.
				              """);
		}

		[Theory]
		[InlineData((byte)2, (byte)1)]
		public async Task ForNullableByte_WhenValueIsGreaterThanExpected_ShouldSucceed(
			byte? subject, byte? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData((byte)1, (byte)2)]
		[InlineData((byte)0, (byte)0)]
		public async Task ForNullableByte_WhenValueIsLessThanOrEqualToExpected_ShouldFail(
			byte? subject, byte? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than {Formatter.Format(expected)},
				              but found {Formatter.Format(subject)}.
				              """);
		}

		[Theory]
		[AutoData]
		public async Task ForNullableByte_WhenValueIsNull_ShouldFail(
			byte? expected)
		{
			byte? subject = null;

			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than {Formatter.Format(expected)},
				              but found <null>.
				              """);
		}

		[Theory]
		[AutoData]
		public async Task ForNullableDecimal_WhenExpectedIsNull_ShouldFail(decimal? subject)
		{
			decimal? expected = null;

			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than <null>,
				              but found {Formatter.Format(subject)}.
				              """);
		}

		[Theory]
		[InlineData(2.1, 1.1)]
		public async Task ForNullableDecimal_WhenValueIsGreaterThanExpected_ShouldSucceed(
			double? subjectValue, double? expectedValue)
		{
			decimal? subject = subjectValue == null ? null : new decimal(subjectValue.Value);
			decimal? expected = expectedValue == null ? null : new decimal(expectedValue.Value);

			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(1.1, 2.1)]
		[InlineData(-3.03, 5.8)]
		[InlineData(0.0, 0.0)]
		public async Task ForNullableDecimal_WhenValueIsLessThanOrEqualToExpected_ShouldFail(
			double? subjectValue, double? expectedValue)
		{
			decimal? subject = subjectValue == null ? null : new decimal(subjectValue.Value);
			decimal? expected = expectedValue == null ? null : new decimal(expectedValue.Value);

			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than {Formatter.Format(expected)},
				              but found {Formatter.Format(subject)}.
				              """);
		}

		[Theory]
		[AutoData]
		public async Task ForNullableDouble_WhenExpectedIsNull_ShouldFail(double? subject)
		{
			double? expected = null;

			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than <null>,
				              but found {Formatter.Format(subject)}.
				              """);
		}

		[Theory]
		[InlineData(2.1, 1.1)]
		public async Task ForNullableDouble_WhenValueIsGreaterThanExpected_ShouldSucceed(
			double? subject, double? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(1.1, 2.1)]
		[InlineData(-3.03, 5.8)]
		[InlineData(0.0, 0.0)]
		public async Task ForNullableDouble_WhenValueIsLessThanOrEqualToExpected_ShouldFail(
			double? subject, double? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than {Formatter.Format(expected)},
				              but found {Formatter.Format(subject)}.
				              """);
		}

		[Theory]
		[AutoData]
		public async Task ForNullableFloat_WhenExpectedIsNull_ShouldFail(float? subject)
		{
			float? expected = null;

			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than <null>,
				              but found {Formatter.Format(subject)}.
				              """);
		}

		[Theory]
		[InlineData((float)2.1, (float)1.1)]
		public async Task ForNullableFloat_WhenValueIsGreaterThanExpected_ShouldSucceed(
			float? subject, float? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData((float)1.1, (float)2.1)]
		[InlineData((float)-3.03, (float)5.8)]
		[InlineData((float)0.0, (float)0.0)]
		public async Task ForNullableFloat_WhenValueIsLessThanOrEqualToExpected_ShouldFail(
			float? subject, float? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than {Formatter.Format(expected)},
				              but found {Formatter.Format(subject)}.
				              """);
		}

		[Theory]
		[InlineData(2, 1)]
		public async Task ForNullableInt_WhenValueIsGreaterThanExpected_ShouldSucceed(
			int? subject, int? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(-2, -1)]
		[InlineData(0, 0)]
		public async Task ForNullableInt_WhenValueIsLessThanOrEqualToExpected_ShouldFail(
			int? subject, int? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than {Formatter.Format(expected)},
				              but found {Formatter.Format(subject)}.
				              """);
		}

		[Theory]
		[AutoData]
		public async Task ForNullableInt_WhenValueIsNull_ShouldFail(
			int? expected)
		{
			int? subject = null;

			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than {Formatter.Format(expected)},
				              but found <null>.
				              """);
		}

		[Theory]
		[InlineData((long)2, (long)1)]
		public async Task ForNullableLong_WhenValueIsGreaterThanExpected_ShouldSucceed(
			long? subject, long? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData((long)-2, (long)-1)]
		[InlineData((long)0, (long)0)]
		public async Task ForNullableLong_WhenValueIsLessThanOrEqualToExpected_ShouldFail(
			long? subject, long? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than {Formatter.Format(expected)},
				              but found {Formatter.Format(subject)}.
				              """);
		}

		[Theory]
		[AutoData]
		public async Task ForNullableLong_WhenValueIsNull_ShouldFail(
			long? expected)
		{
			long? subject = null;

			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than {Formatter.Format(expected)},
				              but found <null>.
				              """);
		}

		[Theory]
		[InlineData((sbyte)2, (sbyte)1)]
		public async Task ForNullableSbyte_WhenValueIsGreaterThanExpected_ShouldSucceed(
			sbyte? subject, sbyte? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData((sbyte)-2, (sbyte)-1)]
		[InlineData((sbyte)0, (sbyte)0)]
		public async Task ForNullableSbyte_WhenValueIsLessThanOrEqualToExpected_ShouldFail(
			sbyte? subject, sbyte? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than {Formatter.Format(expected)},
				              but found {Formatter.Format(subject)}.
				              """);
		}

		[Theory]
		[AutoData]
		public async Task ForNullableSbyte_WhenValueIsNull_ShouldFail(
			sbyte? expected)
		{
			sbyte? subject = null;

			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than {Formatter.Format(expected)},
				              but found <null>.
				              """);
		}

		[Theory]
		[InlineData((short)2, (short)1)]
		public async Task ForNullableShort_WhenValueIsGreaterThanExpected_ShouldSucceed(
			short? subject, short? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData((short)-2, (short)-1)]
		[InlineData((short)0, (short)0)]
		public async Task ForNullableShort_WhenValueIsLessThanOrEqualToExpected_ShouldFail(
			short? subject, short? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than {Formatter.Format(expected)},
				              but found {Formatter.Format(subject)}.
				              """);
		}

		[Theory]
		[AutoData]
		public async Task ForNullableShort_WhenValueIsNull_ShouldFail(
			short? expected)
		{
			short? subject = null;

			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than {Formatter.Format(expected)},
				              but found <null>.
				              """);
		}

		[Theory]
		[InlineData((uint)2, (uint)1)]
		public async Task ForNullableUint_WhenValueIsGreaterThanExpected_ShouldSucceed(
			uint? subject, uint? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData((uint)1, (uint)2)]
		[InlineData((uint)0, (uint)0)]
		public async Task ForNullableUint_WhenValueIsLessThanOrEqualToExpected_ShouldFail(
			uint? subject, uint? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than {Formatter.Format(expected)},
				              but found {Formatter.Format(subject)}.
				              """);
		}

		[Theory]
		[AutoData]
		public async Task ForNullableUint_WhenValueIsNull_ShouldFail(
			uint? expected)
		{
			uint? subject = null;

			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than {Formatter.Format(expected)},
				              but found <null>.
				              """);
		}

		[Theory]
		[InlineData((ulong)2, (ulong)1)]
		public async Task ForNullableUlong_WhenValueIsGreaterThanExpected_ShouldSucceed(
			ulong? subject, ulong? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData((ulong)1, (ulong)2)]
		[InlineData((ulong)0, (ulong)0)]
		public async Task ForNullableUlong_WhenValueIsLessThanOrEqualToExpected_ShouldFail(
			ulong? subject, ulong? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than {Formatter.Format(expected)},
				              but found {Formatter.Format(subject)}.
				              """);
		}

		[Theory]
		[AutoData]
		public async Task ForNullableUlong_WhenValueIsNull_ShouldFail(
			ulong? expected)
		{
			ulong? subject = null;

			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than {Formatter.Format(expected)},
				              but found <null>.
				              """);
		}

		[Theory]
		[InlineData((ushort)2, (ushort)1)]
		public async Task ForNullableUshort_WhenValueIsGreaterThanExpected_ShouldSucceed(
			ushort? subject, ushort? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData((ushort)1, (ushort)2)]
		[InlineData((ushort)0, (ushort)0)]
		public async Task ForNullableUshort_WhenValueIsLessThanOrEqualToExpected_ShouldFail(
			ushort? subject, ushort? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than {Formatter.Format(expected)},
				              but found {Formatter.Format(subject)}.
				              """);
		}

		[Theory]
		[AutoData]
		public async Task ForNullableUshort_WhenValueIsNull_ShouldFail(
			ushort? expected)
		{
			ushort? subject = null;

			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than {Formatter.Format(expected)},
				              but found <null>.
				              """);
		}

		[Theory]
		[AutoData]
		public async Task ForSbyte_WhenExpectedIsNull_ShouldFail(
			sbyte subject)
		{
			sbyte? expected = null;

			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than <null>,
				              but found {Formatter.Format(subject)}.
				              """);
		}

		[Theory]
		[InlineData((sbyte)2, (sbyte)1)]
		public async Task ForSbyte_WhenValueIsGreaterThanExpected_ShouldSucceed(sbyte subject,
			sbyte? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData((sbyte)-2, (sbyte)-1)]
		[InlineData((sbyte)0, (sbyte)0)]
		public async Task ForSbyte_WhenValueIsLessThanOrEqualToExpected_ShouldFail(sbyte subject,
			sbyte? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than {Formatter.Format(expected)},
				              but found {Formatter.Format(subject)}.
				              """);
		}

		[Theory]
		[AutoData]
		public async Task ForShort_WhenExpectedIsNull_ShouldFail(
			short subject)
		{
			short? expected = null;

			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than <null>,
				              but found {Formatter.Format(subject)}.
				              """);
		}

		[Theory]
		[InlineData((short)2, (short)1)]
		public async Task ForShort_WhenValueIsGreaterThanExpected_ShouldSucceed(short subject,
			short? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData((short)-2, (short)-1)]
		[InlineData((short)0, (short)0)]
		public async Task ForShort_WhenValueIsLessThanOrEqualToExpected_ShouldFail(short subject,
			short? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than {Formatter.Format(expected)},
				              but found {Formatter.Format(subject)}.
				              """);
		}

		[Theory]
		[AutoData]
		public async Task ForUint_WhenExpectedIsNull_ShouldFail(
			uint subject)
		{
			uint? expected = null;

			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than <null>,
				              but found {Formatter.Format(subject)}.
				              """);
		}

		[Theory]
		[InlineData((uint)2, (uint)1)]
		public async Task ForUint_WhenValueIsGreaterThanExpected_ShouldSucceed(uint subject,
			uint? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData((uint)1, (uint)2)]
		[InlineData((uint)0, (uint)0)]
		public async Task ForUint_WhenValueIsLessThanOrEqualToExpected_ShouldFail(uint subject,
			uint? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than {Formatter.Format(expected)},
				              but found {Formatter.Format(subject)}.
				              """);
		}

		[Theory]
		[AutoData]
		public async Task ForUlong_WhenExpectedIsNull_ShouldFail(
			ulong subject)
		{
			ulong? expected = null;

			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than <null>,
				              but found {Formatter.Format(subject)}.
				              """);
		}

		[Theory]
		[InlineData((ulong)2, (ulong)1)]
		public async Task ForUlong_WhenValueIsGreaterThanExpected_ShouldSucceed(ulong subject,
			ulong? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData((ulong)1, (ulong)2)]
		[InlineData((ulong)0, (ulong)0)]
		public async Task ForUlong_WhenValueIsLessThanOrEqualToExpected_ShouldFail(ulong subject,
			ulong? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than {Formatter.Format(expected)},
				              but found {Formatter.Format(subject)}.
				              """);
		}

		[Theory]
		[AutoData]
		public async Task ForUshort_WhenExpectedIsNull_ShouldFail(
			ushort subject)
		{
			ushort? expected = null;

			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than <null>,
				              but found {Formatter.Format(subject)}.
				              """);
		}

		[Theory]
		[InlineData((ushort)2, (ushort)1)]
		public async Task ForUshort_WhenValueIsGreaterThanExpected_ShouldSucceed(ushort subject,
			ushort? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData((ushort)1, (ushort)2)]
		[InlineData((ushort)0, (ushort)0)]
		public async Task ForUshort_WhenValueIsLessThanOrEqualToExpected_ShouldFail(ushort subject,
			ushort? expected)
		{
			async Task Act()
				=> await That(subject).Should().BeGreaterThan(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be greater than {Formatter.Format(expected)},
				              but found {Formatter.Format(subject)}.
				              """);
		}
	}
}
