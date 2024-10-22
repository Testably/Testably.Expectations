using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Formatting;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatStringExtensions
{
	private readonly struct IsNullConstraint : IConstraint<string?>
	{
		#region IExpectation<string> Members

		/// <inheritdoc />
		public ConstraintResult IsMetBy(string? actual)
		{
			if (actual is not null)
			{
				return new ConstraintResult.Failure(ToString(),
					$"found {Formatter.Format(actual)}");
			}

			return new ConstraintResult.Success<string?>(null, ToString());
		}

		#endregion

		/// <inheritdoc />
		public override string ToString()
			=> "is null";
	}
}
