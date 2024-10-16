using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;

namespace Testably.Expectations.Expectations;

public sealed partial class BooleanExpectations
{
	private readonly IExpectationBuilder _expectationBuilder;

	internal BooleanExpectations(IExpectationBuilder expectationBuilder)
	{
		_expectationBuilder = expectationBuilder;
	}

	/// <summary>
	///     Verifies that the value implies the specified <paramref name="consequent" /> value.
	/// </summary>
	public AssertionResult<bool, BooleanExpectations> Implies(bool consequent,
		[CallerArgumentExpression("consequent")]
		string doNotPopulateThisValue = "")
		=> new(_expectationBuilder.Add(
				new ImpliesExpectation(consequent),
				b => b.AppendMethod(nameof(Implies), doNotPopulateThisValue)),
			this);

	/// <summary>
	///     Verifies that the value is equal to the specified <paramref name="expected" /> value.
	/// </summary>
	public AssertionResult<bool, BooleanExpectations> Is(bool expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(_expectationBuilder.Add(
				new IsExpectation(expected),
				b => b.AppendMethod(nameof(Is), doNotPopulateThisValue)),
			this);

	/// <summary>
	///     Verifies that the value is <see langword="false" />.
	/// </summary>
	public AssertionResult<bool, BooleanExpectations> IsFalse()
		=> new(_expectationBuilder.Add(
				new IsExpectation(false),
				b => b.AppendMethod(nameof(IsFalse))),
			this);

	/// <summary>
	///     Verifies that the value is not equal to the specified <paramref name="unexpected" /> value.
	/// </summary>
	public AssertionResult<bool, BooleanExpectations> IsNot(bool unexpected,
		[CallerArgumentExpression("unexpected")]
		string doNotPopulateThisValue = "")
		=> new(_expectationBuilder.Add(
				new IsNotExpectation(unexpected),
				b => b.AppendMethod(nameof(IsNot), doNotPopulateThisValue)),
			this);

	/// <summary>
	///     Verifies that the value is <see langword="true" />.
	/// </summary>
	public AssertionResult<bool, BooleanExpectations> IsTrue()
		=> new(_expectationBuilder.Add(
				new IsExpectation(true),
				b => b.AppendMethod(nameof(IsTrue))),
			this);
}
