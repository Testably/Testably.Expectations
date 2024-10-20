using Testably.Expectations.Core;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatStringExtensions
{
	private readonly struct IsNotNullConstraint : IExpectation<string>
	{
		#region IExpectation<string> Members

		/// <inheritdoc />
		public ConstraintResult IsMetBy(string? actual)
		{
			if (actual is null)
			{
				return new ConstraintResult.Failure(ToString(), "it was");
			}

			return new ConstraintResult.Success<string>(actual, ToString());
		}

		#endregion

		/// <inheritdoc />
		public override string ToString()
			=> "is not null";
	}
}
