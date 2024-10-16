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
	public Task<(object?, Exception?)> GetValue()
	{
		try
		{
			_action();
			return Task.FromResult<(object?, Exception?)>((null, null));
		}
		catch (Exception ex)
		{
			return Task.FromResult<(object?, Exception?)>((null, ex));
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
	public Task<(TValue?, Exception?)> GetValue()
	{
		try
		{
			var value = _action();
			return Task.FromResult<(TValue?, Exception?)>((value, null));
		}
		catch (Exception ex)
		{
			return Task.FromResult<(TValue?, Exception?)>((default, ex));
		}
	}
}
