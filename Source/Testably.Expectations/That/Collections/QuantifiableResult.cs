using System.Linq;
using Testably.Expectations.Core;
using Testably.Expectations.Options;

namespace Testably.Expectations.That.Collections;

/// <summary>
///     A quantifiable result matching items against the expected <see cref="Quantity" />.
/// </summary>
public class QuantifiableResult<TResult>(
	TResult result,
	ExpectationBuilder expectationBuilder,
	CollectionQuantifier quantity)
{
	public ExpectationBuilder ExpectationBuilder { get; } = expectationBuilder;

	/// <summary>
	///     The quantifier.
	/// </summary>
	public CollectionQuantifier Quantity => quantity;

	/// <summary>
	///     The collection.
	/// </summary>
	public TResult Result => result;

}
