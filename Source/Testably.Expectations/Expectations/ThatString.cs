using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;

namespace Testably.Expectations.Expectations;

public sealed partial class ThatString
{
	private readonly IExpectationBuilder _expectationBuilder;

	internal ThatString(IExpectationBuilder expectationBuilder)
	{
		_expectationBuilder = expectationBuilder;
	}

	/// <summary>
	///     Expect the actual value to be equal to <paramref name="expected" />.
	/// </summary>
	public AssertionResult<string, ThatString> Is(string expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(_expectationBuilder.Add(
				new IsExpectation(expected),
				b => b.AppendMethod(nameof(Is), doNotPopulateThisValue)),
			this);

	/// <summary>
	///     Expect the actual value to not be null.
	/// </summary>
	public AssertionResult<string, ThatString> IsNotNull()
		=> new(_expectationBuilder.Add(
				new IsNotNullExpectation(),
				b => b.AppendMethod(nameof(IsNotNull))),
			this);

	/// <summary>
	///     Expect the actual value to not be null.
	/// </summary>
	public AssertionResult<string?, ThatString> IsNull()
		=> new(_expectationBuilder.Add(
				new IsNullExpectation(),
				b => b.AppendMethod(nameof(IsNull))),
			this);
}
