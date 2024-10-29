using System;
using System.Threading.Tasks;

namespace Testably.Expectations.Core.Sources;

internal class DelegateSource(Action action) : IValueSource<DelegateValue>
{
	#region IValueSource<DelegateValue> Members

	public Task<DelegateValue?> GetValue()
	{
		try
		{
			action();
			return Task.FromResult<DelegateValue?>(
				new DelegateValue(null));
		}
		catch (Exception ex)
		{
			return Task.FromResult<DelegateValue?>(
				new DelegateValue(ex));
		}
	}

	#endregion
}
