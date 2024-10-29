using System;

namespace Testably.Expectations.Core;

/// <summary>
///     A source for the expectations can be either a <see cref="Value" /> or an <see cref="Exception" />.
/// </summary>
public class DelegateValue<TValue> : DelegateValue
{
	public TValue? Value { get; }

	public DelegateValue(in TValue? value, Exception? exception) : base(exception)
	{
		Value = value;
	}
}

public class DelegateValue
{
	public Exception? Exception { get; }

	public DelegateValue(Exception? exception)
	{
		Exception = exception;
	}
}
