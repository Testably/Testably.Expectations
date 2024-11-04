using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Testably.Expectations.Core.Sources;

internal class DelegateAsyncSource(Func<CancellationToken, Task> action) : IValueSource<DelegateValue>
{
	#region IValueSource<DelegateValue> Members

	public async Task<DelegateValue?> GetValue(CancellationToken cancellationToken)
	{
		Stopwatch sw = new();
		try
		{
			sw.Start();
			await action(cancellationToken);
			sw.Stop();
			return new DelegateValue(null, sw.Elapsed);
		}
		catch (Exception ex)
		{
			return new DelegateValue(ex, sw.Elapsed);
		}
	}

	#endregion
}
