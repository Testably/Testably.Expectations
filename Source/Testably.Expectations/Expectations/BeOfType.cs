using Testably.Expectations.Core;

namespace Testably.Expectations.Expectations;

internal class BeOfType<TType> : IExpectation<object?, TType>
{
	/// <inheritdoc />
	public ExpectationResult IsMetBy(object? actual)
	{
		if (actual is null)
		{
			return new ExpectationResult.Failure(ToString(), "found null");
		}

		if (actual is TType)
		{
			return new ExpectationResult.Success();
		}

		return new ExpectationResult.Failure(ToString(), $"it was of type {actual.GetType().Name}");
	}

	/// <inheritdoc />
	public override string ToString()
		=> $"to be of type {typeof(TType).Name}";
}
