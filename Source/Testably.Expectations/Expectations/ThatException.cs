using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;

namespace Testably.Expectations.Expectations;

public sealed partial class ThatException<TException>
	where TException : Exception
{
	private readonly IExpectationBuilder _expectationBuilder;

	internal ThatException(IExpectationBuilder expectationBuilder)
	{
		_expectationBuilder = expectationBuilder;
	}

	/// <summary>
	///     Expect the <typeparamref type="TException" /> has a message equal to <paramref name="expected" />
	/// </summary>
	public AssertionResult<TException, ThatException<TException>> HasMessage(
		string expected, [CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(_expectationBuilder.Add(
				new HasMessageExpectation<TException>(expected),
				b => b.AppendMethod(nameof(HasMessage), doNotPopulateThisValue)),
			this);
}
