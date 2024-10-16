using System;
using System.Threading.Tasks;

namespace Testably.Expectations.Core.Sources;

internal class DelegateSource : IValueSource<object>
{
	private readonly Action _action;

	public DelegateSource(Action action)
	{
		_action = action;
	}
	public Task<SourceValue<object>> GetValue()
	{
		try
		{
			_action();
			return Task.FromResult<SourceValue<object>>(new(null, null));
		}
		catch (Exception ex)
		{
			return Task.FromResult<SourceValue<object>>(new(null, ex));
		}
	}
}


internal class DelegateValueSource<TValue> : IValueSource<TValue>
{
	private readonly Func<TValue> _action;

	public DelegateValueSource(Func<TValue> action)
	{
		_action = action;
	}
	public Task<SourceValue<TValue>> GetValue()
	{
		try
		{
			var value = _action();
			return Task.FromResult<SourceValue<TValue>>(new(value, null));
		}
		catch (Exception ex)
		{
			return Task.FromResult<SourceValue<TValue>>(new(default, ex));
		}
	}
}
