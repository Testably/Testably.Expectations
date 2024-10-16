using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;

namespace Testably.Expectations.Expectations.Booleans;

internal readonly struct IsNot(bool unexpected) : IExpectation<bool>
{
	#region IExpectation<bool> Members

	/// <inheritdoc />
	public ExpectationResult IsMetBy(bool actual)
	{
		if (!unexpected.Equals(actual))
		{
			return new ExpectationResult.Success<bool>(actual, ToString());
		}

		return new ExpectationResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
	}

	#endregion

	/// <inheritdoc />
	public override string ToString()
		=> $"is not {Formatter.Format(unexpected)}";
}

internal readonly struct NullableIsNot(bool? unexpected) : IExpectation<bool?>
{
	#region IExpectation<bool> Members

	/// <inheritdoc />
	public ExpectationResult IsMetBy(bool? actual)
	{
		if (!unexpected.Equals(actual))
		{
			return new ExpectationResult.Success<bool?>(actual, ToString());
		}

		return new ExpectationResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
	}

	#endregion

	/// <inheritdoc />
	public override string ToString()
		=> $"is not {Formatter.Format(unexpected)}";
}
