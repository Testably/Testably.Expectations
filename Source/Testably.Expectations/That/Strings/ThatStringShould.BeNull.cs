using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatStringShould
{
	/// <summary>
	///     Verifies that the subject is <see langword="null" />.
	/// </summary>
	public static AndOrExpectationResult<string?, IThat<string?>> BeNull(
		this IThat<string?> source)
		=> new(source.ExpectationBuilder.Add(
				new IsNullConstraint(),
				b => b.AppendMethod(nameof(BeNull))),
			source);

	/// <summary>
	///     Verifies that the subject is not <see langword="null" />.
	/// </summary>
	public static AndOrExpectationResult<string, IThat<string?>> NotBeNull(
		this IThat<string?> source)
		=> new(source.ExpectationBuilder.Add(
				new IsNotNullConstraint(),
				b => b.AppendMethod(nameof(NotBeNull))),
			source);

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
			=> "be null";
	}

	private readonly struct IsNotNullConstraint : IConstraint<string>
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
			=> "not be null";
	}
}
