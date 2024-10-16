using System;
using Testably.Expectations.Core;

namespace Testably.Expectations.Expectations.Exceptions;
public class ExceptionAssertionResult<TException> : AssertionResult<TException>
	  where TException : Exception
{
	private readonly IExpectationBuilder _expectationBuilder;

	internal ExceptionAssertionResult(IExpectationBuilder expectationBuilder) : base(expectationBuilder)
	{
		_expectationBuilder = expectationBuilder;
	}

	public ExceptionExpectations<TException> Which
	{
		get
		{
			return new ExceptionExpectations<TException>(_expectationBuilder.And());
		}
	}
}
