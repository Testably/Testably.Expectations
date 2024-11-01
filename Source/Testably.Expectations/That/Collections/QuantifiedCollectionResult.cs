using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.EvaluationContext;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;
// ReSharper disable once CheckNamespace

namespace Testably.Expectations;

/// <summary>
///     A quantifiable result matching items against the expected <see cref="Quantity" />.
/// </summary>
public class QuantifiedCollectionResult<TResult>(
	TResult result,
	ExpectationBuilder expectationBuilder,
	CollectionQuantifier quantity)
{
	/// <summary>
	///     The expectation builder.
	/// </summary>
	public ExpectationBuilder ExpectationBuilder { get; } = expectationBuilder;

	/// <summary>
	///     The quantifier.
	/// </summary>
	public CollectionQuantifier Quantity => quantity;

	/// <summary>
	///     The return value of the expectation.
	/// </summary>
	public TResult Result => result;
}
