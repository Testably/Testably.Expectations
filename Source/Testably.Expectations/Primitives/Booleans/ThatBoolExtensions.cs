using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Core.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="bool" /> values.
/// </summary>
public static partial class ThatBoolExtensions
{
	/// <summary>
	///     Verifies that the actual value implies the specified <paramref name="consequent" /> value.
	/// </summary>
	public static AndOrExpectationResult<bool, That<bool>> Implies(this That<bool> source,
		bool consequent,
		[CallerArgumentExpression("consequent")]
		string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(new ImpliesConstraint(consequent),
				b => b.AppendMethod(nameof(Implies), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the actual value is equal to the specified <paramref name="expected" /> value.
	/// </summary>
	public static AndOrExpectationResult<bool, That<bool>> Is(this That<bool> source,
		bool expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(new IsConstraint(expected),
				b => b.AppendMethod(nameof(Is), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the actual value is <see langword="false" />.
	/// </summary>
	public static AndOrExpectationResult<bool, That<bool>> IsFalse(this That<bool> source)
		=> new(source.ExpectationBuilder.Add(new IsConstraint(false),
				b => b.AppendMethod(nameof(IsFalse))),
			source);

	/// <summary>
	///     Verifies that the actual value is not equal to the specified <paramref name="unexpected" /> value.
	/// </summary>
	public static AndOrExpectationResult<bool, That<bool>> IsNot(this That<bool> source,
		bool unexpected,
		[CallerArgumentExpression("unexpected")]
		string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(new IsNotConstraint(unexpected),
				b => b.AppendMethod(nameof(IsNot), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the actual value is <see langword="true" />.
	/// </summary>
	public static AndOrExpectationResult<bool, That<bool>> IsTrue(this That<bool> source)
		=> new(source.ExpectationBuilder.Add(new IsConstraint(true),
				b => b.AppendMethod(nameof(IsTrue))),
			source);
}
