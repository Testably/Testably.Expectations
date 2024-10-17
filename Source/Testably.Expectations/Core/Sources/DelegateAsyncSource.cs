using System;
using System.Threading.Tasks;

namespace Testably.Expectations.Core.Sources;

internal class DelegateAsyncSource : IValueSource<DelegateSource.WithoutValue>
{
	private readonly Func<Task> _action;

	public DelegateAsyncSource(Func<Task> action)
	{
		_action = action;
	}

	public async Task<SourceValue<DelegateSource.WithoutValue>> GetValue()
	{
		try
		{
			await _action();
			return new SourceValue<DelegateSource.WithoutValue>(DelegateSource.WithoutValue.Instance, null);
		}
		catch (Exception ex)
		{
			return new SourceValue<DelegateSource.WithoutValue>(DelegateSource.WithoutValue.Instance, ex);
		}
	}
}
