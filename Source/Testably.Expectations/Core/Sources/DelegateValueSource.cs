using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Testably.Expectations.Core.Sources;

internal class DelegateValueSource<TValue>(Func<CancellationToken, TValue> action)
	: IValueSource<DelegateValue<TValue>>
{
	#region IValueSource<DelegateValue<TValue>> Members

	public Task<DelegateValue<TValue>?> GetValue(CancellationToken cancellationToken)
	{
		Stopwatch sw = new();
		try
		{
			sw.Start();
			TValue value = action(cancellationToken);
			sw.Stop();
			return Task.FromResult<DelegateValue<TValue>?>(new DelegateValue<TValue>(value, null, sw.Elapsed));
		}
		catch (Exception ex)
		{
			return Task.FromResult<DelegateValue<TValue>?>(new DelegateValue<TValue>(default, ex, sw.Elapsed));
		}
	}

	#endregion
}
