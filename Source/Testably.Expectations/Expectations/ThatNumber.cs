using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;

namespace Testably.Expectations.Expectations;

public sealed partial class ThatNumber<TNumber>
#if NET8_0_OR_GREATER
	where TNumber : struct, INumber<TNumber>
#else
    where TNumber : struct, System.IComparable<TNumber>
#endif
{
	private readonly IExpectationBuilder _expectationBuilder;

	internal ThatNumber(IExpectationBuilder expectationBuilder)
	{
		_expectationBuilder = expectationBuilder;
	}

	/// <summary>
	///     Verifies that the value is equal to the specified <paramref name="expected" /> value.
	/// </summary>
	public AssertionResult<TNumber, ThatNumber<TNumber>> Is(TNumber expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(_expectationBuilder.Add(new IsExpectation(expected),
				b => b.AppendMethod(nameof(Is), doNotPopulateThisValue)),
			this);

	/// <summary>
	///     Verifies that the value is equal to the specified <paramref name="expected" /> value.
	/// </summary>
	public AssertionResult<TNumber, ThatNumber<TNumber>> Is(TNumber? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(_expectationBuilder.Add(new IsExpectation(expected),
				b => b.AppendMethod(nameof(Is), doNotPopulateThisValue)),
			this);

	/// <summary>
	///     Verifies that the value is equal to the specified <paramref name="expected" /> value.
	/// </summary>
	public AssertionResult<TNumber, ThatNumber<TNumber>> IsNot(TNumber expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(_expectationBuilder.Add(new IsNotExpectation(expected),
				b => b.AppendMethod(nameof(IsNot), doNotPopulateThisValue)),
			this);
}
