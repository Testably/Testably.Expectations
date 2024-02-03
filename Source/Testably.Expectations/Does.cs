using System;

using Testably.Expectations.Common;

namespace Testably.Expectations;

public static class Does
{
	public static Func<IConstraint<string?>, IConstraint<string?>> StartWith(string expected) => _ => _.StartsWith(expected);
	//public static Func<IConstraint<Action>, IConstraint<TException?>> Throw<TException>(string expected)
	//	where TException : Exception
	//	=> _ => _.Throws<TException>();
}

