using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;

namespace Testably.Expectations.Expectations.Strings;

internal class DoesNotThrow<TActual> : IDelegateExpectation<TActual>
{
	#region IDelegateExpectation<TActual> Members

	/// <inheritdoc />
	public ExpectationResult IsMetBy(SourceValue<TActual> value)
	{
		if (value.Exception is not null)
		{
			return new ExpectationResult.Failure<TActual?>(value.Value, ToString(),
				$"it did throw {Formatter.PrependAOrAn(value.Exception.GetType().Name)}:{Environment.NewLine}\t{value.Exception.Message}");
		}

		return new ExpectationResult.Success<TActual?>(value.Value, ToString());
	}

	#endregion

	/// <inheritdoc />
	public override string ToString()
		=> "does not throw";
}
