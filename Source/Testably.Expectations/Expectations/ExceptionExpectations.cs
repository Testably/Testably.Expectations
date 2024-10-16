using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.CoreVoid.Helpers;
using Testably.Expectations.Expectations.Exceptions;

namespace Testably.Expectations.Expectations;

public class ExceptionExpectations<TException>
	  where TException : Exception
{
	private readonly IExpectationBuilder _expectationBuilder;

	internal ExceptionExpectations(IExpectationBuilder expectationBuilder)
	{
		_expectationBuilder = expectationBuilder;
	}

	/// <summary>
	///     Expect the <typeparamref="TException" /> has a message equal to <paramref name="expected"/>
	/// </summary>
	public AssertionResult<TException, ExceptionExpectations<TException>> HasMessage(string expected, [CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(_expectationBuilder.Add(
			new HasMessage<TException>(expected),
			b => b.AppendMethod(nameof(HasMessage), doNotPopulateThisValue)),
			this);
}
