namespace Testably.Expectations.Tests.ThatTests.Numbers;

public sealed partial class NumberShould
{
	public sealed class Be
	{
		public sealed class WithinTests
		{
			[Fact]
			public async Task ForByte_WhenInsideTolerance_ShouldSucceed()
			{
				byte subject = 12;
				byte expected = 11;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Fact]
			public async Task ForByte_WhenOutsideTolerance_ShouldFail()
			{
				byte subject = 12;
				byte expected = 10;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage("""
					             Expected subject to
					             be 10 ± 1,
					             but found 12
					             at Expect.That(subject).Should().Be(expected).Within(1)
					             """);
			}

			[Fact]
			public async Task ForDecimal_WhenInsideTolerance_ShouldSucceed()
			{
				decimal subject = new(12.2);
				decimal expected = new(12.1);

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(new decimal(0.1));

				await That(Act).Should().NotThrow();
			}

			[Fact]
			public async Task ForDecimal_WhenOutsideTolerance_ShouldFail()
			{
				decimal subject = new(12.3);
				decimal expected = new(12.1);

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(new decimal(0.1));

				await That(Act).Should().Throw<XunitException>()
					.WithMessage("""
					             Expected subject to
					             be 12.1 ± 0.1,
					             but found 12.3
					             at Expect.That(subject).Should().Be(expected).Within(new decimal(0.1))
					             """);
			}

			[Fact]
			public async Task
				ForDecimal_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException()
			{
				decimal subject = new(12.2);
				decimal expected = new(12.1);

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(new decimal(-0.1));

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Fact]
			public async Task ForDouble_WhenInsideTolerance_ShouldSucceed()
			{
				double subject = 12.2;
				double expected = 12.1;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(0.1);

				await That(Act).Should().NotThrow();
			}

