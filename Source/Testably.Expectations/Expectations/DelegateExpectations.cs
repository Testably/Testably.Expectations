using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Expectations.Exceptions;

namespace Testably.Expectations.Expectations;

public abstract partial class DelegateExpectations
{
	private readonly IExpectationBuilder _expectationBuilder;

	internal DelegateExpectations(IExpectationBuilder expectationBuilder)
	{
		_expectationBuilder = expectationBuilder;
	}

	/// <summary>
	///     Verifies that the delegate throws an exception of type <typeparamref name="TException" />.
	/// </summary>
	public ExceptionAssertionResult<TException> Throws<TException>()
		where TException : Exception
		=> new(_expectationBuilder.Add(
			new ThrowsExpectation<TException>(),
			b => b.AppendMethod(nameof(ThrowsException))));

	/// <summary>
	///     Verifies that the delegate throws exactly an exception of type <typeparamref name="TException" />.
	/// </summary>
	public ExceptionAssertionResult<TException> ThrowsExactly<TException>()
		where TException : Exception
		=> new(_expectationBuilder.Add(
			new ThrowsExactlyExpectation<TException>(),
			b => b.AppendMethod(nameof(ThrowsException))));

	/// <summary>
	///     Verifies that the delegate throws an exception.
	/// </summary>
	public ExceptionAssertionResult<Exception> ThrowsException()
		=> new(_expectationBuilder.Add(
			new ThrowsExpectation<Exception>(),
			b => b.AppendMethod(nameof(ThrowsException))));
}
