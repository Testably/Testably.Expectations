using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Options;
using Testably.Expectations.Results;

namespace Testably.Expectations.That.Delegates;

public partial class ThatDelegateThrows<TException>
{
	/// <summary>
	///     Verifies, that the exception was thrown only if the <paramref name="predicate" /> is <see langword="true" />,
	///     otherwise it verifies, that no exception was thrown.
	/// </summary>
	public ThatDelegateThrows<TException?> OnlyIf(bool predicate,
		[CallerArgumentExpression("predicate")]
		string doNotPopulateThisValue = "")
	{
		_throwOptions.CheckThrow(predicate);
		ExpectationBuilder.AppendExpression(b
			=> b.AppendMethod(nameof(OnlyIf), doNotPopulateThisValue));
		return new ThatDelegateThrows<TException?>(ExpectationBuilder, _throwOptions);
	}
}