			[Fact]
			public async Task ForDouble_WhenOutsideTolerance_ShouldFail()
			{
				double subject = 12.3;
				double expected = 12.1;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(0.1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage("""
					             Expected subject to
					             be 12.1 ± 0.1,
					             but found 12.3
					             at Expect.That(subject).Should().Be(expected).Within(0.1)
					             """);
			}

			[Fact]
			public async Task
				ForDouble_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException()
			{
				double subject = 12.2;
				double expected = 12.1;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(-0.1);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Fact]
			public async Task ForFloat_WhenInsideTolerance_ShouldSucceed()
			{
				float subject = 12.2F;
				float expected = 12.1F;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(0.1F);

				await That(Act).Should().NotThrow();
			}

			[Fact]
			public async Task ForFloat_WhenOutsideTolerance_ShouldFail()
			{
				float subject = 12.3F;
				float expected = 12.1F;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(0.1F);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage("""
					             Expected subject to
					             be 12.1 ± 0.1,
					             but found 12.3
					             at Expect.That(subject).Should().Be(expected).Within(0.1F)
					             """);
			}

			[Fact]
			public async Task
				ForFloat_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException()
			{
				float subject = 12.2F;
				float expected = 12.1F;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(-0.1F);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Fact]
			public async Task ForInt_WhenInsideTolerance_ShouldSucceed()
			{
				int subject = 12;
				int expected = 11;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Fact]
			public async Task ForInt_WhenOutsideTolerance_ShouldFail()
			{
				int subject = 12;
				int expected = 10;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage("""
					             Expected subject to
					             be 10 ± 1,
					             but found 12
					             at Expect.That(subject).Should().Be(expected).Within(1)
					             """);
			}

			[Fact]
			public async Task
				ForInt_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException()
			{
				int subject = 12;
				int expected = 11;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(-1);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Fact]
			public async Task ForLong_WhenInsideTolerance_ShouldSucceed()
			{
				long subject = 12;
				long expected = 11;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Fact]
			public async Task ForLong_WhenOutsideTolerance_ShouldFail()
			{
				long subject = 12;
				long expected = 10;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage("""
					             Expected subject to
					             be 10 ± 1,
					             but found 12
					             at Expect.That(subject).Should().Be(expected).Within(1)
					             """);
			}

			[Fact]
			public async Task
				ForLong_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException()
			{
				long subject = 12;
				long expected = 11;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(-1);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Fact]
			public async Task ForNullableByte_WhenInsideTolerance_ShouldSucceed()
			{
				byte? subject = 12;
				byte? expected = 11;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Fact]
			public async Task ForNullableByte_WhenOutsideTolerance_ShouldFail()
			{
				byte? subject = 12;
				byte? expected = 10;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage("""
					             Expected subject to
					             be 10 ± 1,
					             but found 12
					             at Expect.That(subject).Should().Be(expected).Within(1)
					             """);
			}

			[Fact]
			public async Task ForNullableDecimal_WhenInsideTolerance_ShouldSucceed()
			{
				decimal? subject = new(12.2);
				decimal? expected = new(12.1);

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(new decimal(0.1));

				await That(Act).Should().NotThrow();
			}

			[Fact]
			public async Task ForNullableDecimal_WhenOutsideTolerance_ShouldFail()
			{
				decimal? subject = new(12.3);
				decimal? expected = new(12.1);

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(new decimal(0.1));

				await That(Act).Should().Throw<XunitException>()
					.WithMessage("""
					             Expected subject to
					             be 12.1 ± 0.1,
					             but found 12.3
					             at Expect.That(subject).Should().Be(expected).Within(new decimal(0.1))
					             """);
			}

			[Fact]
			public async Task
				ForNullableDecimal_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException()
			{
				decimal? subject = new(12.2);
				decimal? expected = new(12.1);

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(new decimal(-0.1));

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Fact]
			public async Task ForNullableDouble_WhenInsideTolerance_ShouldSucceed()
			{
				double? subject = 12.2;
				double? expected = 12.1;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(0.1);

				await That(Act).Should().NotThrow();
			}

			[Fact]
			public async Task ForNullableDouble_WhenOutsideTolerance_ShouldFail()
			{
				double? subject = 12.3;
				double? expected = 12.1;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(0.1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage("""
					             Expected subject to
					             be 12.1 ± 0.1,
					             but found 12.3
					             at Expect.That(subject).Should().Be(expected).Within(0.1)
					             """);
			}

			[Fact]
			public async Task
				ForNullableDouble_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException()
			{
				double? subject = 12.2;
				double? expected = 12.1;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(-0.1);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Fact]
			public async Task ForNullableFloat_WhenInsideTolerance_ShouldSucceed()
			{
				float? subject = 12.2F;
				float? expected = 12.1F;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(0.1F);

				await That(Act).Should().NotThrow();
			}

			[Fact]
			public async Task ForNullableFloat_WhenOutsideTolerance_ShouldFail()
			{
				float? subject = 12.3F;
				float? expected = 12.1F;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(0.1F);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage("""
					             Expected subject to
					             be 12.1 ± 0.1,
					             but found 12.3
					             at Expect.That(subject).Should().Be(expected).Within(0.1F)
					             """);
			}

			[Fact]
			public async Task
				ForNullableFloat_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException()
			{
				float? subject = 12.2F;
				float? expected = 12.1F;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(-0.1F);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Fact]
			public async Task ForNullableInt_WhenInsideTolerance_ShouldSucceed()
			{
				int? subject = 12;
				int? expected = 11;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Fact]
			public async Task ForNullableInt_WhenOutsideTolerance_ShouldFail()
			{
				int? subject = 12;
				int? expected = 10;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage("""
					             Expected subject to
					             be 10 ± 1,
					             but found 12
					             at Expect.That(subject).Should().Be(expected).Within(1)
					             """);
			}

			[Fact]
			public async Task
				ForNullableInt_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException()
			{
				int? subject = 12;
				int? expected = 11;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(-1);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Fact]
			public async Task ForNullableLong_WhenInsideTolerance_ShouldSucceed()
			{
				long? subject = 12;
				long? expected = 11;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Fact]
			public async Task ForNullableLong_WhenOutsideTolerance_ShouldFail()
			{
				long? subject = 12;
				long? expected = 10;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage("""
					             Expected subject to
					             be 10 ± 1,
					             but found 12
					             at Expect.That(subject).Should().Be(expected).Within(1)
					             """);
			}

			[Fact]
			public async Task
				ForNullableLong_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException()
			{
				long? subject = 12;
				long? expected = 11;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(-1);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Fact]
			public async Task ForNullableSbyte_WhenInsideTolerance_ShouldSucceed()
			{
				sbyte? subject = 12;
				sbyte? expected = 11;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Fact]
			public async Task ForNullableSbyte_WhenOutsideTolerance_ShouldFail()
			{
				sbyte? subject = 12;
				sbyte? expected = 10;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage("""
					             Expected subject to
					             be 10 ± 1,
					             but found 12
					             at Expect.That(subject).Should().Be(expected).Within(1)
					             """);
			}

			[Fact]
			public async Task
				ForNullableSbyte_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException()
			{
				sbyte? subject = 12;
				sbyte? expected = 11;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(-1);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Fact]
			public async Task ForNullableShort_WhenInsideTolerance_ShouldSucceed()
			{
				short? subject = 12;
				short? expected = 11;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Fact]
			public async Task ForNullableShort_WhenOutsideTolerance_ShouldFail()
			{
				short? subject = 12;
				short? expected = 10;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage("""
					             Expected subject to
					             be 10 ± 1,
					             but found 12
					             at Expect.That(subject).Should().Be(expected).Within(1)
					             """);
			}

			[Fact]
			public async Task
				ForNullableShort_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException()
			{
				short? subject = 12;
				short? expected = 11;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(-1);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Fact]
			public async Task ForNullableUint_WhenInsideTolerance_ShouldSucceed()
			{
				uint? subject = 12;
				uint? expected = 11;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Fact]
			public async Task ForNullableUint_WhenOutsideTolerance_ShouldFail()
			{
				uint? subject = 12;
				uint? expected = 10;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage("""
					             Expected subject to
					             be 10 ± 1,
					             but found 12
					             at Expect.That(subject).Should().Be(expected).Within(1)
					             """);
			}

			[Fact]
			public async Task ForNullableUlong_WhenInsideTolerance_ShouldSucceed()
			{
				ulong? subject = 12;
				ulong? expected = 11;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Fact]
			public async Task ForNullableUlong_WhenOutsideTolerance_ShouldFail()
			{
				ulong? subject = 12;
				ulong? expected = 10;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage("""
					             Expected subject to
					             be 10 ± 1,
					             but found 12
					             at Expect.That(subject).Should().Be(expected).Within(1)
					             """);
			}

			[Fact]
			public async Task ForNullableUshort_WhenInsideTolerance_ShouldSucceed()
			{
				ushort? subject = 12;
				ushort? expected = 11;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Fact]
			public async Task ForNullableUshort_WhenOutsideTolerance_ShouldFail()
			{
				ushort? subject = 12;
				ushort? expected = 10;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage("""
					             Expected subject to
					             be 10 ± 1,
					             but found 12
					             at Expect.That(subject).Should().Be(expected).Within(1)
					             """);
			}

			[Fact]
			public async Task ForSbyte_WhenInsideTolerance_ShouldSucceed()
			{
				sbyte subject = 12;
				sbyte expected = 11;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Fact]
			public async Task ForSbyte_WhenOutsideTolerance_ShouldFail()
			{
				sbyte subject = 12;
				sbyte expected = 10;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage("""
					             Expected subject to
					             be 10 ± 1,
					             but found 12
					             at Expect.That(subject).Should().Be(expected).Within(1)
					             """);
			}

			[Fact]
			public async Task
				ForSbyte_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException()
			{
				sbyte subject = 12;
				sbyte expected = 11;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(-1);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Fact]
			public async Task ForShort_WhenInsideTolerance_ShouldSucceed()
			{
				short subject = 12;
				short expected = 11;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Fact]
			public async Task ForShort_WhenOutsideTolerance_ShouldFail()
			{
				short subject = 12;
				short expected = 10;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage("""
					             Expected subject to
					             be 10 ± 1,
					             but found 12
					             at Expect.That(subject).Should().Be(expected).Within(1)
					             """);
			}

			[Fact]
			public async Task
				ForShort_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException()
			{
				short subject = 12;
				short expected = 11;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(-1);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Fact]
			public async Task ForUint_WhenInsideTolerance_ShouldSucceed()
			{
				uint subject = 12;
				uint expected = 11;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Fact]
			public async Task ForUint_WhenOutsideTolerance_ShouldFail()
			{
				uint subject = 12;
				uint expected = 10;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage("""
					             Expected subject to
					             be 10 ± 1,
					             but found 12
					             at Expect.That(subject).Should().Be(expected).Within(1)
					             """);
			}

			[Fact]
			public async Task ForUlong_WhenInsideTolerance_ShouldSucceed()
			{
				ulong subject = 12;
				ulong expected = 11;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Fact]
			public async Task ForUlong_WhenOutsideTolerance_ShouldFail()
			{
				ulong subject = 12;
				ulong expected = 10;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage("""
					             Expected subject to
					             be 10 ± 1,
					             but found 12
					             at Expect.That(subject).Should().Be(expected).Within(1)
					             """);
			}

			[Fact]
			public async Task ForUshort_WhenInsideTolerance_ShouldSucceed()
			{
				ushort subject = 12;
				ushort expected = 11;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Fact]
			public async Task ForUshort_WhenOutsideTolerance_ShouldFail()
			{
				ushort subject = 12;
				ushort expected = 10;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage("""
					             Expected subject to
					             be 10 ± 1,
					             but found 12
					             at Expect.That(subject).Should().Be(expected).Within(1)
					             """);
			}
		}
	}

