using System.Globalization;

namespace Testably.Expectations.Tests.ThatTests.Numbers;

public sealed partial class NumberShould
{
	public sealed class BeNaNTests
	{
		[Fact]
		public async Task ForDouble_ShouldSupportChaining()
		{
			double subject = double.NaN;

			async Task Act()
				=> await That(subject).Should().BeNaN()
					.And.Be(subject);

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task ForDouble_WhenSubjectIsNaN_ShouldSucceed()
		{
			double subject = double.NaN;

			async Task Act() => await That(subject).Should().BeNaN();

			await That(Act).Should().NotThrow();
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
				=> await That(subject).Should().BeNaN();

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
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

			async Task Act() => await That(subject).Should().BeNaN()
				.And.Be(subject);

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task ForFloat_WhenSubjectIsNaN_ShouldSucceed()
		{
			float subject = float.NaN;

			async Task Act()
				=> await That(subject).Should().BeNaN();

			await That(Act).Should().NotThrow();
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
				=> await That(subject).Should().BeNaN();

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be NaN,
				              but found {subject.ToString(CultureInfo.InvariantCulture)}
				              at Expect.That(subject).Should().BeNaN()
				              """);
		}
	}

	public sealed class NotBeNaNTests
	{
		[Fact]
		public async Task ForDouble_ShouldSupportChaining()
		{
			double subject = double.Epsilon;

			async Task Act()
				=> await That(subject).Should().NotBeNaN()
					.And.Be(subject);

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task ForDouble_WhenSubjectIsNaN_ShouldFail()
		{
			double subject = double.NaN;

			async Task Act() => await That(subject).Should().NotBeNaN();

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              not be NaN,
				              but found {subject.ToString(CultureInfo.InvariantCulture)}
				              at Expect.That(subject).Should().NotBeNaN()
				              """);
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
		public async Task ForDouble_WhenSubjectIsNormalValue_ShouldSucceed(double subject)
		{
			async Task Act()
				=> await That(subject).Should().NotBeNaN();

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task ForFloat_ShouldSupportChaining()
		{
			float subject = float.Epsilon;

			async Task Act() => await That(subject).Should().NotBeNaN()
				.And.Be(subject);

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task ForFloat_WhenSubjectIsNaN_ShouldFail()
		{
			float subject = float.NaN;

			async Task Act()
				=> await That(subject).Should().NotBeNaN();

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              not be NaN,
				              but found {subject.ToString(CultureInfo.InvariantCulture)}
				              at Expect.That(subject).Should().NotBeNaN()
				              """);
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
		public async Task ForFloat_WhenSubjectIsNormalValue_ShouldSucceed(float subject)
		{
			async Task Act()
				=> await That(subject).Should().NotBeNaN();

			await That(Act).Should().NotThrow();
		}
	}
}
