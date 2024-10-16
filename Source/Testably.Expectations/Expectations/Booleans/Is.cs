using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;

namespace Testably.Expectations.Expectations.Booleans;

internal readonly struct Is(bool expected) : IExpectation<bool>
{
	#region IExpectation<bool> Members

	/// <inheritdoc />
	public ExpectationResult IsMetBy(bool actual)
	{
		if (expected.Equals(actual))
		{
			return new ExpectationResult.Success<bool>(actual, ToString());
		}

		return new ExpectationResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
	}

	#endregion

	/// <inheritdoc />
	public override string ToString()
		=> $"is {Formatter.Format(expected)}";
}

internal readonly struct NullableIs(bool? expected) : IExpectation<bool?>
{
	#region IExpectation<bool> Members

	/// <inheritdoc />
	public ExpectationResult IsMetBy(bool? actual)
	{
		if (expected.Equals(actual))
		{
			return new ExpectationResult.Success<bool?>(actual, ToString());
		}

		return new ExpectationResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
	}

	#endregion

	/// <inheritdoc />
	public override string ToString()
		=> $"is {Formatter.Format(expected)}";
}
