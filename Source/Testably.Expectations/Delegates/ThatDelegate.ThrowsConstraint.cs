using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Core.Sources;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public abstract partial class ThatDelegate
{
	private readonly struct ThrowsConstraint<TException> :
		IExpectation<DelegateSource.NoValue, TException>,
		IDelegateExpectation<DelegateSource.NoValue>
		where TException : Exception
	{
		/// <inheritdoc />
		public ConstraintResult IsMetBy(DelegateSource.NoValue actual, Exception? exception)
		{
			if (exception is TException typedException)
			{
				return new ConstraintResult.Success<TException?>(typedException, ToString());
			}

			if (exception is null)
			{
				return new ConstraintResult.Failure<TException?>(null, ToString(), "it did not");
			}

			return new ConstraintResult.Failure<TException?>(null, ToString(),
				$"it did throw {exception.GetType().Name.PrependAOrAn()}:{Environment.NewLine}\t{exception.Message}");
		}

		/// <inheritdoc />
		public ConstraintResult IsMetBy(SourceValue<DelegateSource.NoValue> value)
			=> IsMetBy(value.Value, value.Exception);

		public override string ToString()
			=> $"throws {typeof(TException).Name.PrependAOrAn()}";
	}
}
