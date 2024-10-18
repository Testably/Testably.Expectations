using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;

namespace Testably.Expectations.Expectations;

public abstract partial class ThatNumber<TNumber, TSelf>
#if NET8_0_OR_GREATER
	where TNumber : struct, INumber<TNumber>
#else
    where TNumber : struct, System.IComparable<TNumber>
#endif
	where TSelf : ThatNumber<TNumber, TSelf>
{
	private readonly IExpectationBuilder _expectationBuilder;

	internal ThatNumber(IExpectationBuilder expectationBuilder)
	{
		_expectationBuilder = expectationBuilder;
	}

	/// <summary>
	///     Verifies that the value is equal to the specified <paramref name="expected" /> value.
	/// </summary>
	public AssertionResult<TNumber, TSelf> Is(TNumber expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(_expectationBuilder.Add(new IsExpectation(expected),
				b => b.AppendMethod(nameof(Is), doNotPopulateThisValue)),
			(TSelf)this);

	/// <summary>
	///     Verifies that the value is equal to the specified <paramref name="expected" /> value.
	/// </summary>
	public AssertionResult<TNumber, TSelf> Is(TNumber? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(_expectationBuilder.Add(new IsExpectation(expected),
				b => b.AppendMethod(nameof(Is), doNotPopulateThisValue)),
			(TSelf)this);

	/// <summary>
	///     Verifies that the value is not equal to the specified <paramref name="expected" /> value.
	/// </summary>
	public AssertionResult<TNumber, TSelf> IsNot(TNumber expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(_expectationBuilder.Add(new IsNotExpectation(expected),
				b => b.AppendMethod(nameof(IsNot), doNotPopulateThisValue)),
			(TSelf)this);
}
