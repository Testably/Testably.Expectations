using System.Text;

namespace Testably.Expectations.Core.Helpers;

internal static class StringBuilderHelpers
{
	public static void AppendMethod(this StringBuilder builder, string methodName)
	{
		builder.Append('.').Append(methodName).Append('(').Append(')');
	}

	public static void AppendMethod(this StringBuilder builder, string methodName, string param1)
	{
		builder.Append('.').Append(methodName).Append('(').Append(param1).Append(')');
	}
}
