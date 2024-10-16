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

	#region IValueSource<object> Members

	public Task<SourceValue<object>> GetValue()
	{
		try
		{
			_action();
			return Task.FromResult<SourceValue<object>>(new SourceValue<object>(null, null));
		}
		catch (Exception ex)
		{
			return Task.FromResult<SourceValue<object>>(new SourceValue<object>(null, ex));
		}
	}

	#endregion
}

internal class DelegateAsyncSource : IValueSource<object>
{
	private readonly Func<Task> _action;

	public DelegateAsyncSource(Func<Task> action)
	{
		_action = action;
	}

	#region IValueSource<object> Members

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

	#endregion
}

internal class DelegateValueSource<TValue> : IValueSource<TValue>
{
	private readonly Func<TValue> _action;

	public DelegateValueSource(Func<TValue> action)
	{
		_action = action;
	}

	#region IValueSource<TValue> Members

	public Task<SourceValue<TValue>> GetValue()
	{
		try
		{
			TValue? value = _action();
			return Task.FromResult<SourceValue<TValue>>(new SourceValue<TValue>(value, null));
		}
		catch (Exception ex)
		{
			return Task.FromResult<SourceValue<TValue>>(new SourceValue<TValue>(default, ex));
		}
	}

	#endregion
}

internal class DelegateAsyncValueSource<TValue> : IValueSource<TValue>
{
	private readonly Func<Task<TValue>> _action;

	public DelegateAsyncValueSource(Func<Task<TValue>> action)
	{
		_action = action;
	}

	#region IValueSource<TValue> Members

	public async Task<SourceValue<TValue>> GetValue()
	{
		try
		{
			TValue? value = await _action();
			return new SourceValue<TValue>(value, null);
		}
		catch (Exception ex)
		{
			return new SourceValue<TValue>(default, ex);
		}
	}

	#endregion
}
