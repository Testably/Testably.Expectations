using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;

namespace Testably.Expectations.Results;

/// <summary>
///     An <see cref="ExpectationResult" /> when an exception was thrown.
/// </summary>
public class
	DelegateExpectationResult<TException> : ExpectationResult<TException,
	DelegateExpectationResult<TException>>
	where TException : Exception?
{
	/// <summary>
	///     Additional expectations on the thrown <typeparamref name="TException" />.
	/// </summary>
	public That<TException> Which
		=> new(_expectationBuilder.Which<TException, TException>(
			PropertyAccessor<TException?, TException?>.FromFunc(p => p.Value, ""),
			null,
			b => b.Append(".").Append(nameof(Which)),
			whichTextSeparator: ""));

	private readonly IExpectationBuilder _expectationBuilder;
	private readonly ThatDelegate.ThrowsOption _throwOptions;

	internal DelegateExpectationResult(IExpectationBuilder expectationBuilder,
		ThatDelegate.ThrowsOption throwOptions)
		: base(expectationBuilder)
	{
		_expectationBuilder = expectationBuilder;
		_throwOptions = throwOptions;
	}

	/// <summary>
	///     Verifies, that the exception was thrown only if the <paramref name="predicate" /> is <see langword="true" />,
	///     otherwise it verifies, that no exception was thrown.
	/// </summary>
	public DelegateExpectationResult<TException?> OnlyIf(bool predicate,
		[CallerArgumentExpression("predicate")]
		string doNotPopulateThisValue = "")
	{
		_throwOptions.CheckThrow(predicate);
		_expectationBuilder.AppendExpression(b
			=> b.AppendMethod(nameof(OnlyIf), doNotPopulateThisValue));
		return new DelegateExpectationResult<TException?>(_expectationBuilder, _throwOptions);
	}
}
