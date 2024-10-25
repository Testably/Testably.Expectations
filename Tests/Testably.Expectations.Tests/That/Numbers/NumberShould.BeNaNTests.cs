﻿using System.Globalization;

namespace Testably.Expectations.Tests.That.Numbers;

public sealed partial class NumberShould
{
	public sealed class BeNaNTests
	{
		[Fact]
		public async Task ForDouble_ShouldSupportChaining()
		{
			double subject = double.NaN;

			async Task Act()
				=> await Expect.That(subject).Should().BeNaN()
					.And.Be(subject);

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task ForDouble_WhenSubjectIsNaN_ShouldSucceed()
		{
			double subject = double.NaN;

			async Task Act() => await Expect.That(subject).Should().BeNaN();

			await Expect.That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(-1d)]
		[InlineData(0d)]
		[InlineData(1d)]
		[InlineData(double.MinValue)]
		[InlineData(double.MaxValue)]
		[InlineData(double.Epsilon)]
		[InlineData(double.NegativeInfinity)]
		[InlineData(double.PositiveInfinity)]
		public async Task ForDouble_WhenSubjectIsNormalValue_ShouldFail(double subject)
		{
			async Task Act()
				=> await Expect.That(subject).Should().BeNaN();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HaveMessage($"""
				                   Expected subject to
				                   be NaN,
				                   but found {subject.ToString(CultureInfo.InvariantCulture)}
				                   at Expect.That(subject).Should().BeNaN()
				                   """);
		}

		[Fact]
		public async Task ForFloat_ShouldSupportChaining()
		{
			float subject = float.NaN;

			async Task Act() => await Expect.That(subject).Should().BeNaN()
				.And.Be(subject);

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task ForFloat_WhenSubjectIsNaN_ShouldSucceed()
		{
			float subject = float.NaN;

			async Task Act()
				=> await Expect.That(subject).Should().BeNaN();

			await Expect.That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(-1f)]
		[InlineData(0f)]
		[InlineData(1f)]
		[InlineData(float.MinValue)]
		[InlineData(float.MaxValue)]
		[InlineData(float.Epsilon)]
		[InlineData(float.NegativeInfinity)]
		[InlineData(float.PositiveInfinity)]
		public async Task ForFloat_WhenSubjectIsNormalValue_ShouldFail(float subject)
		{
			async Task Act()
				=> await Expect.That(subject).Should().BeNaN();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HaveMessage($"""
				                   Expected subject to
				                   be NaN,
				                   but found {subject.ToString(CultureInfo.InvariantCulture)}
				                   at Expect.That(subject).Should().BeNaN()
				                   """);
		}
	}
}
