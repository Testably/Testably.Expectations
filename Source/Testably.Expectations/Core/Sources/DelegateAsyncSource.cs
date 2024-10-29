using System;
using System.Threading.Tasks;

namespace Testably.Expectations.Core.Sources;

internal class DelegateAsyncSource : IValueSource<DelegateValue<DelegateSource.NoValue>>
{
	private readonly Func<Task> _action;

	public DelegateAsyncSource(Func<Task> action)
	{
		_action = action;
	}

	#region IValueSource<NoValue> Members

	public async Task<DelegateValue<DelegateSource.NoValue>?> GetValue()
	{
		try
		{
			await _action();
			return new DelegateValue<DelegateSource.NoValue>(DelegateSource.NoValue.Instance, null);
		}
		catch (Exception ex)
		{
			return new DelegateValue<DelegateSource.NoValue>(DelegateSource.NoValue.Instance, ex);
		}
	}

	#endregion
}
