using System;
using System.Threading.Tasks;

namespace Testably.Expectations.Core.Sources;

internal class DelegateAsyncValueSource<TValue> : IValueSource<TValue>
{
	private readonly Func<Task<TValue>> _action;

	public DelegateAsyncValueSource(Func<Task<TValue>> action)
	{
		_action = action;
	}

	#region IValueSource<TValue> Members

	public async Task<SourceValue<TValue>> GetValue()
	{
		try
		{
			TValue? value = await _action();
			return new SourceValue<TValue>(value, null);
		}
		catch (Exception ex)
		{
			return new SourceValue<TValue>(default, ex);
		}
	}

	#endregion
}
