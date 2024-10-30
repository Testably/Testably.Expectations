using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Options;
using Testably.Expectations.That.Collections;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatEnumerableShould
{
	/// <summary>
	///     Verifies that at least <paramref name="minimum" /> items...
	/// </summary>
	public static QuantifiableResult<IThat<IEnumerable<TItem>>> AtLeast<TItem>(
		this IThat<IEnumerable<TItem>> source,
		int minimum, [CallerArgumentExpression("minimum")] string doNotPopulateThisValue = "")
	{
		source.ExpectationBuilder.AppendMethodStatement(nameof(AtLeast), doNotPopulateThisValue);
		return new QuantifiableResult<IThat<IEnumerable<TItem>>>(source, source.ExpectationBuilder,
			CollectionQuantifier.AtLeast(minimum));
	}
}
