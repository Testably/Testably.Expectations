using System.Collections.Generic;
using System.Linq;
using System.Text;
using TUnit.Assertions.Core;
using TUnit.Assertions.Core.Internal;

namespace TUnit.Assertions.Assertions.Strings;
public class StringAssertions
{
	private readonly AssertionBuilder _assertionBuilder;
	private readonly string? _value;

	internal StringAssertions(AssertionBuilder assertionBuilder, string? value)
	{
		_assertionBuilder = assertionBuilder;
		_value = value;
	}
	public AssertionResult<string?, StringAssertions> Is(string? expected)
	{
		return new AssertionResult<string?, StringAssertions>(_assertionBuilder, _value, this);
	}
}
