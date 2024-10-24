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
	///     Verifies that the delegate throws an exception of type <typeparamref name="TException" />.
	/// </summary>
	public static DelegateExpectationResult<TException> Throw<TException>(this ThatDelegate source)
		where TException : Exception
	{
		ThrowsOption throwOptions = new();
		return new DelegateExpectationResult<TException>(source.ExpectationBuilder.AddCast(
				new ThrowsConstraint<TException>(throwOptions),
				b => b.Append('.').Append(nameof(Throw)).Append('<')
					.Append(typeof(TException).Name)
					.Append(">()")),
			throwOptions);
	}
}
