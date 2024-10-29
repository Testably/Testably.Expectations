using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatBoolShould
{
	/// <summary>
	///     Verifies that the subject implies the <paramref name="consequent" /> value.
	/// </summary>
	public static AndOrExpectationResult<bool, IThat<bool>> Imply(this IThat<bool> source,
		bool consequent,
		[CallerArgumentExpression("consequent")]
		string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder
				.AddConstraint(new ImpliesValueConstraint(consequent))
				.AppendMethodStatement(nameof(Imply), doNotPopulateThisValue),
			source);

	private readonly struct ImpliesValueConstraint(bool consequent) : IValueConstraint<bool>
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
			=> $"imply {Formatter.Format(consequent)}";
	}
}
