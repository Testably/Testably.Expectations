using System;
using System.Threading.Tasks;

namespace Testably.Expectations.Core.Sources;

internal class DelegateSource : IValueSource<DelegateSource.NoValue>
{
	private readonly Action _action;

	public DelegateSource(Action action)
	{
		_action = action;
	}

	public Task<SourceValue<NoValue>> GetValue()
	{
		try
		{
			_action();
			return Task.FromResult(new SourceValue<NoValue>(NoValue.Instance, null));
		}
		catch (Exception ex)
		{
			return Task.FromResult(new SourceValue<NoValue>(NoValue.Instance, ex));
		}
	}

	internal struct NoValue
	{
		internal static NoValue Instance { get; } = new();
	}
}
