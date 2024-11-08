using System.Linq;
using Testably.Expectations.Formatting;

namespace Testably.Expectations.Tests.ThatTests.Numbers;

public sealed partial class NumberShould
{
	public sealed partial class BeOneOfTests
	{
		public sealed class WithinTests
		{
			[Theory]
			[InlineData((byte)5, (byte)6)]
			[InlineData((byte)5, (byte)4)]
			public async Task ForByte_WhenInsideTolerance_ShouldSucceed(
				byte subject, params byte[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Theory]
			[InlineData((byte)5, (byte)7)]
			[InlineData((byte)5, (byte)3)]
			public async Task ForByte_WhenOutsideTolerance_ShouldFail(
				byte subject, params byte[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage($"""
					              Expected subject to
					              be one of {Formatter.Format(expected)} ± 1,
					              but found 5.
					              """);
			}

			[Theory]
			[InlineData(12.5, 12.6)]
			[InlineData(12.5, 12.4)]
			public async Task ForDecimal_WhenInsideTolerance_ShouldSucceed(
				double subjectValue, params double[] expectedValues)
			{
				decimal subject = new(subjectValue);
				decimal[] expected = expectedValues
					.Select(expectedValue => new decimal(expectedValue))
					.ToArray();

				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(new decimal(0.1));

				await That(Act).Should().NotThrow();
			}

			[Theory]
			[InlineData(12.5, 12.7)]
			[InlineData(12.5, 12.3)]
			public async Task ForDecimal_WhenOutsideTolerance_ShouldFail(
				double subjectValue, params double[] expectedValues)
			{
				decimal subject = new(subjectValue);
				decimal[] expected = expectedValues
					.Select(expectedValue => new decimal(expectedValue))
					.ToArray();

				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(new decimal(0.1));

				await That(Act).Should().Throw<XunitException>()
					.WithMessage($"""
					              Expected subject to
					              be one of {Formatter.Format(expected)} ± 0.1,
					              but found 12.5.
					              """);
			}

			[Theory]
			[AutoData]
			public async Task
				ForDecimal_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException(
					decimal subject, params decimal[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(new decimal(-0.1));

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Theory]
			[InlineData(12.5, 12.6)]
			[InlineData(12.5, 12.4)]
			public async Task ForDouble_WhenInsideTolerance_ShouldSucceed(
				double subject, params double[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(0.11);

				await That(Act).Should().NotThrow();
			}

			[Theory]
			[InlineData(12.5, 12.7)]
			[InlineData(12.5, 12.3)]
			public async Task ForDouble_WhenOutsideTolerance_ShouldFail(
				double subject, params double[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(0.1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage($"""
					              Expected subject to
					              be one of {Formatter.Format(expected)} ± 0.1,
					              but found 12.5.
					              """);
			}

			[Theory]
			[AutoData]
			public async Task
				ForDouble_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException(
					double subject, params double[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(-0.1);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Theory]
			[InlineData(12.5F, 12.6F)]
			[InlineData(12.5F, 12.4F)]
			public async Task ForFloat_WhenInsideTolerance_ShouldSucceed(
				float subject, params float[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(0.11F);

				await That(Act).Should().NotThrow();
			}

			[Theory]
			[InlineData(12.5F, 12.7F)]
			[InlineData(12.5F, 12.3F)]
			public async Task ForFloat_WhenOutsideTolerance_ShouldFail(
				float subject, params float[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(0.1F);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage($"""
					              Expected subject to
					              be one of {Formatter.Format(expected)} ± 0.1,
					              but found 12.5.
					              """);
			}

			[Theory]
			[AutoData]
			public async Task
				ForFloat_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException(
					float subject, params float[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(-0.1F);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Theory]
			[InlineData(5, 6)]
			[InlineData(5, 4)]
			public async Task ForInt_WhenInsideTolerance_ShouldSucceed(
				int subject, params int[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Theory]
			[InlineData(5, 7)]
			[InlineData(5, 3)]
			public async Task ForInt_WhenOutsideTolerance_ShouldFail(
				int subject, params int[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage($"""
					              Expected subject to
					              be one of {Formatter.Format(expected)} ± 1,
					              but found 5.
					              """);
			}

			[Theory]
			[AutoData]
			public async Task
				ForInt_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException(
					int subject, params int[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(-1);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Theory]
			[InlineData(5L, 6L)]
			[InlineData(5L, 4L)]
			public async Task ForLong_WhenInsideTolerance_ShouldSucceed(
				long subject, params long[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Theory]
			[InlineData(5L, 7L)]
			[InlineData(5L, 3L)]
			public async Task ForLong_WhenOutsideTolerance_ShouldFail(
				long subject, params long[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage($"""
					              Expected subject to
					              be one of {Formatter.Format(expected)} ± 1,
					              but found 5.
					              """);
			}

			[Theory]
			[AutoData]
			public async Task
				ForLong_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException(
					long subject, params long[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(-1);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Theory]
			[InlineData((byte)5, (byte)6)]
			[InlineData((byte)5, (byte)4)]
			public async Task ForNullableByte_WhenInsideTolerance_ShouldSucceed(
				byte? subject, params byte?[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Theory]
			[InlineData((byte)5, (byte)7)]
			[InlineData((byte)5, (byte)3)]
			public async Task ForNullableByte_WhenOutsideTolerance_ShouldFail(
				byte? subject, params byte?[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage($"""
					              Expected subject to
					              be one of {Formatter.Format(expected)} ± 1,
					              but found 5.
					              """);
			}

			[Theory]
			[InlineData(12.5, 12.6)]
			[InlineData(12.5, 12.4)]
			public async Task ForNullableDecimal_WhenInsideTolerance_ShouldSucceed(
				double subjectValue, params double?[] expectedValues)
			{
				decimal? subject = new(subjectValue);
				decimal?[] expected = expectedValues
					.Select(expectedValue => expectedValue == null
						? (decimal?)null
						: new decimal(expectedValue.Value))
					.ToArray();

				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(new decimal(0.1));

				await That(Act).Should().NotThrow();
			}

			[Theory]
			[InlineData(12.5, 12.7)]
			[InlineData(12.5, 12.3)]
			public async Task ForNullableDecimal_WhenOutsideTolerance_ShouldFail(
				double subjectValue, params double?[] expectedValues)
			{
				decimal? subject = new(subjectValue);
				decimal?[] expected = expectedValues
					.Select(expectedValue => expectedValue == null
						? (decimal?)null
						: new decimal(expectedValue.Value))
					.ToArray();

				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(new decimal(0.1));

				await That(Act).Should().Throw<XunitException>()
					.WithMessage($"""
					              Expected subject to
					              be one of {Formatter.Format(expected)} ± 0.1,
					              but found 12.5.
					              """);
			}

			[Theory]
			[AutoData]
			public async Task
				ForNullableDecimal_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException(
					decimal? subject, params decimal?[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(new decimal(-0.1));

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Theory]
			[InlineData(12.5, 12.6)]
			[InlineData(12.5, 12.4)]
			public async Task ForNullableDouble_WhenInsideTolerance_ShouldSucceed(
				double? subject, params double?[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(0.11);

				await That(Act).Should().NotThrow();
			}

			[Theory]
			[InlineData(12.5, 12.7)]
			[InlineData(12.5, 12.3)]
			public async Task ForNullableDouble_WhenOutsideTolerance_ShouldFail(
				double? subject, params double?[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(0.1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage($"""
					              Expected subject to
					              be one of {Formatter.Format(expected)} ± 0.1,
					              but found 12.5.
					              """);
			}

			[Theory]
			[AutoData]
			public async Task
				ForNullableDouble_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException(
					double? subject, params double?[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(-0.1);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Theory]
			[InlineData(12.5F, 12.6F)]
			[InlineData(12.5F, 12.4F)]
			public async Task ForNullableFloat_WhenInsideTolerance_ShouldSucceed(
				float? subject, params float?[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(0.11F);

				await That(Act).Should().NotThrow();
			}

			[Theory]
			[InlineData(12.5F, 12.7F)]
			[InlineData(12.5F, 12.3F)]
			public async Task ForNullableFloat_WhenOutsideTolerance_ShouldFail(
				float? subject, params float?[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(0.1F);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage($"""
					              Expected subject to
					              be one of {Formatter.Format(expected)} ± 0.1,
					              but found 12.5.
					              """);
			}

			[Theory]
			[AutoData]
			public async Task
				ForNullableFloat_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException(
					float? subject, params float?[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(-0.1F);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Theory]
			[InlineData(5, 6)]
			[InlineData(5, 4)]
			public async Task ForNullableInt_WhenInsideTolerance_ShouldSucceed(
				int? subject, params int?[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Theory]
			[InlineData(5, 7)]
			[InlineData(5, 3)]
			public async Task ForNullableInt_WhenOutsideTolerance_ShouldFail(
				int? subject, params int?[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage($"""
					              Expected subject to
					              be one of {Formatter.Format(expected)} ± 1,
					              but found 5.
					              """);
			}

			[Theory]
			[AutoData]
			public async Task
				ForNullableInt_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException(
					int? subject, params int?[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(-1);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Theory]
			[InlineData((long)5, (long)6)]
			[InlineData((long)5, (long)4)]
			public async Task ForNullableLong_WhenInsideTolerance_ShouldSucceed(
				long? subject, params long?[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Theory]
			[InlineData((long)5, (long)7)]
			[InlineData((long)5, (long)3)]
			public async Task ForNullableLong_WhenOutsideTolerance_ShouldFail(
				long? subject, params long?[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage($"""
					              Expected subject to
					              be one of {Formatter.Format(expected)} ± 1,
					              but found 5.
					              """);
			}

			[Theory]
			[AutoData]
			public async Task
				ForNullableLong_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException(
					long? subject, params long?[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(-1);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Theory]
			[InlineData((sbyte)5, (sbyte)6)]
			[InlineData((sbyte)5, (sbyte)4)]
			public async Task ForNullableSbyte_WhenInsideTolerance_ShouldSucceed(
				sbyte? subject, params sbyte?[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Theory]
			[InlineData((sbyte)5, (sbyte)7)]
			[InlineData((sbyte)5, (sbyte)3)]
			public async Task ForNullableSbyte_WhenOutsideTolerance_ShouldFail(
				sbyte? subject, params sbyte?[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage($"""
					              Expected subject to
					              be one of {Formatter.Format(expected)} ± 1,
					              but found 5.
					              """);
			}

			[Theory]
			[AutoData]
			public async Task
				ForNullableSbyte_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException(
					sbyte? subject, params sbyte?[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(-1);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Theory]
			[InlineData((short)5, (short)6)]
			[InlineData((short)5, (short)4)]
			public async Task ForNullableShort_WhenInsideTolerance_ShouldSucceed(
				short? subject, params short?[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Theory]
			[InlineData((short)5, (short)7)]
			[InlineData((short)5, (short)3)]
			public async Task ForNullableShort_WhenOutsideTolerance_ShouldFail(
				short? subject, params short?[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage($"""
					              Expected subject to
					              be one of {Formatter.Format(expected)} ± 1,
					              but found 5.
					              """);
			}

			[Theory]
			[AutoData]
			public async Task
				ForNullableShort_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException(
					short? subject, params short?[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(-1);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Theory]
			[InlineData((uint)5, (uint)6)]
			[InlineData((uint)5, (uint)4)]
			public async Task ForNullableUint_WhenInsideTolerance_ShouldSucceed(
				uint? subject, params uint?[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Theory]
			[InlineData((uint)5, (uint)7)]
			[InlineData((uint)5, (uint)3)]
			public async Task ForNullableUint_WhenOutsideTolerance_ShouldFail(
				uint? subject, params uint?[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage($"""
					              Expected subject to
					              be one of {Formatter.Format(expected)} ± 1,
					              but found 5.
					              """);
			}

			[Theory]
			[InlineData((ulong)5, (ulong)6)]
			[InlineData((ulong)5, (ulong)4)]
			public async Task ForNullableUlong_WhenInsideTolerance_ShouldSucceed(
				ulong? subject, params ulong?[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Theory]
			[InlineData((ulong)5, (ulong)7)]
			[InlineData((ulong)5, (ulong)3)]
			public async Task ForNullableUlong_WhenOutsideTolerance_ShouldFail(
				ulong? subject, params ulong?[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage($"""
					              Expected subject to
					              be one of {Formatter.Format(expected)} ± 1,
					              but found 5.
					              """);
			}

			[Theory]
			[InlineData((ushort)5, (ushort)6)]
			[InlineData((ushort)5, (ushort)4)]
			public async Task ForNullableUshort_WhenInsideTolerance_ShouldSucceed(
				ushort? subject, params ushort?[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Theory]
			[InlineData((ushort)5, (ushort)7)]
			[InlineData((ushort)5, (ushort)3)]
			public async Task ForNullableUshort_WhenOutsideTolerance_ShouldFail(
				ushort? subject, params ushort?[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage($"""
					              Expected subject to
					              be one of {Formatter.Format(expected)} ± 1,
					              but found 5.
					              """);
			}

			[Theory]
			[InlineData((sbyte)5, (sbyte)6)]
			[InlineData((sbyte)5, (sbyte)4)]
			public async Task ForSbyte_WhenInsideTolerance_ShouldSucceed(
				sbyte subject, params sbyte[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Theory]
			[InlineData((sbyte)5, (sbyte)7)]
			[InlineData((sbyte)5, (sbyte)3)]
			public async Task ForSbyte_WhenOutsideTolerance_ShouldFail(
				sbyte subject, params sbyte[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage($"""
					              Expected subject to
					              be one of {Formatter.Format(expected)} ± 1,
					              but found 5.
					              """);
			}

			[Theory]
			[AutoData]
			public async Task
				ForSbyte_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException(
					sbyte subject, params sbyte[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(-1);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Theory]
			[InlineData((short)5, (short)6)]
			[InlineData((short)5, (short)4)]
			public async Task ForShort_WhenInsideTolerance_ShouldSucceed(
				short subject, params short[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Theory]
			[InlineData((short)5, (short)7)]
			[InlineData((short)5, (short)3)]
			public async Task ForShort_WhenOutsideTolerance_ShouldFail(
				short subject, params short[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage($"""
					              Expected subject to
					              be one of {Formatter.Format(expected)} ± 1,
					              but found 5.
					              """);
			}

			[Theory]
			[AutoData]
			public async Task
				ForShort_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException(
					short subject, params short[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(-1);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Theory]
			[InlineData((uint)5, (uint)6)]
			[InlineData((uint)5, (uint)4)]
			public async Task ForUint_WhenInsideTolerance_ShouldSucceed(
				uint subject, params uint[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Theory]
			[InlineData((uint)5, (uint)7)]
			[InlineData((uint)5, (uint)3)]
			public async Task ForUint_WhenOutsideTolerance_ShouldFail(
				uint subject, params uint[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage($"""
					              Expected subject to
					              be one of {Formatter.Format(expected)} ± 1,
					              but found 5.
					              """);
			}

			[Theory]
			[InlineData((ulong)5, (ulong)6)]
			[InlineData((ulong)5, (ulong)4)]
			public async Task ForUlong_WhenInsideTolerance_ShouldSucceed(
				ulong subject, params ulong[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Theory]
			[InlineData((ulong)5, (ulong)7)]
			[InlineData((ulong)5, (ulong)3)]
			public async Task ForUlong_WhenOutsideTolerance_ShouldFail(
				ulong subject, params ulong[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage($"""
					              Expected subject to
					              be one of {Formatter.Format(expected)} ± 1,
					              but found 5.
					              """);
			}

			[Theory]
			[InlineData((ushort)5, (ushort)6)]
			[InlineData((ushort)5, (ushort)4)]
			public async Task ForUshort_WhenInsideTolerance_ShouldSucceed(
				ushort subject, params ushort[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Theory]
			[InlineData((ushort)5, (ushort)7)]
			[InlineData((ushort)5, (ushort)3)]
			public async Task ForUshort_WhenOutsideTolerance_ShouldFail(
				ushort subject, params ushort[] expected)
			{
				async Task Act()
					=> await That(subject).Should().BeOneOf(expected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage($"""
					              Expected subject to
					              be one of {Formatter.Format(expected)} ± 1,
					              but found 5.
					              """);
			}
		}
	}

	public sealed partial class NotBeOneOfTests
	{
		public sealed class WithinTests
		{
			[Theory]
			[InlineData((byte)5, (byte)6)]
			[InlineData((byte)5, (byte)4)]
			public async Task ForByte_WhenInsideTolerance_ShouldFail(
				byte subject, params byte[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage($"""
					              Expected subject to
					              not be one of {Formatter.Format(unexpected)} ± 1,
					              but found 5.
					              """);
			}

			[Theory]
			[InlineData((byte)5, (byte)7)]
			[InlineData((byte)5, (byte)3)]
			public async Task ForByte_WhenOutsideTolerance_ShouldSucceed(
				byte subject, params byte[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Theory]
			[InlineData(12.5, 12.6)]
			[InlineData(12.5, 12.4)]
			public async Task ForDecimal_WhenInsideTolerance_ShouldFail(
				double subjectValue, params double[] unexpectedValues)
			{
				decimal subject = new(subjectValue);
				decimal[] unexpected = unexpectedValues
					.Select(unexpectedValue => new decimal(unexpectedValue))
					.ToArray();

				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(new decimal(0.1));

				await That(Act).Should().Throw<XunitException>()
					.WithMessage($"""
					              Expected subject to
					              not be one of {Formatter.Format(unexpected)} ± 0.1,
					              but found 12.5.
					              """);
			}

			[Theory]
			[InlineData(12.5, 12.7)]
			[InlineData(12.5, 12.3)]
			public async Task ForDecimal_WhenOutsideTolerance_ShouldSucceed(
				double subjectValue, params double[] unexpectedValues)
			{
				decimal subject = new(subjectValue);
				decimal[] unexpected = unexpectedValues
					.Select(unexpectedValue => new decimal(unexpectedValue))
					.ToArray();

				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(new decimal(0.1));

				await That(Act).Should().NotThrow();
			}

			[Theory]
			[AutoData]
			public async Task
				ForDecimal_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException(
					decimal subject, params decimal[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected)
						.Within(new decimal(-0.1));

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Theory]
			[InlineData(12.5, 12.6)]
			[InlineData(12.5, 12.4)]
			public async Task ForDouble_WhenInsideTolerance_ShouldFail(
				double subject, params double[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(0.11);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage($"""
					              Expected subject to
					              not be one of {Formatter.Format(unexpected)} ± 0.11,
					              but found 12.5.
					              """);
			}

			[Theory]
			[InlineData(12.5, 12.7)]
			[InlineData(12.5, 12.3)]
			public async Task ForDouble_WhenOutsideTolerance_ShouldSucceed(
				double subject, params double[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(0.11);

				await That(Act).Should().NotThrow();
			}

			[Theory]
			[AutoData]
			public async Task
				ForDouble_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException(
					double subject, params double[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(-0.1);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Theory]
			[InlineData(12.5F, 12.6F)]
			[InlineData(12.5F, 12.4F)]
			public async Task ForFloat_WhenInsideTolerance_ShouldFail(
				float subject, params float[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(0.11F);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage($"""
					              Expected subject to
					              not be one of {Formatter.Format(unexpected)} ± 0.11,
					              but found 12.5.
					              """);
			}

			[Theory]
			[InlineData(12.5F, 12.7F)]
			[InlineData(12.5F, 12.3F)]
			public async Task ForFloat_WhenOutsideTolerance_ShouldSucceed(
				float subject, params float[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(0.11F);

				await That(Act).Should().NotThrow();
			}

			[Theory]
			[AutoData]
			public async Task
				ForFloat_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException(
					float subject, params float[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(-0.1F);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Theory]
			[InlineData(5, 6)]
			[InlineData(5, 4)]
			public async Task ForInt_WhenInsideTolerance_ShouldFail(
				int subject, params int[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage($"""
					              Expected subject to
					              not be one of {Formatter.Format(unexpected)} ± 1,
					              but found 5.
					              """);
			}

			[Theory]
			[InlineData(5, 7)]
			[InlineData(5, 3)]
			public async Task ForInt_WhenOutsideTolerance_ShouldSucceed(
				int subject, params int[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Theory]
			[AutoData]
			public async Task
				ForInt_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException(
					int subject, params int[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(-1);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Theory]
			[InlineData(5L, 6L)]
			[InlineData(5L, 4L)]
			public async Task ForLong_WhenInsideTolerance_ShouldFail(
				long subject, params long[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage($"""
					              Expected subject to
					              not be one of {Formatter.Format(unexpected)} ± 1,
					              but found 5.
					              """);
			}

			[Theory]
			[InlineData(5L, 7L)]
			[InlineData(5L, 3L)]
			public async Task ForLong_WhenOutsideTolerance_ShouldSucceed(
				long subject, params long[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Theory]
			[AutoData]
			public async Task
				ForLong_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException(
					long subject, params long[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(-1);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Theory]
			[InlineData((byte)5, (byte)6)]
			[InlineData((byte)5, (byte)4)]
			public async Task ForNullableByte_WhenInsideTolerance_ShouldFail(
				byte? subject, params byte?[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage($"""
					              Expected subject to
					              not be one of {Formatter.Format(unexpected)} ± 1,
					              but found 5.
					              """);
			}

			[Theory]
			[InlineData((byte)5, (byte)7)]
			[InlineData((byte)5, (byte)3)]
			public async Task ForNullableByte_WhenOutsideTolerance_ShouldSucceed(
				byte? subject, params byte?[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Theory]
			[InlineData(12.5, 12.6)]
			[InlineData(12.5, 12.4)]
			public async Task ForNullableDecimal_WhenInsideTolerance_ShouldFail(
				double subjectValue, params double?[] unexpectedValues)
			{
				decimal? subject = new(subjectValue);
				decimal?[] unexpected = unexpectedValues
					.Select(unexpectedValue => unexpectedValue == null
						? (decimal?)null
						: new decimal(unexpectedValue.Value))
					.ToArray();

				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(new decimal(0.1));

				await That(Act).Should().Throw<XunitException>()
					.WithMessage($"""
					              Expected subject to
					              not be one of {Formatter.Format(unexpected)} ± 0.1,
					              but found 12.5.
					              """);
			}

			[Theory]
			[InlineData(12.5, 12.7)]
			[InlineData(12.5, 12.3)]
			public async Task ForNullableDecimal_WhenOutsideTolerance_ShouldSucceed(
				double subjectValue, params double?[] unexpectedValues)
			{
				decimal? subject = new(subjectValue);
				decimal?[] unexpected = unexpectedValues
					.Select(unexpectedValue => unexpectedValue == null
						? (decimal?)null
						: new decimal(unexpectedValue.Value))
					.ToArray();

				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(new decimal(0.1));

				await That(Act).Should().NotThrow();
			}

			[Theory]
			[AutoData]
			public async Task
				ForNullableDecimal_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException(
					decimal? subject, params decimal?[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected)
						.Within(new decimal(-0.1));

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Theory]
			[InlineData(12.5, 12.6)]
			[InlineData(12.5, 12.4)]
			public async Task ForNullableDouble_WhenInsideTolerance_ShouldFail(
				double? subject, params double?[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(0.11);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage($"""
					              Expected subject to
					              not be one of {Formatter.Format(unexpected)} ± 0.11,
					              but found 12.5.
					              """);
			}

			[Theory]
			[InlineData(12.5, 12.7)]
			[InlineData(12.5, 12.3)]
			public async Task ForNullableDouble_WhenOutsideTolerance_ShouldSucceed(
				double? subject, params double?[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(0.11);

				await That(Act).Should().NotThrow();
			}

			[Theory]
			[AutoData]
			public async Task
				ForNullableDouble_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException(
					double? subject, params double?[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(-0.1);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Theory]
			[InlineData(12.5F, 12.6F)]
			[InlineData(12.5F, 12.4F)]
			public async Task ForNullableFloat_WhenInsideTolerance_ShouldFail(
				float? subject, params float?[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(0.11F);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage($"""
					              Expected subject to
					              not be one of {Formatter.Format(unexpected)} ± 0.11,
					              but found 12.5.
					              """);
			}

			[Theory]
			[InlineData(12.5F, 12.7F)]
			[InlineData(12.5F, 12.3F)]
			public async Task ForNullableFloat_WhenOutsideTolerance_ShouldSucceed(
				float? subject, params float?[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(0.11F);

				await That(Act).Should().NotThrow();
			}

			[Theory]
			[AutoData]
			public async Task
				ForNullableFloat_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException(
					float? subject, params float?[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(-0.1F);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Theory]
			[InlineData(5, 6)]
			[InlineData(5, 4)]
			public async Task ForNullableInt_WhenInsideTolerance_ShouldFail(
				int? subject, params int?[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage($"""
					              Expected subject to
					              not be one of {Formatter.Format(unexpected)} ± 1,
					              but found 5.
					              """);
			}

			[Theory]
			[InlineData(5, 7)]
			[InlineData(5, 3)]
			public async Task ForNullableInt_WhenOutsideTolerance_ShouldSucceed(
				int? subject, params int?[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Theory]
			[AutoData]
			public async Task
				ForNullableInt_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException(
					int? subject, params int?[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(-1);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Theory]
			[InlineData((long)5, (long)6)]
			[InlineData((long)5, (long)4)]
			public async Task ForNullableLong_WhenInsideTolerance_ShouldFail(
				long? subject, params long?[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage($"""
					              Expected subject to
					              not be one of {Formatter.Format(unexpected)} ± 1,
					              but found 5.
					              """);
			}

			[Theory]
			[InlineData((long)5, (long)7)]
			[InlineData((long)5, (long)3)]
			public async Task ForNullableLong_WhenOutsideTolerance_ShouldSucceed(
				long? subject, params long?[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Theory]
			[AutoData]
			public async Task
				ForNullableLong_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException(
					long? subject, params long?[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(-1);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Theory]
			[InlineData((sbyte)5, (sbyte)6)]
			[InlineData((sbyte)5, (sbyte)4)]
			public async Task ForNullableSbyte_WhenInsideTolerance_ShouldFail(
				sbyte? subject, params sbyte?[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage($"""
					              Expected subject to
					              not be one of {Formatter.Format(unexpected)} ± 1,
					              but found 5.
					              """);
			}

			[Theory]
			[InlineData((sbyte)5, (sbyte)7)]
			[InlineData((sbyte)5, (sbyte)3)]
			public async Task ForNullableSbyte_WhenOutsideTolerance_ShouldSucceed(
				sbyte? subject, params sbyte?[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Theory]
			[AutoData]
			public async Task
				ForNullableSbyte_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException(
					sbyte? subject, params sbyte?[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(-1);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Theory]
			[InlineData((short)5, (short)6)]
			[InlineData((short)5, (short)4)]
			public async Task ForNullableShort_WhenInsideTolerance_ShouldFail(
				short? subject, params short?[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage($"""
					              Expected subject to
					              not be one of {Formatter.Format(unexpected)} ± 1,
					              but found 5.
					              """);
			}

			[Theory]
			[InlineData((short)5, (short)7)]
			[InlineData((short)5, (short)3)]
			public async Task ForNullableShort_WhenOutsideTolerance_ShouldSucceed(
				short? subject, params short?[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Theory]
			[AutoData]
			public async Task
				ForNullableShort_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException(
					short? subject, params short?[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(-1);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Theory]
			[InlineData((uint)5, (uint)6)]
			[InlineData((uint)5, (uint)4)]
			public async Task ForNullableUint_WhenInsideTolerance_ShouldFail(
				uint? subject, params uint?[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage($"""
					              Expected subject to
					              not be one of {Formatter.Format(unexpected)} ± 1,
					              but found 5.
					              """);
			}

			[Theory]
			[InlineData((uint)5, (uint)7)]
			[InlineData((uint)5, (uint)3)]
			public async Task ForNullableUint_WhenOutsideTolerance_ShouldSucceed(
				uint? subject, params uint?[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Theory]
			[InlineData((ulong)5, (ulong)6)]
			[InlineData((ulong)5, (ulong)4)]
			public async Task ForNullableUlong_WhenInsideTolerance_ShouldFail(
				ulong? subject, params ulong?[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage($"""
					              Expected subject to
					              not be one of {Formatter.Format(unexpected)} ± 1,
					              but found 5.
					              """);
			}

			[Theory]
			[InlineData((ulong)5, (ulong)7)]
			[InlineData((ulong)5, (ulong)3)]
			public async Task ForNullableUlong_WhenOutsideTolerance_ShouldSucceed(
				ulong? subject, params ulong?[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Theory]
			[InlineData((ushort)5, (ushort)6)]
			[InlineData((ushort)5, (ushort)4)]
			public async Task ForNullableUshort_WhenInsideTolerance_ShouldFail(
				ushort? subject, params ushort?[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage($"""
					              Expected subject to
					              not be one of {Formatter.Format(unexpected)} ± 1,
					              but found 5.
					              """);
			}

			[Theory]
			[InlineData((ushort)5, (ushort)7)]
			[InlineData((ushort)5, (ushort)3)]
			public async Task ForNullableUshort_WhenOutsideTolerance_ShouldSucceed(
				ushort? subject, params ushort?[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Theory]
			[InlineData((sbyte)5, (sbyte)6)]
			[InlineData((sbyte)5, (sbyte)4)]
			public async Task ForSbyte_WhenInsideTolerance_ShouldFail(
				sbyte subject, params sbyte[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage($"""
					              Expected subject to
					              not be one of {Formatter.Format(unexpected)} ± 1,
					              but found 5.
					              """);
			}

			[Theory]
			[InlineData((sbyte)5, (sbyte)7)]
			[InlineData((sbyte)5, (sbyte)3)]
			public async Task ForSbyte_WhenOutsideTolerance_ShouldSucceed(
				sbyte subject, params sbyte[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Theory]
			[AutoData]
			public async Task
				ForSbyte_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException(
					sbyte subject, params sbyte[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(-1);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Theory]
			[InlineData((short)5, (short)6)]
			[InlineData((short)5, (short)4)]
			public async Task ForShort_WhenInsideTolerance_ShouldFail(
				short subject, params short[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage($"""
					              Expected subject to
					              not be one of {Formatter.Format(unexpected)} ± 1,
					              but found 5.
					              """);
			}

			[Theory]
			[InlineData((short)5, (short)7)]
			[InlineData((short)5, (short)3)]
			public async Task ForShort_WhenOutsideTolerance_ShouldSucceed(
				short subject, params short[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Theory]
			[AutoData]
			public async Task
				ForShort_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException(
					short subject, params short[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(-1);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Theory]
			[InlineData((uint)5, (uint)6)]
			[InlineData((uint)5, (uint)4)]
			public async Task ForUint_WhenInsideTolerance_ShouldFail(
				uint subject, params uint[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage($"""
					              Expected subject to
					              not be one of {Formatter.Format(unexpected)} ± 1,
					              but found 5.
					              """);
			}

			[Theory]
			[InlineData((uint)5, (uint)7)]
			[InlineData((uint)5, (uint)3)]
			public async Task ForUint_WhenOutsideTolerance_ShouldSucceed(
				uint subject, params uint[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Theory]
			[InlineData((ulong)5, (ulong)6)]
			[InlineData((ulong)5, (ulong)4)]
			public async Task ForUlong_WhenInsideTolerance_ShouldFail(
				ulong subject, params ulong[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage($"""
					              Expected subject to
					              not be one of {Formatter.Format(unexpected)} ± 1,
					              but found 5.
					              """);
			}

			[Theory]
			[InlineData((ulong)5, (ulong)7)]
			[InlineData((ulong)5, (ulong)3)]
			public async Task ForUlong_WhenOutsideTolerance_ShouldSucceed(
				ulong subject, params ulong[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Theory]
			[InlineData((ushort)5, (ushort)6)]
			[InlineData((ushort)5, (ushort)4)]
			public async Task ForUshort_WhenInsideTolerance_ShouldFail(
				ushort subject, params ushort[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage($"""
					              Expected subject to
					              not be one of {Formatter.Format(unexpected)} ± 1,
					              but found 5.
					              """);
			}

			[Theory]
			[InlineData((ushort)5, (ushort)7)]
			[InlineData((ushort)5, (ushort)3)]
			public async Task ForUshort_WhenOutsideTolerance_ShouldSucceed(
				ushort subject, params ushort[] unexpected)
			{
				async Task Act()
					=> await That(subject).Should().NotBeOneOf(unexpected).Within(1);

				await That(Act).Should().NotThrow();
			}
		}
	}
}
