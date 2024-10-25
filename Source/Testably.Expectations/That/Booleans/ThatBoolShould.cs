using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Formatting;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="bool" /> values.
/// </summary>
public static partial class ThatBoolShould
{
	/// <summary>
	///     Start expectations for current <see cref="bool" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<bool> Should(this IExpectThat<bool> subject)
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<bool>(subject.ExpectationBuilder);
	}

	private readonly struct IsConstraint(bool expected) : IConstraint<bool>
	{
		public ConstraintResult IsMetBy(bool actual)
		{
			if (expected.Equals(actual))
			{
				return new ConstraintResult.Success<bool>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> $"be {Formatter.Format(expected)}";
	}
}
