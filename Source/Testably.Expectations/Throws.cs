using System;
using Testably.Expectations.Common;

namespace Testably.Expectations;

public static class Throws
{
	public static Func<IConstraintBuilder<Action>, IConstraint<Exception?>> Exception => _ => _.Throws<Exception>();
	public static Func<IConstraintBuilder<Action>, IConstraint<TException?>> TypeOf<TException>()
		where TException : Exception
		=> _ => _.Throws<TException>();
}

