using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
// ReSharper disable once CheckNamespace

namespace Testably.Expectations;

/// <summary>
///     An intermediate type to collect the maximum of the range.
/// </summary>
public class BetweenResult<TTarget>(
	ExpectationBuilder expectationBuilder,
	Func<int, TTarget> callback)
{
	/// <summary>
	///     ... and <paramref name="maximum" />...
	/// </summary>
	/// <param name="maximum"></param>
	/// <param name="doNotPopulateThisValue"></param>
	/// <returns></returns>
	public TTarget And(int maximum,
		[CallerArgumentExpression("maximum")] string doNotPopulateThisValue = "")
	{
		expectationBuilder.AppendMethodStatement(nameof(And), doNotPopulateThisValue);
		return callback(maximum);
	}
}
