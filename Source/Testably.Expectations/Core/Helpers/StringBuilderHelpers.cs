using System.Text;

namespace Testably.Expectations.Core.Helpers;

internal static class StringBuilderHelpers
{
	public static StringBuilder AppendMethod(this StringBuilder builder, string methodName)
	{
		return builder.Append('.').Append(methodName).Append('(').Append(')');
	}

	public static StringBuilder  AppendMethod(this StringBuilder builder, string methodName, string param1)
	{
		return builder.Append('.').Append(methodName).Append('(').Append(param1).Append(')');
	}
}
