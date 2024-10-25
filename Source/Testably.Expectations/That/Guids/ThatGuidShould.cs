using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Formatting;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="Guid" /> values.
/// </summary>
public static partial class ThatGuidShould
{
	/// <summary>
	///     Start expectations for current <see cref="Guid" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<Guid> Should(this IExpectThat<Guid> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<Guid>(subject.ExpectationBuilder);
	}

	private readonly struct Constraint(string expectation, Func<Guid, bool> successIf)
		: IConstraint<Guid>
	{
		public ConstraintResult IsMetBy(Guid actual)
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
