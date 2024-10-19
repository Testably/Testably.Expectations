using System;
using System.Threading.Tasks;

namespace Testably.Expectations.Core.Sources;

internal class DelegateAsyncSource : IValueSource<DelegateSource.NoValue>
{
	private readonly Func<Task> _action;

	public DelegateAsyncSource(Func<Task> action)
	{
		_action = action;
	}

	public async Task<SourceValue<DelegateSource.NoValue>> GetValue()
	{
		try
		{
			await _action();
			return new SourceValue<DelegateSource.NoValue>(DelegateSource.NoValue.Instance, null);
		}
		catch (Exception ex)
		{
			return new SourceValue<DelegateSource.NoValue>(DelegateSource.NoValue.Instance, ex);
		}
	}
}
