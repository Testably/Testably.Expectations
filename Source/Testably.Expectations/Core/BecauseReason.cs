using System;

namespace Testably.Expectations.Core;

internal struct BecauseReason(string reason)
{
	private string? _message;

	private string CreateMessage()
	{
		const string prefix = "because";
		string message = reason.Trim();

		return !message.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)
			? $", {prefix} {message}"
			: $", {message}";
	}

	public override string ToString()
	{
		_message ??= CreateMessage();
		return _message;
	}

	public ConstraintResult ApplyTo(ConstraintResult result)
	{
		var message = CreateMessage();
		return result.UpdateExpectationText(e => e.ExpectationText + message);
	}
}
