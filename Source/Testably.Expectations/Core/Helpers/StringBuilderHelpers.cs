using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testably.Expectations.Expectations.Strings;

namespace Testably.Expectations.CoreVoid.Helpers;
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