	public sealed class NotBe
	{
		public sealed class WithinTests
		{
			[Fact]
			public async Task ForByte_WhenInsideTolerance_ShouldFail()
			{
				byte subject = 12;
				byte unexpected = 11;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage("""
					             Expected subject to
					             not be 11 ± 1,
					             but found 12
					             at Expect.That(subject).Should().NotBe(unexpected).Within(1)
					             """);
			}

			[Fact]
			public async Task ForByte_WhenOutsideTolerance_ShouldSucceed()
			{
				byte subject = 12;
				byte unexpected = 10;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Fact]
			public async Task ForDecimal_WhenInsideTolerance_ShouldFail()
			{
				decimal subject = new(12.2);
				decimal unexpected = new(12.1);

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(new decimal(0.1));

				await That(Act).Should().Throw<XunitException>()
					.WithMessage("""
					             Expected subject to
					             not be 12.1 ± 0.1,
					             but found 12.2
					             at Expect.That(subject).Should().NotBe(unexpected).Within(new decimal(0.1))
					             """);
			}

			[Fact]
			public async Task ForDecimal_WhenOutsideTolerance_ShouldSucceed()
			{
				decimal subject = new(12.3);
				decimal unexpected = new(12.1);

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(new decimal(0.1));

				await That(Act).Should().NotThrow();
			}

