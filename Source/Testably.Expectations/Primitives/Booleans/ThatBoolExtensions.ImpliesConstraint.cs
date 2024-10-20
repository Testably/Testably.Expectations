using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Formatting;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatBoolExtensions
{
	private readonly struct ImpliesConstraint(bool consequent) : IConstraint<bool>
	{
		public ConstraintResult IsMetBy(bool actual)
		{
			if (!actual || consequent)
			{
				return new ConstraintResult.Success<bool>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(), "it did not");
		}

		public override string ToString()
			=> $"implies {Formatter.Format(consequent)}";
	}
}
