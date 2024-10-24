using System;
using System.Threading.Tasks;
using Testably.Expectations.Core.Helpers;

namespace Testably.Expectations.Core.Sources;

internal class ValueSource<TValue> : IValueSource<TValue>
{
	private readonly TValue? _value;
	private Func<TValue?, TValue?>? _wrapper;

	public ValueSource(TValue? value)
	{
		_value = value;
	}

	#region IValueSource<TValue> Members

	public Task<SourceValue<TValue>> GetValue()
	{
		var value = _value;
		if (_wrapper is not null)
		{
			value = _wrapper.Invoke(value);
		}
		return Task.FromResult(new SourceValue<TValue>(value, null));
	}

	#endregion

	internal void AddWrapper(Func<TValue?, TValue?> wrapper)
	{
		_wrapper = wrapper;
	}
}
