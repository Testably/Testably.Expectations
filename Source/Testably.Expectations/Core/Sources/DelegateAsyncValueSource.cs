using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Testably.Expectations.Core.Sources;

internal class DelegateAsyncValueSource<TValue> : IValueSource<DelegateValue<TValue>>
{
	private readonly Func<Task<TValue>> _action;

	public DelegateAsyncValueSource(Func<Task<TValue>> action)
	{
		_action = action;
	}

	#region IValueSource<DelegateValue<TValue>> Members

	public async Task<DelegateValue<TValue>?> GetValue()
	{
		Stopwatch sw = new();
		try
		{
			sw.Start();
			TValue? value = await _action();
			sw.Stop();
			return new DelegateValue<TValue>(value, null, sw.Elapsed);
		}
		catch (Exception ex)
		{
			return new DelegateValue<TValue>(default, ex, sw.Elapsed);
		}
	}

	#endregion
}
