using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Formatting;
using Testably.Expectations.Core.Sources;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatExceptionExtensions
{
	private readonly struct HasParamNameConstraint<T>(string expected) : IConstraint<T>,
		IDelegateConstraint<DelegateSource.NoValue>
		where T : ArgumentException
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
			=> $"has ParamName {Formatter.Format(expected)}";
	}
}
