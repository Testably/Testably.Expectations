using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Core.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="bool" />? values.
/// </summary>
public static partial class ThatNullableBoolExtensions
{
	/// <summary>
	///     Verifies that the actual value is equal to the specified <paramref name="expected" /> value.
	/// </summary>
	public static AssertionResultAndOr<bool?, That<bool?>> Is(this That<bool?> source,
		bool? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(
				new IsConstraint(expected),
				b => b.AppendMethod(nameof(Is), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the actual value is <see langword="false" />.
	/// </summary>
	public static AssertionResultAndOr<bool?, That<bool?>> IsFalse(this That<bool?> source)
		=> new(source.ExpectationBuilder.Add(
				new IsConstraint(false),
				b => b.AppendMethod(nameof(IsFalse))),
			source);

	/// <summary>
	///     Verifies that the actual value is not equal to the specified <paramref name="unexpected" /> value.
	/// </summary>
	public static AssertionResultAndOr<bool?, That<bool?>> IsNot(this That<bool?> source,
		bool? unexpected,
		[CallerArgumentExpression("unexpected")]
		string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(
				new IsNotConstraint(unexpected),
				b => b.AppendMethod(nameof(IsNot), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the actual value is not <see langword="false" />.
	/// </summary>
	public static AssertionResultAndOr<bool?, That<bool?>> IsNotFalse(this That<bool?> source)
		=> new(source.ExpectationBuilder.Add(
				new IsNotConstraint(false),
				b => b.AppendMethod(nameof(IsNotFalse))),
			source);

	/// <summary>
	///     Verifies that the actual value is not <see langword="null" />.
	/// </summary>
	public static AssertionResultAndOr<bool?, That<bool?>> IsNotNull(this That<bool?> source)
		=> new(source.ExpectationBuilder.Add(
				new IsNotConstraint(null),
				b => b.AppendMethod(nameof(IsNotNull))),
			source);

	/// <summary>
	///     Verifies that the actual value is not <see langword="true" />.
	/// </summary>
	public static AssertionResultAndOr<bool?, That<bool?>> IsNotTrue(this That<bool?> source)
		=> new(source.ExpectationBuilder.Add(
				new IsNotConstraint(true),
				b => b.AppendMethod(nameof(IsNotTrue))),
			source);

	/// <summary>
	///     Verifies that the actual value is <see langword="null" />.
	/// </summary>
	public static AssertionResultAndOr<bool?, That<bool?>> IsNull(this That<bool?> source)
		=> new(source.ExpectationBuilder.Add(
				new IsConstraint(null),
				b => b.AppendMethod(nameof(IsNull))),
			source);

	/// <summary>
	///     Verifies that the actual value is <see langword="true" />.
	/// </summary>
	public static AssertionResultAndOr<bool?, That<bool?>> IsTrue(this That<bool?> source)
		=> new(source.ExpectationBuilder.Add(
				new IsConstraint(true),
				b => b.AppendMethod(nameof(IsTrue))),
			source);
}
