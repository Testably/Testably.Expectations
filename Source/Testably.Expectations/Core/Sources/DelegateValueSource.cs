using System;
using System.Threading.Tasks;

namespace Testably.Expectations.Core.Sources;

internal class DelegateValueSource<TValue> : IValueSource<TValue>
{
	private readonly Func<TValue> _action;

	public DelegateValueSource(Func<TValue> action)
	{
		_action = action;
	}

	#region IValueSource<TValue> Members

	public Task<SourceValue<TValue>> GetValue()
	{
		try
		{
			TValue? value = _action();
			return Task.FromResult(new SourceValue<TValue>(value, null));
		}
		catch (Exception ex)
		{
			return Task.FromResult(new SourceValue<TValue>(default, ex));
		}
	}

	#endregion
}
