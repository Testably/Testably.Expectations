using System;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Core.Sources;

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
				.AddConstraint(new ThrowsExactlyCastConstraint<TException>(throwOptions)),
			throwOptions);
	}

	/// <summary>
	///     Verifies that the delegate throws exactly an exception of type <paramref name="exceptionType" />.
	/// </summary>
	public static ThatDelegateThrows<Exception> ThrowExactly(this ThatDelegate source,
		Type exceptionType)
	{
		ThrowsOption throwOptions = new();
		return new ThatDelegateThrows<Exception>(source.ExpectationBuilder
				.AddConstraint(new ThrowsExactlyCastConstraint(exceptionType, throwOptions)),
			throwOptions);
	}

	private readonly struct ThrowsExactlyCastConstraint<TException>(ThrowsOption throwOptions)
		: ICastConstraint<DelegateValue, Exception?>
		where TException : Exception
	{
		public ConstraintResult IsMetBy(DelegateValue? value)
		{
			Exception? exception = value?.Exception;
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
		public override string ToString()
		{
			if (!throwOptions.DoCheckThrow)
			{
				return DoesNotThrowExpectation;
			}

			return $"throw exactly {typeof(TException).Name.PrependAOrAn()}";
		}
	}

	private readonly struct ThrowsExactlyCastConstraint(
		Type exceptionType,
		ThrowsOption throwOptions)
		: ICastConstraint<DelegateValue, Exception?>
	{
		/// <inheritdoc />
		public ConstraintResult IsMetBy(DelegateValue? value)
		{
			Exception? exception = value?.Exception;
			if (!throwOptions.DoCheckThrow)
			{
				return DoesNotThrowResult<Exception>(exception);
			}

			if (exception?.GetType() == exceptionType)
			{
				return new ConstraintResult.Success<Exception?>(exception, ToString());
			}

			if (exception is null)
			{
				return new ConstraintResult.Failure<Exception?>(null, ToString(), "it did not");
			}

			return new ConstraintResult.Failure<Exception?>(null, ToString(),
				$"it did throw {exception.FormatForMessage()}");
		}

		/// <inheritdoc />
		public override string ToString()
		{
			if (!throwOptions.DoCheckThrow)
			{
				return DoesNotThrowExpectation;
			}

			return $"throw exactly {exceptionType.Name.PrependAOrAn()}";
		}
	}
}
