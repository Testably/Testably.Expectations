using System;
using Testably.Expectations.Core;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatDelegateShould
{
	/// <summary>
	///     Verifies that the delegate throws an exception of type <typeparamref name="TException" />.
	/// </summary>
	public static ThatDelegateThrows<TException> Throw<TException>(this ThatDelegate source)
		where TException : Exception
	{
		ThrowsOption throwOptions = new();
		return new ThatDelegateThrows<TException>(source.ExpectationBuilder
				.AddConstraint(new ThrowsCastConstraint<TException>(throwOptions))
				.AppendGenericMethodStatement<TException>(nameof(Throw)),
			throwOptions);
	}
}
