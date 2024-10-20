using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Core.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="string" /> collections.
/// </summary>
public static partial class ThatStringCollectionExtensions
{
	/// <summary>
	///     Verifies that the actual collection contains the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrExpectationResult<IEnumerable<string>, That<IEnumerable<string>>> Contains(
		this That<IEnumerable<string>> source,
		string expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(new ContainsConstraint(expected),
				b => b.AppendMethod(nameof(Contains), doNotPopulateThisValue)),
			source);
}
