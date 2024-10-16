using Testably.Expectations.Core;
using Testably.Expectations.CoreVoid.Helpers;
using Testably.Expectations.Expectations.Bool;

namespace Testably.Expectations.Expectations;

public class BoolExpectations
{
	private readonly IExpectationBuilder _expectationBuilder;

	internal BoolExpectations(IExpectationBuilder expectationBuilder)
	{
		_expectationBuilder = expectationBuilder;
	}

	/// <summary>
	///     Expect the actual value to be equal to <paramref name="expected" />.
	/// </summary>
	public AssertionResult<bool, BoolExpectations> IsFalse()
		=> new(_expectationBuilder.Add(
			new IsFalse(),
			b => b.AppendMethod(nameof(IsFalse))),
			this);

	/// <summary>
	///     Expect the actual value to not be null.
	/// </summary>
	public AssertionResult<string, BoolExpectations> IsTrue()
		=> new(_expectationBuilder.Add(
			new IsTrue(),
			b => b.AppendMethod(nameof(IsTrue))),
			this);
}
