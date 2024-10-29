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
	public static ThatDelegateThrows<Exception> ThrowException(this ThatDelegate source)
	{
		ThrowsOption throwOptions = new();
		return new ThatDelegateThrows<Exception>(source.ExpectationBuilder
				.AddConstraint(new ThrowsCastConstraint<Exception>(throwOptions))
				.AppendMethodStatement(nameof(ThrowException)),
			throwOptions);
	}
}
