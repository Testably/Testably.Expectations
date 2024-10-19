using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;
using Testably.Expectations.Core.Helpers;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="bool" /> values.
/// </summary>
public static class ThatBoolExtensions
{
	/// <summary>
	///     Verifies that the actual value implies the specified <paramref name="consequent" /> value.
	/// </summary>
	public static AssertionResult<bool, That<bool>> Implies(this That<bool> source,
		bool consequent,
		[CallerArgumentExpression("consequent")]
		string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(new ImpliesExpectation(consequent),
				b => b.AppendMethod(nameof(Implies), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the actual value is equal to the specified <paramref name="expected" /> value.
	/// </summary>
	public static AssertionResult<bool, That<bool>> Is(this That<bool> source,
		bool expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(new IsExpectation(expected),
				b => b.AppendMethod(nameof(Is), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the actual value is <see langword="false" />.
	/// </summary>
	public static AssertionResult<bool, That<bool>> IsFalse(this That<bool> source)
		=> new(source.ExpectationBuilder.Add(new IsExpectation(false),
				b => b.AppendMethod(nameof(IsFalse))),
			source);

	/// <summary>
	///     Verifies that the actual value is not equal to the specified <paramref name="unexpected" /> value.
	/// </summary>
	public static AssertionResult<bool, That<bool>> IsNot(this That<bool> source,
		bool unexpected,
		[CallerArgumentExpression("unexpected")]
		string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(new IsNotExpectation(unexpected),
				b => b.AppendMethod(nameof(IsNot), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the actual value is <see langword="true" />.
	/// </summary>
	public static AssertionResult<bool, That<bool>> IsTrue(this That<bool> source)
		=> new(source.ExpectationBuilder.Add(new IsExpectation(true),
				b => b.AppendMethod(nameof(IsTrue))),
			source);

	private readonly struct ImpliesExpectation(bool consequent) : IExpectation<bool>
	{
		public ExpectationResult IsMetBy(bool actual)
		{
			if (!actual || consequent)
			{
				return new ExpectationResult.Success<bool>(actual, ToString());
			}

			return new ExpectationResult.Failure(ToString(), "it did not");
		}

		public override string ToString()
			=> $"implies {Formatter.Format(consequent)}";
	}

	private readonly struct IsNotExpectation(bool unexpected) : IExpectation<bool>
	{
		public ExpectationResult IsMetBy(bool actual)
		{
			if (!unexpected.Equals(actual))
			{
				return new ExpectationResult.Success<bool>(actual, ToString());
			}

			return new ExpectationResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> $"is not {Formatter.Format(unexpected)}";
	}

	private readonly struct IsExpectation(bool expected) : IExpectation<bool>
	{
		public ExpectationResult IsMetBy(bool actual)
		{
			if (expected.Equals(actual))
			{
				return new ExpectationResult.Success<bool>(actual, ToString());
			}

			return new ExpectationResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> $"is {Formatter.Format(expected)}";
	}
}