			[Fact]
			public async Task
				ForDecimal_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException()
			{
				decimal subject = new(12.2);
				decimal unexpected = new(12.1);

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(new decimal(-0.1));

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Fact]
			public async Task ForDouble_WhenInsideTolerance_ShouldFail()
			{
				double subject = 12.2;
				double unexpected = 12.1;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(0.1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage("""
					             Expected subject to
					             not be 12.1 ± 0.1,
					             but found 12.2
					             at Expect.That(subject).Should().NotBe(unexpected).Within(0.1)
					             """);
			}

			[Fact]
			public async Task ForDouble_WhenOutsideTolerance_ShouldSucceed()
			{
				double subject = 12.3;
				double unexpected = 12.1;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(0.1);

				await That(Act).Should().NotThrow();
			}

			[Fact]
			public async Task
				ForDouble_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException()
			{
				double subject = 12.2;
				double unexpected = 12.1;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(-0.1);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Fact]
			public async Task ForFloat_WhenInsideTolerance_ShouldFail()
			{
				float subject = 12.2F;
				float unexpected = 12.1F;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(0.1F);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage("""
					             Expected subject to
					             not be 12.1 ± 0.1,
					             but found 12.2
					             at Expect.That(subject).Should().NotBe(unexpected).Within(0.1F)
					             """);
			}

			[Fact]
			public async Task ForFloat_WhenOutsideTolerance_ShouldSucceed()
			{
				float subject = 12.3F;
				float unexpected = 12.1F;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(0.1F);

				await That(Act).Should().NotThrow();
			}

			[Fact]
			public async Task
				ForFloat_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException()
			{
				float subject = 12.2F;
				float unexpected = 12.1F;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(-0.1F);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Fact]
			public async Task ForInt_WhenInsideTolerance_ShouldFail()
			{
				int subject = 12;
				int unexpected = 11;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage("""
					             Expected subject to
					             not be 11 ± 1,
					             but found 12
					             at Expect.That(subject).Should().NotBe(unexpected).Within(1)
					             """);
			}

			[Fact]
			public async Task ForInt_WhenOutsideTolerance_ShouldSucceed()
			{
				int subject = 12;
				int unexpected = 10;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Fact]
			public async Task
				ForInt_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException()
			{
				int subject = 12;
				int unexpected = 11;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(-1);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Fact]
			public async Task ForLong_WhenInsideTolerance_ShouldFail()
			{
				long subject = 12;
				long unexpected = 11;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage("""
					             Expected subject to
					             not be 11 ± 1,
					             but found 12
					             at Expect.That(subject).Should().NotBe(unexpected).Within(1)
					             """);
			}

			[Fact]
			public async Task ForLong_WhenOutsideTolerance_ShouldSucceed()
			{
				long subject = 12;
				long unexpected = 10;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Fact]
			public async Task
				ForLong_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException()
			{
				long subject = 12;
				long unexpected = 11;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(-1);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Fact]
			public async Task ForNullableByte_WhenInsideTolerance_ShouldFail()
			{
				byte? subject = 12;
				byte? unexpected = 11;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage("""
					             Expected subject to
					             not be 11 ± 1,
					             but found 12
					             at Expect.That(subject).Should().NotBe(unexpected).Within(1)
					             """);
			}

			[Fact]
			public async Task ForNullableByte_WhenOutsideTolerance_ShouldSucceed()
			{
				byte? subject = 12;
				byte? unexpected = 10;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Fact]
			public async Task ForNullableDecimal_WhenInsideTolerance_ShouldFail()
			{
				decimal? subject = new(12.2);
				decimal? unexpected = new(12.1);

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(new decimal(0.1));

				await That(Act).Should().Throw<XunitException>()
					.WithMessage("""
					             Expected subject to
					             not be 12.1 ± 0.1,
					             but found 12.2
					             at Expect.That(subject).Should().NotBe(unexpected).Within(new decimal(0.1))
					             """);
			}

			[Fact]
			public async Task ForNullableDecimal_WhenOutsideTolerance_ShouldSucceed()
			{
				decimal? subject = new(12.3);
				decimal? unexpected = new(12.1);

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(new decimal(0.1));

				await That(Act).Should().NotThrow();
			}

			[Fact]
			public async Task
				ForNullableDecimal_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException()
			{
				decimal? subject = new(12.2);
				decimal? unexpected = new(12.1);

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(new decimal(-0.1));

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Fact]
			public async Task ForNullableDouble_WhenInsideTolerance_ShouldFail()
			{
				double? subject = 12.2;
				double? unexpected = 12.1;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(0.1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage("""
					             Expected subject to
					             not be 12.1 ± 0.1,
					             but found 12.2
					             at Expect.That(subject).Should().NotBe(unexpected).Within(0.1)
					             """);
			}

			[Fact]
			public async Task ForNullableDouble_WhenOutsideTolerance_ShouldSucceed()
			{
				double? subject = 12.3;
				double? unexpected = 12.1;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(0.1);

				await That(Act).Should().NotThrow();
			}

			[Fact]
			public async Task
				ForNullableDouble_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException()
			{
				double? subject = 12.2;
				double? unexpected = 12.1;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(-0.1);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Fact]
			public async Task ForNullableFloat_WhenInsideTolerance_ShouldFail()
			{
				float? subject = 12.2F;
				float? unexpected = 12.1F;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(0.1F);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage("""
					             Expected subject to
					             not be 12.1 ± 0.1,
					             but found 12.2
					             at Expect.That(subject).Should().NotBe(unexpected).Within(0.1F)
					             """);
			}

			[Fact]
			public async Task ForNullableFloat_WhenOutsideTolerance_ShouldSucceed()
			{
				float? subject = 12.3F;
				float? unexpected = 12.1F;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(0.1F);

				await That(Act).Should().NotThrow();
			}

			[Fact]
			public async Task
				ForNullableFloat_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException()
			{
				float? subject = 12.2F;
				float? unexpected = 12.1F;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(-0.1F);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Fact]
			public async Task ForNullableInt_WhenInsideTolerance_ShouldFail()
			{
				int? subject = 12;
				int? unexpected = 11;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage("""
					             Expected subject to
					             not be 11 ± 1,
					             but found 12
					             at Expect.That(subject).Should().NotBe(unexpected).Within(1)
					             """);
			}

			[Fact]
			public async Task ForNullableInt_WhenOutsideTolerance_ShouldSucceed()
			{
				int? subject = 12;
				int? unexpected = 10;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Fact]
			public async Task
				ForNullableInt_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException()
			{
				int? subject = 12;
				int? unexpected = 11;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(-1);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Fact]
			public async Task ForNullableLong_WhenInsideTolerance_ShouldFail()
			{
				long? subject = 12;
				long? unexpected = 11;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage("""
					             Expected subject to
					             not be 11 ± 1,
					             but found 12
					             at Expect.That(subject).Should().NotBe(unexpected).Within(1)
					             """);
			}

			[Fact]
			public async Task ForNullableLong_WhenOutsideTolerance_ShouldSucceed()
			{
				long? subject = 12;
				long? unexpected = 10;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Fact]
			public async Task
				ForNullableLong_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException()
			{
				long? subject = 12;
				long? unexpected = 11;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(-1);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Fact]
			public async Task ForNullableSbyte_WhenInsideTolerance_ShouldFail()
			{
				sbyte? subject = 12;
				sbyte? unexpected = 11;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage("""
					             Expected subject to
					             not be 11 ± 1,
					             but found 12
					             at Expect.That(subject).Should().NotBe(unexpected).Within(1)
					             """);
			}

			[Fact]
			public async Task ForNullableSbyte_WhenOutsideTolerance_ShouldSucceed()
			{
				sbyte? subject = 12;
				sbyte? unexpected = 10;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Fact]
			public async Task
				ForNullableSbyte_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException()
			{
				sbyte? subject = 12;
				sbyte? unexpected = 11;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(-1);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Fact]
			public async Task ForNullableShort_WhenInsideTolerance_ShouldFail()
			{
				short? subject = 12;
				short? unexpected = 11;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage("""
					             Expected subject to
					             not be 11 ± 1,
					             but found 12
					             at Expect.That(subject).Should().NotBe(unexpected).Within(1)
					             """);
			}

			[Fact]
			public async Task ForNullableShort_WhenOutsideTolerance_ShouldSucceed()
			{
				short? subject = 12;
				short? unexpected = 10;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Fact]
			public async Task
				ForNullableShort_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException()
			{
				short? subject = 12;
				short? unexpected = 11;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(-1);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Fact]
			public async Task ForNullableUint_WhenInsideTolerance_ShouldFail()
			{
				uint? subject = 12;
				uint? unexpected = 11;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage("""
					             Expected subject to
					             not be 11 ± 1,
					             but found 12
					             at Expect.That(subject).Should().NotBe(unexpected).Within(1)
					             """);
			}

			[Fact]
			public async Task ForNullableUint_WhenOutsideTolerance_ShouldSucceed()
			{
				uint? subject = 12;
				uint? unexpected = 10;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Fact]
			public async Task ForNullableUlong_WhenInsideTolerance_ShouldFail()
			{
				ulong? subject = 12;
				ulong? unexpected = 11;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage("""
					             Expected subject to
					             not be 11 ± 1,
					             but found 12
					             at Expect.That(subject).Should().NotBe(unexpected).Within(1)
					             """);
			}

			[Fact]
			public async Task ForNullableUlong_WhenOutsideTolerance_ShouldSucceed()
			{
				ulong? subject = 12;
				ulong? unexpected = 10;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Fact]
			public async Task ForNullableUshort_WhenInsideTolerance_ShouldFail()
			{
				ushort? subject = 12;
				ushort? unexpected = 11;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage("""
					             Expected subject to
					             not be 11 ± 1,
					             but found 12
					             at Expect.That(subject).Should().NotBe(unexpected).Within(1)
					             """);
			}

			[Fact]
			public async Task ForNullableUshort_WhenOutsideTolerance_ShouldSucceed()
			{
				ushort? subject = 12;
				ushort? unexpected = 10;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Fact]
			public async Task ForSbyte_WhenInsideTolerance_ShouldFail()
			{
				sbyte subject = 12;
				sbyte unexpected = 11;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage("""
					             Expected subject to
					             not be 11 ± 1,
					             but found 12
					             at Expect.That(subject).Should().NotBe(unexpected).Within(1)
					             """);
			}

			[Fact]
			public async Task ForSbyte_WhenOutsideTolerance_ShouldSucceed()
			{
				sbyte subject = 12;
				sbyte unexpected = 10;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Fact]
			public async Task
				ForSbyte_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException()
			{
				sbyte subject = 12;
				sbyte unexpected = 11;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(-1);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Fact]
			public async Task ForShort_WhenInsideTolerance_ShouldFail()
			{
				short subject = 12;
				short unexpected = 11;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage("""
					             Expected subject to
					             not be 11 ± 1,
					             but found 12
					             at Expect.That(subject).Should().NotBe(unexpected).Within(1)
					             """);
			}

			[Fact]
			public async Task ForShort_WhenOutsideTolerance_ShouldSucceed()
			{
				short subject = 12;
				short unexpected = 10;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Fact]
			public async Task
				ForShort_WhenToleranceIsNegative_ShouldThrowArgumentOutOfRangeException()
			{
				short subject = 12;
				short unexpected = 11;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(-1);

				await That(Act).Should().Throw<ArgumentOutOfRangeException>()
					.WithParamName("tolerance").And
					.WithMessage("*Tolerance must be non-negative*").AsWildcard();
			}

			[Fact]
			public async Task ForUint_WhenInsideTolerance_ShouldFail()
			{
				uint subject = 12;
				uint unexpected = 11;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage("""
					             Expected subject to
					             not be 11 ± 1,
					             but found 12
					             at Expect.That(subject).Should().NotBe(unexpected).Within(1)
					             """);
			}

			[Fact]
			public async Task ForUint_WhenOutsideTolerance_ShouldSucceed()
			{
				uint subject = 12;
				uint unexpected = 10;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Fact]
			public async Task ForUlong_WhenInsideTolerance_ShouldFail()
			{
				ulong subject = 12;
				ulong unexpected = 11;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage("""
					             Expected subject to
					             not be 11 ± 1,
					             but found 12
					             at Expect.That(subject).Should().NotBe(unexpected).Within(1)
					             """);
			}

			[Fact]
			public async Task ForUlong_WhenOutsideTolerance_ShouldSucceed()
			{
				ulong subject = 12;
				ulong unexpected = 10;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Fact]
			public async Task ForUshort_WhenInsideTolerance_ShouldFail()
			{
				ushort subject = 12;
				ushort unexpected = 11;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage("""
					             Expected subject to
					             not be 11 ± 1,
					             but found 12
					             at Expect.That(subject).Should().NotBe(unexpected).Within(1)
					             """);
			}

			[Fact]
			public async Task ForUshort_WhenOutsideTolerance_ShouldSucceed()
			{
				ushort subject = 12;
				ushort unexpected = 10;

				async Task Act()
					=> await That(subject).Should().NotBe(unexpected).Within(1);

				await That(Act).Should().NotThrow();
			}
		}
	}
}
