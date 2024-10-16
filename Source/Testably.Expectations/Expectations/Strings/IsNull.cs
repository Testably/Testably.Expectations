using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;

namespace Testably.Expectations.Expectations.Strings;

internal class IsNull : IExpectation<string>
{
	#region INullableExpectation<T> Members

	/// <inheritdoc />
	public ExpectationResult IsMetBy(string? actual)
	{
		if (actual is not null)
		{
			return new ExpectationResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
		}

		return new ExpectationResult.Success<string?>(actual, ToString());
	}

	#endregion

	/// <inheritdoc />
	public override string ToString()
		=> "is null";
}
