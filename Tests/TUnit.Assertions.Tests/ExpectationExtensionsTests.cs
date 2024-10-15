using AutoFixture.Xunit2;
using System;
using System.Threading.Tasks;
using Xunit;

namespace TUnit.Assertions.Tests;

public sealed class ExpectationExtensionsTests
{
	[Theory]
	[AutoData]
	public async Task WhichMessage_ShouldGiveAccessToTheMessageOfAnExceptionForExpectations(
		string? message)
	{
		var action = () => { return message; };

		var result = await Assert.That(action).Throws<ArgumentException>().Which
			.HasMessage("=)").And
			.HasInnerException(e => e
				.HasInnerException(e2 => e2
					.HasMessage("foo")));
		_ = result.Message.Length;
		//var result = await Assert.That(message).Is("foo").And.Is("bar");

		//Xunit.Assert.Equal(10, result.Length);
	}
}
