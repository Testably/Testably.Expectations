using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Testably.Expectations.Core.Sources;

internal class DelegateAsyncValueSource<TValue>(Func<CancellationToken, Task<TValue>> action)
	: IValueSource<DelegateValue<TValue>>
{
	#region IValueSource<DelegateValue<TValue>> Members

	public async Task<DelegateValue<TValue>?> GetValue(CancellationToken cancellationToken)
	{
		Stopwatch sw = new();
		try
		{
			sw.Start();
			TValue value = await action(cancellationToken);
			sw.Stop();
			return new DelegateValue<TValue>(value, null, sw.Elapsed);
		}
		catch (Exception ex)
		{
			return new DelegateValue<TValue>(default, ex, sw.Elapsed);
		}
	}

	#endregion
}
