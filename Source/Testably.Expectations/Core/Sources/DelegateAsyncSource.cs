using System;
using System.Threading.Tasks;

namespace Testably.Expectations.Core.Sources;

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