﻿namespace Testably.Expectations.Tests.Primitives.Enums;

public sealed partial class ThatNullableEnum
{
	public sealed class IsTests
	{
		[Theory]
		[InlineData(MyColors.Blue, MyColors.Green)]
		[InlineData(MyColors.Blue, null)]
		[InlineData(MyColors.Green, MyColors.Blue)]
		[InlineData(MyColors.Green, null)]
		[InlineData(null, MyColors.Blue)]
		[InlineData(null, MyColors.Green)]
		public async Task WhenValuesAreDifferent_ShouldFail(MyColors? value, MyColors? expected)
		{
			async Task Act()
				=> await Expect.That(value).Is(expected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that value
				                   is {expected?.ToString() ?? "<null>"},
				                   but found {value?.ToString() ?? "<null>"}
				                   at Expect.That(value).Is(expected)
				                   """);
		}

		[Theory]
		[InlineData(MyColors.Blue)]
		[InlineData(MyColors.Green)]
		public async Task WhenValuesAreTheSame_ShouldSucceed(MyColors? value)
		{
			MyColors? expected = value;

			async Task Act()
				=> await Expect.That(value).Is(expected);

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			MyColors? subject = null;

			async Task Act()
				=> await Expect.That(subject).Is(MyColors.Red);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  is Red,
				                  but found <null>
				                  at Expect.That(subject).Is(MyColors.Red)
				                  """);
		}

		[Fact]
		public async Task WhenSubjectAndExpectedAreNull_ShouldSucceed()
		{
			MyColors? subject = null;

			async Task Act()
				=> await Expect.That(subject).Is(null);

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
