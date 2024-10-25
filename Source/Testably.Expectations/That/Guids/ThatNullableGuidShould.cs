using System;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Formatting;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="Guid" />? values.
/// </summary>
public static partial class ThatNullableGuidShould
{
	private readonly struct Constraint(string expectation, Func<Guid?, bool> successIf)
		: IConstraint<Guid?>
	{
		public ConstraintResult IsMetBy(Guid? actual)
		{
			if (successIf(actual))
			{
				return new ConstraintResult.Success<Guid?>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> expectation;
	}
}
