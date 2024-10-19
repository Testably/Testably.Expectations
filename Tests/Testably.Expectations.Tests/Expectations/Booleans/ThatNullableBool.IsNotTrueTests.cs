﻿using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests.Expectations.Booleans;

public sealed partial class ThatNullableBool
{
	public sealed class IsNotTrueTests
	{
		[Fact]
		public async Task Fails_For_True_Value()
		{
			bool? value = true;

			async Task Act()
				=> await That(value).IsNotTrue();

			await That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that value
				                  is not True,
				                  but found True
				                  at Expect.That(value).IsNotTrue()
				                  """);
		}

		[Theory]
		[InlineData(false)]
		[InlineData(null)]
		public async Task Succeeds_For_False_Or_Null_Value(bool? value)
		{
			async Task Act()
				=> await That(value).IsNotTrue();

			await That(Act).DoesNotThrow();
		}
	}
}
