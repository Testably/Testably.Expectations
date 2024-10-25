using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Core.Sources;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="Exception" /> values.
/// </summary>
public static partial class ThatExceptionShould
{
	/// <summary>
	///     Verifies that the actual <see cref="ArgumentException" /> has an <paramref name="expected" /> param name.
	/// </summary>
	public static AndOrExpectationResult<TException, ThatExceptionShould<TException>> HaveParamName<TException>(
		this ThatExceptionShould<TException> source,
		string expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		where TException : ArgumentException?
		=> new(source.ExpectationBuilder.Add(
				new HasParamNameConstraint<TException>(expected),
				b => b.AppendMethod(nameof(HaveParamName), doNotPopulateThisValue)),
			source);

	private readonly struct HasParamNameConstraint<T>(string expected) : IConstraint<T>,
		IDelegateConstraint<DelegateSource.NoValue>
		where T : ArgumentException?
	{
		public ConstraintResult IsMetBy(SourceValue<DelegateSource.NoValue> value)
		{
			return IsMetBy(value.Exception as T);
		}

		public ConstraintResult IsMetBy(T? actual)
		{
			if (actual == null)
			{
				return new ConstraintResult.Failure(ToString(),
					"found <null>");
			}

			if (actual.ParamName == expected)
			{
				return new ConstraintResult.Success<T?>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(),
				$"found ParamName {Formatter.Format(actual.ParamName)}");
		}

		public override string ToString()
			=> $"have ParamName {Formatter.Format(expected)}";
	}
}
