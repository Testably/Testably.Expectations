using System.Globalization;

namespace Testably.Expectations.Tests.That.Numbers;

public sealed partial class NumberShould
{
	public sealed class BeFiniteTests
	{
		[Fact]
		public async Task ForDouble_ShouldSupportChaining()
		{
			double subject = double.Epsilon;

			async Task Act()
				=> await Expect.That(subject).Should().BeFinite()
					.And.Be(subject);

			await Expect.That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(double.PositiveInfinity)]
		[InlineData(double.NegativeInfinity)]
		[InlineData(double.NaN)]
		public async Task ForDouble_WhenSubjectIsInfinity_ShouldFail(double subject)
		{
			async Task Act() => await Expect.That(subject).Should().BeFinite();

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be finite,
				              but found {subject.ToString(CultureInfo.InvariantCulture)}
				              at Expect.That(subject).Should().BeFinite()
				              """);
		}

		[Theory]
		[InlineData(-1d)]
		[InlineData(0d)]
		[InlineData(1d)]
		[InlineData(double.MinValue)]
		[InlineData(double.MaxValue)]
		[InlineData(double.Epsilon)]
		public async Task ForDouble_WhenSubjectIsNormalValue_ShouldSucceed(double subject)
		{
			async Task Act()
				=> await Expect.That(subject).Should().BeFinite();

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task ForFloat_ShouldSupportChaining()
		{
			float subject = float.Epsilon;

			async Task Act() => await Expect.That(subject).Should().BeFinite()
				.And.Be(subject);

			await Expect.That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(float.PositiveInfinity)]
		[InlineData(float.NegativeInfinity)]
		[InlineData(float.NaN)]
		public async Task ForFloat_WhenSubjectIsInfinity_ShouldFail(float subject)
		{
			async Task Act()
				=> await Expect.That(subject).Should().BeFinite();

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be finite,
				              but found {subject.ToString(CultureInfo.InvariantCulture)}
				              at Expect.That(subject).Should().BeFinite()
				              """);
		}

		[Theory]
		[InlineData(-1f)]
		[InlineData(0f)]
		[InlineData(1f)]
		[InlineData(float.MinValue)]
		[InlineData(float.MaxValue)]
		[InlineData(float.Epsilon)]
		public async Task ForFloat_WhenSubjectIsNormalValue_ShouldSucceed(float subject)
		{
			async Task Act()
				=> await Expect.That(subject).Should().BeFinite();

			await Expect.That(Act).Should().NotThrow();
		}
	}

	public sealed class NotBeFiniteTests
	{
		[Fact]
		public async Task ForDouble_ShouldSupportChaining()
		{
			double subject = double.PositiveInfinity;

			async Task Act()
				=> await Expect.That(subject).Should().NotBeFinite()
					.And.Be(subject);

			await Expect.That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(double.PositiveInfinity)]
		[InlineData(double.NegativeInfinity)]
		[InlineData(double.NaN)]
		public async Task ForDouble_WhenSubjectIsInfinity_ShouldSucceed(double subject)
		{
			async Task Act() => await Expect.That(subject).Should().NotBeFinite();

			await Expect.That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(-1d)]
		[InlineData(0d)]
		[InlineData(1d)]
		[InlineData(double.MinValue)]
		[InlineData(double.MaxValue)]
		[InlineData(double.Epsilon)]
		public async Task ForDouble_WhenSubjectIsNormalValue_ShouldFail(double subject)
		{
			async Task Act()
				=> await Expect.That(subject).Should().NotBeFinite();

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              not be finite,
				              but found {subject.ToString(CultureInfo.InvariantCulture)}
				              at Expect.That(subject).Should().NotBeFinite()
				              """);
		}

		[Fact]
		public async Task ForFloat_ShouldSupportChaining()
		{
			float subject = float.PositiveInfinity;

			async Task Act() => await Expect.That(subject).Should().NotBeFinite()
				.And.Be(subject);

			await Expect.That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(float.PositiveInfinity)]
		[InlineData(float.NegativeInfinity)]
		[InlineData(float.NaN)]
		public async Task ForFloat_WhenSubjectIsInfinity_ShouldSucceed(float subject)
		{
			async Task Act()
				=> await Expect.That(subject).Should().NotBeFinite();

			await Expect.That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(-1f)]
		[InlineData(0f)]
		[InlineData(1f)]
		[InlineData(float.MinValue)]
		[InlineData(float.MaxValue)]
		[InlineData(float.Epsilon)]
		public async Task ForFloat_WhenSubjectIsNormalValue_ShouldFail(float subject)
		{
			async Task Act()
				=> await Expect.That(subject).Should().NotBeFinite();

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              not be finite,
				              but found {subject.ToString(CultureInfo.InvariantCulture)}
				              at Expect.That(subject).Should().NotBeFinite()
				              """);
		}
	}
}
