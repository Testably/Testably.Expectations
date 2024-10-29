using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatObjectShould
{
	/// <summary>
	///     Verifies that the subject is of type <typeparamref name="TType" />.
	/// </summary>
	public static AndOrWhichExpectationResult<TType, IThat<object?>> Be<TType>(
		this IThat<object?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new IsValueConstraint<TType>())
				.AppendGenericMethodStatement<TType>(nameof(Be)),
			source);

	private readonly struct IsValueConstraint<TType> : IValueConstraint<object?>
	{
		public ConstraintResult IsMetBy(object? actual)
		{
			if (actual is TType typedActual)
			{
				return new ConstraintResult.Success<TType>(typedActual, ToString());
			}

			return new ConstraintResult.Failure(ToString(),
				$"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> $"be type {Formatter.Format(typeof(TType))}";
	}
}
