using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Formatting;
using Testably.Expectations.Options;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatObjectShould
{
	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static ObjectEqualityResult<object?, IThat<object?>> Be(
		this IThat<object?> source,
		object? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		ObjectEqualityOptions? options = new();
		return new ObjectEqualityResult<object?, IThat<object?>>(
			source.ExpectationBuilder
				.AddConstraint(new IsEqualValueConstraint(
					expected, doNotPopulateThisValue, options))
				.AppendMethodStatement(nameof(Be), doNotPopulateThisValue),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is of type <typeparamref name="TType" />.
	/// </summary>
	public static AndOrWhichResult<TType, IThat<object?>> Be<TType>(
		this IThat<object?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new IsValueConstraint<TType>())
				.AppendGenericMethodStatement<TType>(nameof(Be)),
			source);

	private readonly struct IsEqualValueConstraint(
		object? expected,
		string expectedExpression,
		ObjectEqualityOptions options)
		: IValueConstraint<object?>
	{
		public ConstraintResult IsMetBy(object? actual)
		{
			ObjectEqualityOptions.Result result = options.AreConsideredEqual(actual, expected);

			if (!result.AreConsideredEqual)
			{
				return new ConstraintResult.Failure(ToString(), result.Failure);
			}

			return new ConstraintResult.Success<object?>(actual, ToString());
		}

		public override string ToString()
			=> options.GetExpectation(expectedExpression);
	}

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
