using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Testably.Expectations.Core.Sources;

internal class DelegateValueSource<TValue> : IValueSource<DelegateValue<TValue>>
{
	private readonly Func<TValue> _action;

	public DelegateValueSource(Func<TValue> action)
	{
		_action = action;
	}

	#region IValueSource<DelegateValue<TValue>> Members

	public Task<DelegateValue<TValue>?> GetValue()
	{
		Stopwatch sw = new();
		try
		{
			sw.Start();
			TValue value = _action();
			sw.Stop();
			return Task.FromResult<DelegateValue<TValue>?>(new DelegateValue<TValue>(value, null, sw.Elapsed));
		}
		catch (Exception ex)
		{
			return Task.FromResult<DelegateValue<TValue>?>(new DelegateValue<TValue>(default, ex, sw.Elapsed));
		}
	}

	#endregion
}
