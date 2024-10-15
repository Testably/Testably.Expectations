using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUnit.Assertions.Core;
using TUnit.Assertions.Core.Internal;

namespace TUnit.Assertions.Assertions.Delegates;
public class DelegateAssertionResult<TException> : AssertionResult<TException?>
where TException : Exception
{
	private readonly AssertionBuilder _assertionBuilder;

	/// <inheritdoc />
	internal DelegateAssertionResult(AssertionBuilder assertionBuilder, Func<Task<TException?>> value) : base(assertionBuilder, value)
	{
		_assertionBuilder = assertionBuilder;
	}

	public ExceptionAssertions Which => new ExceptionAssertions(_assertionBuilder, null);
}
