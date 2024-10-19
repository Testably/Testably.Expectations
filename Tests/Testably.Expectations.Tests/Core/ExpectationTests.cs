﻿using System.Threading.Tasks;
using Xunit;

namespace Testably.Expectations.Tests.Core;

public sealed class ExpectationTests
{
	[Theory]
	[InlineData(false, true)]
	[InlineData(true, false)]
	[InlineData(false, false)]
	public async Task And_ShouldFailWhenAnyArgumentFails(bool a, bool b)
	{
		async Task Act()
			=> await Expect.That(true).Is(a).And.Is(b);

		await Expect.That(Act).ThrowsException();
	}

	[Theory]
	[InlineData(true, true)]
	public async Task And_ShouldRequireBothArgumentsToSucceed(bool a, bool b)
	{
		async Task Act()
			=> await Expect.That(true).Is(a).And.Is(b);

		await Expect.That(Act).DoesNotThrow();
	}

	[Theory]
	[InlineData(false, false)]
	public async Task Or_ShouldFailWhenBothArgumentsFail(bool a, bool b)
	{
		async Task Act()
			=> await Expect.That(true).Is(a).Or.Is(b);

		await Expect.That(Act).ThrowsException();
	}

	[Theory]
	[InlineData(false, true)]
	[InlineData(true, false)]
	[InlineData(true, true)]
	public async Task Or_ShouldRequireAnyArgumentToSucceed(bool a, bool b)
	{
		async Task Act()
			=> await Expect.That(true).Is(a).Or.Is(b);

		await Expect.That(Act).DoesNotThrow();
	}
}
