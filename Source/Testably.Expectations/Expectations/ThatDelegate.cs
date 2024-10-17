using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;

namespace Testably.Expectations.Expectations;

public abstract partial class ThatDelegate
{
	private readonly IExpectationBuilder _expectationBuilder;

	internal ThatDelegate(IExpectationBuilder expectationBuilder)
	{
		_expectationBuilder = expectationBuilder;
	}

	/// <summary>
	///     Verifies that the delegate throws an exception of type <typeparamref name="TException" />.
	/// </summary>
	public ThrowsExceptionResult<TException> Throws<TException>()
		where TException : Exception
		=> new(_expectationBuilder.Add(
			new ThrowsExpectation<TException>(),
			b => b.AppendMethod(nameof(ThrowsException))));

	/// <summary>
	///     Verifies that the delegate throws exactly an exception of type <typeparamref name="TException" />.
	/// </summary>
	public ThrowsExceptionResult<TException> ThrowsExactly<TException>()
		where TException : Exception
		=> new(_expectationBuilder.Add(
			new ThrowsExactlyExpectation<TException>(),
			b => b.AppendMethod(nameof(ThrowsException))));

	/// <summary>
	///     Verifies that the delegate throws an exception.
	/// </summary>
	public ThrowsExceptionResult<Exception> ThrowsException()
		=> new(_expectationBuilder.Add(
			new ThrowsExpectation<Exception>(),
			b => b.AppendMethod(nameof(ThrowsException))));
}
