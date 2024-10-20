using System;

namespace Testably.Expectations.Core.Helpers;

internal static class ExceptionHelpers
{
	public static string FormatForMessage(this Exception exception)
	{
		string message = exception.GetType().Name.PrependAOrAn();
		if (!string.IsNullOrEmpty(exception.Message))
		{
			message += ":" + Environment.NewLine + exception.Message.Indent();
		}

		return message;
	}
}
