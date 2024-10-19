using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;
using Testably.Expectations.Core.Helpers;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="bool" />? values.
/// </summary>
public static class ThatBoolNullableExtensions
{
	/// <summary>
	///     Verifies that the actual value is equal to the specified <paramref name="expected" /> value.
	/// </summary>
	public static AssertionResult<bool?, That<bool?>> Is(this That<bool?> source,
		bool? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(
				new NullableIsExpectation(expected),
				b => b.AppendMethod(nameof(Is), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the actual value is <see langword="false" />.
	/// </summary>
	public static AssertionResult<bool?, That<bool?>> IsFalse(this That<bool?> source)
		=> new(source.ExpectationBuilder.Add(
				new NullableIsExpectation(false),
				b => b.AppendMethod(nameof(IsFalse))),
			source);

	/// <summary>
	///     Verifies that the actual value is not equal to the specified <paramref name="unexpected" /> value.
	/// </summary>
	public static AssertionResult<bool?, That<bool?>> IsNot(this That<bool?> source,
		bool? unexpected,
		[CallerArgumentExpression("unexpected")]
			string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(
				new NullableIsNotExpectation(unexpected),
				b => b.AppendMethod(nameof(IsNot), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the actual value is not <see langword="false" />.
	/// </summary>
	public static AssertionResult<bool?, That<bool?>> IsNotFalse(this That<bool?> source)
		=> new(source.ExpectationBuilder.Add(
				new NullableIsNotExpectation(false),
				b => b.AppendMethod(nameof(IsNotFalse))),
			source);

	/// <summary>
	///     Verifies that the actual value is not <see langword="null" />.
	/// </summary>
	public static AssertionResult<bool?, That<bool?>> IsNotNull(this That<bool?> source)
		=> new(source.ExpectationBuilder.Add(
				new NullableIsNotExpectation(null),
				b => b.AppendMethod(nameof(IsNotNull))),
			source);

	/// <summary>
	///     Verifies that the actual value is not <see langword="true" />.
	/// </summary>
	public static AssertionResult<bool?, That<bool?>> IsNotTrue(this That<bool?> source)
		=> new(source.ExpectationBuilder.Add(
				new NullableIsNotExpectation(true),
				b => b.AppendMethod(nameof(IsNotTrue))),
			source);

	/// <summary>
	///     Verifies that the actual value is <see langword="null" />.
	/// </summary>
	public static AssertionResult<bool?, That<bool?>> IsNull(this That<bool?> source)
		=> new(source.ExpectationBuilder.Add(
				new NullableIsExpectation(null),
				b => b.AppendMethod(nameof(IsNull))),
			source);

	/// <summary>
	///     Verifies that the actual value is <see langword="true" />.
	/// </summary>
	public static AssertionResult<bool?, That<bool?>> IsTrue(this That<bool?> source)
		=> new(source.ExpectationBuilder.Add(
				new NullableIsExpectation(true),
				b => b.AppendMethod(nameof(IsTrue))),
			source);

	private readonly struct NullableIsNotExpectation(bool? unexpected) : IExpectation<bool?>
	{
		public ExpectationResult IsMetBy(bool? actual)
		{
			if (!unexpected.Equals(actual))
			{
				return new ExpectationResult.Success<bool?>(actual, ToString());
			}

			return new ExpectationResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> $"is not {Formatter.Format(unexpected)}";
	}

	private readonly struct NullableIsExpectation(bool? expected) : IExpectation<bool?>
	{
		public ExpectationResult IsMetBy(bool? actual)
		{
			if (expected.Equals(actual))
			{
				return new ExpectationResult.Success<bool?>(actual, ToString());
			}

			return new ExpectationResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> $"is {Formatter.Format(expected)}";
	}
}
