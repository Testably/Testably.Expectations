﻿using System.Globalization;

namespace Testably.Expectations.Tests.That.Numbers;

public sealed partial class NumberShould
{
	public sealed class BeInfiniteTests
	{
		[Fact]
		public async Task ForDouble_ShouldSupportChaining()
		{
			double subject = double.PositiveInfinity;

			async Task Act()
				=> await Expect.That(subject).Should().BeInfinite()
					.And.Be(subject);

			await Expect.That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(double.PositiveInfinity)]
		[InlineData(double.NegativeInfinity)]
		public async Task ForDouble_WhenSubjectIsInfinity_ShouldSucceed(double subject)
		{
			async Task Act() => await Expect.That(subject).Should().BeInfinite();

			await Expect.That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(-1d)]
		[InlineData(0d)]
		[InlineData(1d)]
		[InlineData(double.MinValue)]
		[InlineData(double.MaxValue)]
		[InlineData(double.Epsilon)]
		[InlineData(double.NaN)]
		public async Task ForDouble_WhenSubjectIsNormalValue_ShouldFail(double subject)
		{
			async Task Act()
				=> await Expect.That(subject).Should().BeInfinite();

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be infinite,
				              but found {subject.ToString(CultureInfo.InvariantCulture)}
				              at Expect.That(subject).Should().BeInfinite()
				              """);
		}

		[Fact]
		public async Task ForFloat_ShouldSupportChaining()
		{
			float subject = float.PositiveInfinity;

			async Task Act() => await Expect.That(subject).Should().BeInfinite()
				.And.Be(subject);

			await Expect.That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(float.PositiveInfinity)]
		[InlineData(float.NegativeInfinity)]
		public async Task ForFloat_WhenSubjectIsInfinity_ShouldSucceed(float subject)
		{
			async Task Act()
				=> await Expect.That(subject).Should().BeInfinite();

			await Expect.That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(-1f)]
		[InlineData(0f)]
		[InlineData(1f)]
		[InlineData(float.MinValue)]
		[InlineData(float.MaxValue)]
		[InlineData(float.Epsilon)]
		[InlineData(float.NaN)]
		public async Task ForFloat_WhenSubjectIsNormalValue_ShouldFail(float subject)
		{
			async Task Act()
				=> await Expect.That(subject).Should().BeInfinite();

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be infinite,
				              but found {subject.ToString(CultureInfo.InvariantCulture)}
				              at Expect.That(subject).Should().BeInfinite()
				              """);
		}
	}

	public sealed class NotBeInfiniteTests
	{
		[Fact]
		public async Task ForDouble_ShouldSupportChaining()
		{
			double subject = double.Epsilon;

			async Task Act()
				=> await Expect.That(subject).Should().NotBeInfinite()
					.And.Be(subject);

			await Expect.That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(double.PositiveInfinity)]
		[InlineData(double.NegativeInfinity)]
		public async Task ForDouble_WhenSubjectIsInfinity_ShouldFail(double subject)
		{
			async Task Act() => await Expect.That(subject).Should().NotBeInfinite();

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              not be infinite,
				              but found {subject.ToString(CultureInfo.InvariantCulture)}
				              at Expect.That(subject).Should().NotBeInfinite()
				              """);
		}

		[Theory]
		[InlineData(-1d)]
		[InlineData(0d)]
		[InlineData(1d)]
		[InlineData(double.MinValue)]
		[InlineData(double.MaxValue)]
		[InlineData(double.Epsilon)]
		[InlineData(double.NaN)]
		public async Task ForDouble_WhenSubjectIsNormalValue_ShouldSucceed(double subject)
		{
			async Task Act()
				=> await Expect.That(subject).Should().NotBeInfinite();

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task ForFloat_ShouldSupportChaining()
		{
			float subject = float.Epsilon;

			async Task Act() => await Expect.That(subject).Should().NotBeInfinite()
				.And.Be(subject);

			await Expect.That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(float.PositiveInfinity)]
		[InlineData(float.NegativeInfinity)]
		public async Task ForFloat_WhenSubjectIsInfinity_ShouldFail(float subject)
		{
			async Task Act()
				=> await Expect.That(subject).Should().NotBeInfinite();

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              not be infinite,
				              but found {subject.ToString(CultureInfo.InvariantCulture)}
				              at Expect.That(subject).Should().NotBeInfinite()
				              """);
		}

		[Theory]
		[InlineData(-1f)]
		[InlineData(0f)]
		[InlineData(1f)]
		[InlineData(float.MinValue)]
		[InlineData(float.MaxValue)]
		[InlineData(float.Epsilon)]
		[InlineData(float.NaN)]
		public async Task ForFloat_WhenSubjectIsNormalValue_ShouldSucceed(float subject)
		{
			async Task Act()
				=> await Expect.That(subject).Should().NotBeInfinite();

			await Expect.That(Act).Should().NotThrow();
		}
	}
}
