using System;
using System.Threading.Tasks;

namespace Testably.Expectations.Core.Sources;

internal class DelegateSource : IValueSource<DelegateValue<DelegateSource.NoValue>>
{
	private readonly Action _action;

	public DelegateSource(Action action)
	{
		_action = action;
	}

	#region IValueSource<NoValue> Members

	public Task<DelegateValue<NoValue>?> GetValue()
	{
		try
		{
			_action();
			return Task.FromResult<DelegateValue<NoValue>?>(
				new DelegateValue<NoValue>(NoValue.Instance, null));
		}
		catch (Exception ex)
		{
			return Task.FromResult<DelegateValue<NoValue>?>(
				new DelegateValue<NoValue>(NoValue.Instance, ex));
		}
	}

	#endregion

	internal struct NoValue
	{
		internal static NoValue Instance { get; } = new();
	}
}
