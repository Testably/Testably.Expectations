using System;
using System.Threading.Tasks;

namespace Testably.Expectations.Core.Sources;

internal class DelegateValueSource<TValue> : IValueSource<DelegateValue<TValue>>
{
	private readonly Func<TValue> _action;

	public DelegateValueSource(Func<TValue> action)
	{
		_action = action;
	}

	#region IValueSource<TValue> Members

	public Task<DelegateValue<TValue>?> GetValue()
	{
		try
		{
			TValue? value = _action();
			return Task.FromResult<DelegateValue<TValue>?>(new DelegateValue<TValue>(value, null));
		}
		catch (Exception ex)
		{
			return Task.FromResult<DelegateValue<TValue>?>(new DelegateValue<TValue>(default, ex));
		}
	}

	#endregion
}
