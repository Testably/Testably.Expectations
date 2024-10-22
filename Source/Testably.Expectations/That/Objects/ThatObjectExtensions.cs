using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Options;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="object" /> values.
/// </summary>
public static partial class ThatObjectExtensions
{
	/// <summary>
	///     Verifies that the subject is of type <typeparamref name="TType" />.
	/// </summary>
	public static AndOrWhichExpectationResult<TType, That<object?>> Is<TType>(
		this That<object?> source)
		=> new(source.ExpectationBuilder.Add(
				new IsConstraint<TType>(),
				b => b.Append('.').Append(nameof(Is)).Append('<').Append(typeof(TType).Name)
					.Append(">()")),
			source);

	/// <summary>
	///     Verifies that the subject is equivalent to the <paramref name="expected" /> value.
	/// </summary>
	public static EquivalencyOptionsExpectationResult<T, That<T>> IsEquivalentTo<T>(this That<T> source,
		object expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		var options = new EquivalencyOptions();
		return new(source.ExpectationBuilder.Add(
				new IsEquivalentToConstraint(expected, doNotPopulateThisValue, options),
				b => b.AppendMethod(nameof(IsEquivalentTo), doNotPopulateThisValue)),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the value satisfies the <paramref name="expectations" /> on the properties selected by the
	///     <paramref name="selector" />.
	/// </summary>
	public static AndOrExpectationResult<T, That<object?>> Satisfies<T, TProperty>(
		this That<object?> source,
		Expression<Func<T, TProperty?>> selector,
		Action<That<TProperty?>> expectations,
		[CallerArgumentExpression("selector")] string doNotPopulateThisValue1 = "",
		[CallerArgumentExpression("expectations")]
		string doNotPopulateThisValue2 = "")
		=> new(source.ExpectationBuilder.Which<T, TProperty?>(
				PropertyAccessor<T, TProperty?>.FromExpression(selector),
				expectations,
				b => b.AppendGenericMethod<T, TProperty>(nameof(Satisfies), doNotPopulateThisValue1,
					doNotPopulateThisValue2),
				whichTextSeparator: "satisfies "),
			source);
}
