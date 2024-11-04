using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Testably.Expectations.Core.Sources;

internal class DelegateAsyncSource(Func<Task> action) : IValueSource<DelegateValue>
{
	#region IValueSource<DelegateValue> Members

	public async Task<DelegateValue?> GetValue()
	{
		Stopwatch sw = new();
		try
		{
			sw.Start();
			await action();
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
