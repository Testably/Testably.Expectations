using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Core.Sources;
using Testably.Expectations;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatDelegateShould
{
	/// <summary>
	///     Verifies that the delegate throws exactly an exception of type <typeparamref name="TException" />.
	/// </summary>
	public static ThatDelegateThrows<TException> ThrowExactly<TException>(this ThatDelegate source)
		where TException : Exception
	{
		ThrowsOption throwOptions = new();
		return new ThatDelegateThrows<TException>(source.ExpectationBuilder
				.AddConstraint(new ThrowsExactlyCastConstraint<TException>(throwOptions))
				.AppendGenericMethodStatement<TException>(nameof(ThrowExactly)),
			throwOptions);
	}

	private readonly struct ThrowsExactlyCastConstraint<TException>(ThrowsOption throwOptions)
		: ICastConstraint<DelegateValue, Exception?>
		where TException : Exception
	{
		/// <inheritdoc />
		public ConstraintResult IsMetBy(Exception? exception)
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
		public ConstraintResult IsMetBy(DelegateValue? value)
			=> IsMetBy(value?.Exception);

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
