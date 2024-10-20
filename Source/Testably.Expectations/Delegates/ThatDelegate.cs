using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Core.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on delegate values.
/// </summary>
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
	public DelegateExpectationResult<TException> Throws<TException>()
		where TException : Exception
	{
		ThrowsOption throwOptions = new();
		return new DelegateExpectationResult<TException>(_expectationBuilder.AddCast(
				new ThrowsConstraint<TException>(throwOptions),
				b => b.Append('.').Append(nameof(Throws)).Append('<')
					.Append(typeof(TException).Name)
					.Append(">()")),
			throwOptions);
	}

	/// <summary>
	///     Verifies that the delegate throws exactly an exception of type <typeparamref name="TException" />.
	/// </summary>
	public DelegateExpectationResult<TException> ThrowsExactly<TException>()
		where TException : Exception
	{
		ThrowsOption throwOptions = new();
		return new(_expectationBuilder.AddCast(
			new ThrowsExactlyConstraint<TException>(throwOptions),
			b => b.Append('.').Append(nameof(ThrowsExactly)).Append('<')
				.Append(typeof(TException).Name).Append(">()")),
			throwOptions);
	}

	/// <summary>
	///     Verifies that the delegate throws an exception.
	/// </summary>
	public DelegateExpectationResult<Exception> ThrowsException()
	{
		ThrowsOption throwOptions = new();
		return new(_expectationBuilder.AddCast(
			new ThrowsConstraint<Exception>(throwOptions),
			b => b.AppendMethod(nameof(ThrowsException))),
			throwOptions);
	}

	internal class ThrowsOption
	{
		public bool DoCheckThrow { get; private set; } = true;

		public void CheckThrow(bool doCheckThrow)
		{
			DoCheckThrow = doCheckThrow;
		}
	}
}
