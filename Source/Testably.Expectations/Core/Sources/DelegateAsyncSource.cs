using System;
using System.Threading.Tasks;

namespace Testably.Expectations.Core.Sources;

internal class DelegateAsyncSource(Func<Task> action) : IValueSource<DelegateValue>
{
	#region IValueSource<NoValue> Members

	public async Task<DelegateValue?> GetValue()
	{
		try
		{
			await action();
			return new DelegateValue(null);
		}
		catch (Exception ex)
		{
			return new DelegateValue(ex);
		}
	}

	#endregion
}
