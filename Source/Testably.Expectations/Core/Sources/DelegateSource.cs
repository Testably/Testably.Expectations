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


internal class DelegateAsyncSource : IValueSource<object>
{
	private readonly Func<Task> _action;

	public DelegateAsyncSource(Func<Task> action)
	{
		_action = action;
	}
	public async Task<SourceValue<object>> GetValue()
	{
		try
		{
			await _action();
			return new SourceValue<object>(null, null);
		}
		catch (Exception ex)
		{
			return new SourceValue<object>(null, ex);
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


internal class DelegateAsyncValueSource<TValue> : IValueSource<TValue>
{
	private readonly Func<Task<TValue>> _action;

	public DelegateAsyncValueSource(Func<Task<TValue>> action)
	{
		_action = action;
	}
	public async Task<SourceValue<TValue>> GetValue()
	{
		try
		{
			var value = await _action();
			return new SourceValue<TValue>(value, null);
		}
		catch (Exception ex)
		{
			return new SourceValue<TValue>(default, ex);
		}
	}
}
