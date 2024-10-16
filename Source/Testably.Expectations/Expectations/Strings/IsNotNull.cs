using Testably.Expectations.Core;

namespace Testably.Expectations.Expectations.Strings;

internal class IsNotNull : IExpectation<string>
{
	#region INullableExpectation<T> Members

	/// <inheritdoc />
	public ExpectationResult IsMetBy(string? actual)
	{
		if (actual is null)
		{
			return new ExpectationResult.Failure(ToString(), "it was");
		}

		return new ExpectationResult.Success<string>(actual, ToString());
	}

	#endregion

	/// <inheritdoc />
	public override string ToString()
		=> "is not null";
}
