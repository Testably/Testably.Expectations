using Testably.Expectations.Core;

namespace Testably.Expectations.Expectations;

internal class BeNull<TActual> : INullableExpectation<TActual>
{
	#region INullableExpectation<TActual> Members

	/// <inheritdoc />
	public ExpectationResult IsMetBy(TActual? actual)
	{
		if (actual == null)
		{
			return new ExpectationResult.Success();
		}

		return new ExpectationResult.Failure(ToString(), $"found {actual}");
	}

	#endregion

	/// <inheritdoc />
	public override string ToString()
		=> "to be null";
}
