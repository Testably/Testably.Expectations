﻿using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Core.Sources;
using Testably.Expectations.Results;
using Testably.Expectations.That.Delegates;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatDelegateShould
{

	/// <summary>
	///     Verifies that the delegate throws exactly an exception of type <typeparamref name="TException" />.
	/// </summary>
	public static DelegateExpectationResult<TException> ThrowExactly<TException>(this ThatDelegate source)
		where TException : Exception
	{
		ThrowsOption throwOptions = new();
		return new(source.ExpectationBuilder.AddCast(
				new ThrowsExactlyConstraint<TException>(throwOptions),
				b => b.Append('.').Append(nameof(ThrowExactly)).Append('<')
					.Append(typeof(TException).Name).Append(">()")),
			throwOptions);
	}
	
	private readonly struct ThrowsExactlyConstraint<TException>(ThrowsOption throwOptions) :
		IConstraint<DelegateSource.NoValue, TException>,
		IDelegateConstraint<DelegateSource.NoValue>
		where TException : Exception
	{
		/// <inheritdoc />
		public ConstraintResult IsMetBy(DelegateSource.NoValue actual, Exception? exception)
		{
			if (!throwOptions.DoCheckThrow)
			{
				return DoesNotThrowResult<Exception>(exception);
			}

			if (exception is TException typedException && exception.GetType() == typeof(TException))
			{
				return new ConstraintResult.Success<TException?>(typedException, ToString());
			}

			if (exception is null)
			{
				return new ConstraintResult.Failure<TException?>(null, ToString(), "it did not");
			}

			return new ConstraintResult.Failure<TException?>(null, ToString(),
				$"it did throw {exception.FormatForMessage()}");
		}

		/// <inheritdoc />
		public ConstraintResult IsMetBy(SourceValue<DelegateSource.NoValue> value)
			=> IsMetBy(value.Value, value.Exception);

		/// <inheritdoc />
		public override string ToString()
		{
			if (!throwOptions.DoCheckThrow)
			{
				return DoesNotThrowExpectation;
			}

			return $"throw exactly {typeof(TException).Name.PrependAOrAn()}";
		}
	}
}