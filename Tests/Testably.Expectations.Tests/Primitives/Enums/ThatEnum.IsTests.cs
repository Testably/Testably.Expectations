﻿namespace Testably.Expectations.Tests.Primitives.Enums;

public sealed partial class ThatEnum
{
	public sealed class IsTests
	{
		[Theory]
		[InlineData(MyColors.Blue, MyColors.Green)]
		[InlineData(MyColors.Green, MyColors.Blue)]
		public async Task WhenValuesAreDifferent_ShouldFail(MyColors value, MyColors expected)
		{
			async Task Act()
				=> await Expect.That(value).Is(expected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that value
				                   is {expected},
				                   but found {value}
				                   at Expect.That(value).Is(expected)
				                   """);
		}

		[Theory]
		[InlineData(MyColors.Blue)]
		[InlineData(MyColors.Green)]
		public async Task WhenValuesAreTheSame_ShouldSucceed(MyColors value)
		{
			MyColors expected = value;

			async Task Act()
				=> await Expect.That(value).Is(expected);

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
