using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;

namespace Testably.Expectations.Expectations;

public abstract partial class ThatNumber<TNumber, TSelf>
{
	public sealed class Nullable
	{
		private readonly IExpectationBuilder _expectationBuilder;

		internal Nullable(IExpectationBuilder expectationBuilder)
		{
			_expectationBuilder = expectationBuilder;
		}

		///// <summary>
		/////     Verifies that the value is equal to the specified <paramref name="expected" /> value.
		///// </summary>
		//public AssertionResult<bool?, Nullable> Is(bool? expected,
		//	[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		//	=> new(_expectationBuilder.Add(
		//			new NullableIsExpectation(expected),
		//			b => b.AppendMethod(nameof(Is), doNotPopulateThisValue)),
		//		this);

		///// <summary>
		/////     Verifies that the value is not equal to the specified <paramref name="unexpected" /> value.
		///// </summary>
		//public AssertionResult<bool?, Nullable> IsNot(bool? unexpected,
		//	[CallerArgumentExpression("unexpected")]
		//	string doNotPopulateThisValue = "")
		//	=> new(_expectationBuilder.Add(
		//			new NullableIsNotExpectation(unexpected),
		//			b => b.AppendMethod(nameof(IsNot), doNotPopulateThisValue)),
		//		this);

		///// <summary>
		/////     Verifies that the value is not <see langword="null" />.
		///// </summary>
		//public AssertionResult<bool?, Nullable> IsNotNull()
		//	=> new(_expectationBuilder.Add(
		//			new NullableIsNotExpectation(null),
		//			b => b.AppendMethod(nameof(IsNotNull))),
		//		this);

		///// <summary>
		/////     Verifies that the value is <see langword="null" />.
		///// </summary>
		//public AssertionResult<bool?, Nullable> IsNull()
		//	=> new(_expectationBuilder.Add(
		//			new NullableIsExpectation(null),
		//			b => b.AppendMethod(nameof(IsNull))),
		//		this);
	}
}
