using System;
using System.Runtime.CompilerServices;
using System.Text;
using Testably.Expectations.Core.Helpers;

namespace Testably.Expectations.Results;

/// <summary>
///     An intermediate type to collect the maximum of the range.
/// </summary>
public class BetweenResult<TTarget>(Func<int, TTarget> callback, Action<Action<StringBuilder>> expressionBuilderCallback)
{
	/// <summary>
	///     ... and <paramref name="maximum" /> items...
	/// </summary>
	/// <param name="maximum"></param>
	/// <param name="doNotPopulateThisValue"></param>
	/// <returns></returns>
	public TTarget And(int maximum,
		[CallerArgumentExpression("maximum")] string doNotPopulateThisValue = "")
	{
		expressionBuilderCallback.Invoke(b => b.AppendMethod(nameof(And), doNotPopulateThisValue));
		return callback(maximum);
	}
}
