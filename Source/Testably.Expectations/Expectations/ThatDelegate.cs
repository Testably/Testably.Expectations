using System;
using System.Linq;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Core.Sources;

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
		=> new(_expectationBuilder.AddCast(
			new ThrowsExpectation<TException>(),
			b => b.Append('.').Append(nameof(Throws)).Append('<').Append(typeof(TException).Name).Append(">()")));

	/// <summary>
	///     Verifies that the delegate throws exactly an exception of type <typeparamref name="TException" />.
	/// </summary>
	public ThrowsExceptionResult<TException> ThrowsExactly<TException>()
		where TException : Exception
		=> new(_expectationBuilder.AddCast(
			new ThrowsExactlyExpectation<TException>(),
			b => b.Append('.').Append(nameof(ThrowsExactly)).Append('<').Append(typeof(TException).Name).Append(">()")));

	/// <summary>
	///     Verifies that the delegate throws an exception.
	/// </summary>
	public ThrowsExceptionResult<Exception> ThrowsException()
		=> new(_expectationBuilder.AddCast(
			new ThrowsExpectation<Exception>(),
			b => b.AppendMethod(nameof(ThrowsException))));
}
