using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Formatting;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on <see langword="enum" /> values.
/// </summary>
public static partial class ThatEnumShould
{
	/// <summary>
	///     Start expectations for the current <typeparamref name="TEnum" /> <paramref name="subject" />.
	/// </summary>
	public static That<TEnum> Should<TEnum>(this IExpectThat<TEnum> subject)
		where TEnum : struct, Enum
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new ThatImpl<TEnum>(subject.ExpectationBuilder);
	}

	private readonly struct Constraint<TEnum>(string expectation, Func<TEnum, bool> successIf)
		: IConstraint<TEnum>
		where TEnum : struct, Enum
	{
		public ConstraintResult IsMetBy(TEnum actual)
		{
			if (successIf(actual))
			{
				return new ConstraintResult.Success<TEnum?>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> expectation;
	}
}
