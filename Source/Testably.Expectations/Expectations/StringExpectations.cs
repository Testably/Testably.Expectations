using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Expectations.Strings;

namespace Testably.Expectations.Expectations;

public class StringExpectations
{
	private readonly IExpectationBuilder _expectationBuilder;

	internal StringExpectations(IExpectationBuilder expectationBuilder)
	{
		_expectationBuilder = expectationBuilder;
	}

	/// <summary>
	///     Expect the actual value to be equal to <paramref name="expected" />.
	/// </summary>
	public AssertionResult<string, StringExpectations> Is(string expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(_expectationBuilder.Add(
				new Is(expected),
				b => b.AppendMethod(nameof(Is), doNotPopulateThisValue)),
			this);

	/// <summary>
	///     Expect the actual value to not be null.
	/// </summary>
	public AssertionResult<string, StringExpectations> IsNotNull()
		=> new(_expectationBuilder.Add(
				new IsNotNull(),
				b => b.AppendMethod(nameof(IsNotNull))),
			this);

	/// <summary>
	///     Expect the actual value to not be null.
	/// </summary>
	public AssertionResult<string?, StringExpectations> IsNull()
		=> new(_expectationBuilder.Add(
				new IsNull(),
				b => b.AppendMethod(nameof(IsNull))),
			this);
}
