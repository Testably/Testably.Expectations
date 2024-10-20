using System;

namespace Testably.Expectations.Core.Results;

/// <summary>
///     An <see cref="ExpectationResult" /> when an exception was thrown.
/// </summary>
/// <typeparam name="TException"></typeparam>
public class
	DelegateExpectationResult<TException> : ExpectationResult<TException,
	DelegateExpectationResult<TException>>
	where TException : Exception
{
	/// <summary>
	///     Additional expectations on the thrown <typeparamref name="TException" />.
	/// </summary>
	public That<TException?> Which
		=> new(_expectationBuilder.Which<TException?, TException?>(
			PropertyAccessor<TException?, TException?>.FromFunc(p => p.Value, ""),
			null,
			b => b.Append(".").Append(nameof(Which)),
			whichTextSeparator: ""));

	private readonly IExpectationBuilder _expectationBuilder;

	internal DelegateExpectationResult(IExpectationBuilder expectationBuilder) : base(
		expectationBuilder)
	{
		_expectationBuilder = expectationBuilder;
	}
}
