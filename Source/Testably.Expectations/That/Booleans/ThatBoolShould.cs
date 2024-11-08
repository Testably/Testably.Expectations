using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Formatting;

namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="bool" /> values.
/// </summary>
public static partial class ThatBoolShould
{
	/// <summary>
	///     Start expectations for current <see cref="bool" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<bool> Should(this IExpectSubject<bool> subject)
		=> subject.Should(_ => { });

	private readonly struct IsValueConstraint(bool expected) : IValueConstraint<bool>
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
