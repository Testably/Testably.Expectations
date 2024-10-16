using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testably.Expectations.Core.Sources;
internal class ValueSource<TValue> : IValueSource<TValue>
{
	private readonly TValue? _value;

	public ValueSource(TValue? value)
	{
		_value = value;
	}

	public Task<(TValue?, Exception?)> GetValue() => Task.FromResult((_value, (Exception?)null));
}
