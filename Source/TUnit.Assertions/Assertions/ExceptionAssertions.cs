using System;
using System.Threading.Tasks;
using TUnit.Assertions.Core;
using TUnit.Assertions.Core.Internal;

namespace TUnit.Assertions.Assertions;
public class ExceptionAssertions<TException> where TException : Exception
{
	private readonly AssertionBuilder _assertionBuilder;
	private readonly TException? _value;

	internal ExceptionAssertions(AssertionBuilder assertionBuilder, TException? value)
	{
		_assertionBuilder = assertionBuilder;
		_value = value;
	}
	public AssertionResult<TException?, ExceptionAssertions<TException>> HasMessage(string expected)
	{
		return new AssertionResult<TException?, ExceptionAssertions<TException>>(_assertionBuilder, () => Task.FromResult(_value), this);
	}
	public AssertionResult<TException?, ExceptionAssertions<TException>> HasInnerException(Action<ExceptionAssertions<Exception>> assertions)
	{
		return new AssertionResult<TException?, ExceptionAssertions<TException>>(_assertionBuilder, () => Task.FromResult(_value), this);
	}
}
