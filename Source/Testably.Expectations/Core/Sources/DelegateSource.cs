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
