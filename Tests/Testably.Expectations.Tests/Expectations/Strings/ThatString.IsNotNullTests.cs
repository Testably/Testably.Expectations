﻿using AutoFixture.Xunit2;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests.Expectations.Strings;

public sealed partial class ThatString
{
	public sealed class IsNotNullTests
	{
		[Fact]
		public async Task FailsWhenNull()
		{
			string? actual = null;

			async Task Act()
				=> await Expect.That(actual).IsNotNull();

			XunitException exception = await Assert.ThrowsAsync<XunitException>(Act);
			Assert.Equal("""
			             Expected that actual
			             is not null,
			             but it was
			             at Expect.That(actual).IsNotNull()
			             """, exception.Message);
		}

		[Theory]
		[AutoData]
		public async Task SucceedsWhenNotNull(string? actual)
		{
			async Task Act()
				=> await Expect.That(actual).IsNotNull();

			await Act();
		}
	}
}
