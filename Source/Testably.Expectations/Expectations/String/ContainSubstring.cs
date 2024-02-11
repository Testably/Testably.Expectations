﻿using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;

namespace Testably.Expectations.Expectations.String;

internal class ContainSubstring : IExpectation<string?>
{
	private readonly string _expected;

	public ContainSubstring(string expected)
	{
		_expected = expected;
	}

	#region IExpectation<string?> Members

	/// <inheritdoc />
	public ExpectationResult IsMetBy(string? actual)
	{
		if (actual?.Contains(_expected) == true)
		{
			return new ExpectationResult.Success(ToString());
		}

		return new ExpectationResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
	}

	#endregion

	/// <inheritdoc />
	public override string ToString()
		=> $"to contain {Formatter.Format(_expected)}";
}
