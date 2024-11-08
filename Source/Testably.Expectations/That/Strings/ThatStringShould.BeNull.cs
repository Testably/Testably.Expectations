﻿using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

namespace Testably.Expectations;

public static partial class ThatStringShould
{
	/// <summary>
	///     Verifies that the subject is <see langword="null" />.
	/// </summary>
	public static AndOrResult<string?, IThat<string?>> BeNull(
		this IThat<string?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(
					new IsNullValueConstraint()),
			source);

	/// <summary>
	///     Verifies that the subject is not <see langword="null" />.
	/// </summary>
	public static AndOrResult<string, IThat<string?>> NotBeNull(
		this IThat<string?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(
					new IsNotNullValueConstraint()),
			source);

	private readonly struct IsNullValueConstraint : IValueConstraint<string?>
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

	private readonly struct IsNotNullValueConstraint : IValueConstraint<string>
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
