using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Testably.Expectations.Core.Sources;

internal class DelegateSource(Action<CancellationToken> action) : IValueSource<DelegateValue>
{
	#region IValueSource<DelegateValue> Members

	public Task<DelegateValue?> GetValue(CancellationToken cancellationToken)
	{
		Stopwatch sw = new();
		try
		{
			sw.Start();
			action(cancellationToken);
			sw.Stop();
			return Task.FromResult<DelegateValue?>(
				new DelegateValue(null, sw.Elapsed));
		}
		catch (Exception ex)
		{
			return Task.FromResult<DelegateValue?>(
				new DelegateValue(ex, sw.Elapsed));
		}
	}

	#endregion
}
