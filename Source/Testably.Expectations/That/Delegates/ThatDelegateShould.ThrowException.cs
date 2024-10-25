using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Results;
using Testably.Expectations.That.Delegates;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatDelegateShould
{
	/// <summary>
	///     Verifies that the delegate throws an exception.
	/// </summary>
	public static DelegateExpectationResult<Exception> ThrowException(this ThatDelegate source)
	{
		ThrowsOption throwOptions = new();
		return new(source.ExpectationBuilder.AddCast(
			new ThrowsConstraint<Exception>(throwOptions),
			b => b.AppendMethod(nameof(ThrowException))),
			throwOptions);
	}
}
