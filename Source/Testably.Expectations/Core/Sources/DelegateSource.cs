using System;
using System.Threading.Tasks;

namespace Testably.Expectations.Core.Sources;

internal class DelegateSource : IValueSource<DelegateSource.WithoutValue>
{
	private readonly Action _action;

	public DelegateSource(Action action)
	{
		_action = action;
	}

	public Task<SourceValue<WithoutValue>> GetValue()
	{
		try
		{
			_action();
			return Task.FromResult(new SourceValue<WithoutValue>(WithoutValue.Instance, null));
		}
		catch (Exception ex)
		{
			return Task.FromResult(new SourceValue<WithoutValue>(WithoutValue.Instance, ex));
		}
	}

	internal struct WithoutValue
	{
		internal static WithoutValue Instance { get; } = new();
	}
}
