using System;

namespace Testably.Expectations.Core;

/// <summary>
///     A source for the expectations can be either a <see cref="Value" /> or an <see cref="Exception" />.
/// </summary>
public class SourceValue<TValue> : SourceValue
{
	public TValue? Value { get; }

	public SourceValue(in TValue? value, Exception? exception) : base(exception)
	{
		Value = value;
	}
}

public class SourceValue
{
	public Exception? Exception { get; }

	public SourceValue(Exception? exception)
	{
		Exception = exception;
	}
}
