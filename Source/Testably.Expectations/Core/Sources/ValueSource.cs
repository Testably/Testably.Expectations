using System.Threading;
using System.Threading.Tasks;

namespace Testably.Expectations.Core.Sources;

internal class ValueSource<TValue> : IValueSource<TValue>
{
	private readonly TValue? _value;

	public ValueSource(TValue? value)
	{
		_value = value;
	}

	#region IValueSource<TValue> Members

	public Task<TValue?> GetValue(CancellationToken cancellationToken)
	{
		return Task.FromResult(_value);
	}

	#endregion
}
